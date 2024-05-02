using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyBusinessLogic.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ILogger _logger;
        private readonly IOrderStorage _orderStorage;
        static readonly object locker = new object();

        public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
        }

        public OrderViewModel? ReadElement(OrderSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. Id:{ Id}", model.Id);
            var element = _orderStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public List<OrderViewModel>? ReadList(OrderSearchModel? model)
        {
            _logger.LogInformation("ReadList. OrderId:{Id}", model?.Id);
            var list = model == null ? _orderStorage.GetFullList() : _orderStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public bool CreateOrder(OrderBindingModel model)
        {
            CheckModel(model);

            if (model.Status != OrderStatus.Неизвестен)
                return false;
            model.Status = OrderStatus.Принят;

            if (_orderStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool TakeOrderInWork(OrderBindingModel model)
        {
            lock (locker)
            {
                return ToNextStatus(model, OrderStatus.Выполняется);
            }
        }

        public bool FinishOrder(OrderBindingModel model)
        {
            return ToNextStatus(model, OrderStatus.Готов);
        }

        public bool DeliveryOrder(OrderBindingModel model)
        {
            return ToNextStatus(model, OrderStatus.Выдан);
        }

        public bool ToNextStatus(OrderBindingModel model, OrderStatus orderStatus)
        {
            CheckModel(model, false);
            var element = _orderStorage.GetElement(new OrderSearchModel { Id = model.Id });
            if (element == null)
            {
                _logger.LogWarning("Read operation failed");
                return false;
            }
            if (element.Status != orderStatus - 1)
            {
                _logger.LogWarning("Status change operation failed");
                throw new InvalidOperationException("Текущий статус заказа не может быть переведен в выбранный");
            }
            model.Status = orderStatus;
            if (model.Status == OrderStatus.Готов) model.DateImplement = DateTime.Now;
            if (element.ImplementerId.HasValue)
                model.ImplementerId = element.ImplementerId;
            _orderStorage.Update(model);
            return true;
        }

        private void CheckModel(OrderBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (model.Count <= 0)
            {
                throw new ArgumentNullException("Количество изделий должно быть больше 0", nameof(model.Count));
            }
            if (model.Sum <= 0)
            {
                throw new ArgumentNullException("Цена заказа должна быть больше 0", nameof(model.Sum));
            }
                _logger.LogInformation("Travel. TravelId:{TravelId}.Count:{Count}.Sum:{Sum}Id:{Id}", model.TravelId, model.Count, model.Sum, model.Id);
        }
    }
}
