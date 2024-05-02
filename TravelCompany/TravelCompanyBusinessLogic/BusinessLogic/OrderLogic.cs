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
        private readonly IShopStorage _shopStorage;

        public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage, IShopStorage shopStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
            _shopStorage = shopStorage;
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
                model.Status = OrderStatus.Неизвестен;
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool TakeOrderInWork(OrderBindingModel model)
        {
            return ToNextStatus(model, OrderStatus.Выполняется);
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
            var element = _orderStorage.GetElement(new OrderSearchModel()
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            model.TravelId = element.TravelId;
            model.DateCreate = element.DateCreate;
            model.DateImplement = element.DateImplement;
            model.Status = element.Status;
            model.Count = element.Count;
            model.Sum = element.Sum;

            if (model.Status != orderStatus - 1)
            {
                _logger.LogWarning("Status update to " + orderStatus + " operation failed");
                return false;
            }
            model.Status = orderStatus;

            if (model.Status == OrderStatus.Выдан)
            {
                model.DateImplement = DateTime.Now;
            }

            if (_orderStorage.Update(model) == null)
            {
                model.Status--;
                _logger.LogWarning("Changing status operation faled");
                return false;
            }
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
            if (model.DateImplement.HasValue && model.DateImplement < model.DateCreate)
            {
                throw new ArithmeticException($"Дата выдачи заказа {model.DateImplement} должна быть позже даты его создания {model.DateCreate}");
            }
                _logger.LogInformation("Travel. TravelId:{TravelId}.Count:{Count}.Sum:{Sum}Id:{Id}", model.TravelId, model.Count, model.Sum, model.Id);
        }
    }
}
