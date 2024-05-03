using TravelCompanyDataModels.Enums;
using Microsoft.Extensions.Logging;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyBusinessLogic.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ILogger _logger;
        private readonly IOrderStorage _orderStorage;
        static readonly object _locker = new object();
        private readonly IShopStorage _shopStorage;

        public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage, IShopStorage shopStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
            _shopStorage = shopStorage;
        }

        public OrderViewModel? ReadElement(OrderSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ClientId:{ClientId}.Status:{Status}.ImplementerId:{ImplementerId}.DateFrom:{DateFrom}.DateTo:{DateTo}OrderId:{Id}",
                model.ClientId, model.Status, model.ImplementerId, model.DateFrom, model.DateTo, model.Id);
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
            _logger.LogInformation("ReadList. ClientId:{ClientId}.Status:{Status}.ImplementerId:{ImplementerId}.DateFrom:{DateFrom}.DateTo:{DateTo}OrderId:{Id}",
            model?.ClientId, model?.Status, model?.ImplementerId, model?.DateFrom, model?.DateTo, model?.Id);
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
            lock (_locker)
            {
                return ChangeStatus(model, OrderStatus.Выполняется);
            }
        }

        public bool FinishOrder(OrderBindingModel model)
        {
            return ChangeStatus(model, OrderStatus.Готов);
        }

        public bool DeliveryOrder(OrderBindingModel model)
        {
            lock (_locker)
            {
                model = FillOrderBindingModel(model);
                if (model.Status != OrderStatus.Готов && model.Status != OrderStatus.Ожидает)
                {
                    _logger.LogWarning("Changing status operation faled: Current-{Status}:required-Выдан.", model.Status);
                    throw new InvalidOperationException($"Невозможно приствоить статус выдан заказу с текущим статусом {model.Status}");
                }
                if (!_shopStorage.RestockingShops(new SupplyBindingModel
                {
                    TravelId = model.TravelId,
                    Count = model.Count
                }))
                {
                    if (model.Status == OrderStatus.Готов || model.Status == OrderStatus.Ожидает)
                    {
                        model.Status = OrderStatus.Ожидает;
                        return UpdateOrder(model);
                    }
                }
                model.Status = OrderStatus.Выдан;
                return UpdateOrder(model);
            }
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
                throw new ArgumentException("Колличество пиццы в заказе не может быть меньше 1", nameof(model.Count));
            }
            if (model.Sum <= 0)
            {
                throw new ArgumentException("Стоимость заказа на может быть меньше 1", nameof(model.Sum));
            }
            if (model.DateImplement.HasValue && model.DateImplement < model.DateCreate)
            {
                throw new ArithmeticException($"Дата выдачи заказа {model.DateImplement} не может быть раньше даты его создания {model.DateCreate}");
            }
            _logger.LogInformation("Travel. TravelId:{TravelId}.Count:{Count}.Sum:{Sum}Id:{Id}",
                model.TravelId, model.Count, model.Sum, model.Id);
        }
        private bool ChangeStatus(OrderBindingModel model, OrderStatus requiredStatus)
        {
            model = FillOrderBindingModel(model);

            if (requiredStatus - model.Status == 1)
            {
                model.Status = requiredStatus;
                if (model.Status == OrderStatus.Готов)
                    model.DateImplement = DateTime.Now;
                return UpdateOrder(model);
            }
            _logger.LogWarning("Changing status operation faled: Current-{Status}:required-{requiredStatus}.", model.Status, requiredStatus);
            throw new InvalidOperationException($"Невозможно приствоить статус {requiredStatus} заказу с текущим статусом {model.Status}");
        }

        private OrderBindingModel FillOrderBindingModel(OrderBindingModel model)
        {
            CheckModel(model, false);
            var element = _orderStorage.GetElement(new OrderSearchModel()
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new InvalidOperationException(nameof(element));
            }
            model.Id = element.Id;
            model.DateCreate = element.DateCreate;
            model.TravelId = element.TravelId;
            model.DateImplement = element.DateImplement;
            model.ClientId = element.ClientId;
            model.Status = element.Status;
            model.Count = element.Count;
            model.Sum = element.Sum;
            if (!model.ImplementerId.HasValue)
            {
                model.ImplementerId = element.ImplementerId;
            }
            return model;
        }

        private bool UpdateOrder(OrderBindingModel model)
        {
            if (_orderStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            _logger.LogWarning("Update operation sucsess");
            return true;
        }
    }
}
