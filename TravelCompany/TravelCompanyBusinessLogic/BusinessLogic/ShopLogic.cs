using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyBusinessLogic.BusinessLogic
{
    public class ShopLogic : IShopLogic
    {
        private readonly ILogger _logger;
        private readonly IShopStorage _shopStorage;
        private readonly ITravelStorage _TravelStorage;

        public ShopLogic(ILogger<ShopLogic> logger, IShopStorage shopStorage, ITravelStorage TravelStorage)
        {
            _logger = logger;
            _shopStorage = shopStorage;
            _TravelStorage = TravelStorage;
        }

        public List<ShopViewModel>? ReadList(ShopSearchModel? model)
        {
            _logger.LogInformation("ReadList. ShopName:{ShopName}.Id:{ Id}", model?.ShopName, model?.Id);
            var list = model == null ? _shopStorage.GetFullList() : _shopStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public ShopViewModel? ReadElement(ShopSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ShopName:{ShopName}.Id:{ Id}", model.ShopName, model.Id);
            var element = _shopStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(ShopBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_shopStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        public bool MakeSupply(SupplyBindingModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (model.Count <= 0)
            {
                throw new ArgumentException("Количество изделий должно быть больше 0");
            }
            var shop = _shopStorage.GetElement(new ShopSearchModel
            {
                Id = model.ShopId
            });
            if (shop == null)
            {
                throw new ArgumentException("Магазина не существует");
            }

            var totalSupplyCount = shop.ShopTravels.Values.Sum(supply => supply.Item2) + model.Count;
            if (totalSupplyCount > shop.TravelMaxCount)
            {
                throw new ArgumentException("Количество поставляемых товаров превышает максимальное количество товаров, которое может содержать магазин");
            }

            if (shop.ShopTravels.ContainsKey(model.TravelId))
            {
                var oldValue = shop.ShopTravels[model.TravelId];
                oldValue.Item2 += model.Count;
                shop.ShopTravels[model.TravelId] = oldValue;
            }
            else
            {
                var Travel = _TravelStorage.GetElement(new TravelSearchModel
                {
                    Id = model.TravelId
                });
                if (Travel == null)
                {
                    throw new ArgumentException($"Поставка: Товар с id:{model.TravelId} не найденн");
                }
                shop.ShopTravels.Add(model.TravelId, (Travel, model.Count));
            }

            _shopStorage.Update(new ShopBindingModel()
            {
                Id = shop.Id,
                ShopName = shop.ShopName,
                Adress = shop.Adress,
                OpeningDate = shop.OpeningDate,
                ShopTravels = shop.ShopTravels,
                TravelMaxCount = shop.TravelMaxCount,
            });

            return true;
        }


        private void CheckModel(ShopBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.Adress))
            {
                throw new ArgumentException("Адрес магазина длжен быть заполнен", nameof(model.Adress));
            }
            if (string.IsNullOrEmpty(model.ShopName))
            {
                throw new ArgumentException("Название магазина должно быть заполнено", nameof(model.ShopName));
            }
            _logger.LogInformation("Shop. ShopName:{ShopName}.Adres:{Adres}.OpeningDate:{OpeningDate}.Id:{ Id}", model.ShopName, model.Adress, model.OpeningDate, model.Id);
            var element = _shopStorage.GetElement(new ShopSearchModel
            {
                ShopName = model.ShopName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Магазин с таким названием уже есть");
            }
        }

        public bool Sale(SupplySearchModel model)
        {
            if (!model.TravelId.HasValue || !model.Count.HasValue)
            {
                return false;
            }
            _logger.LogInformation("Check Travel count in all shops");
            if (_shopStorage.Sale(model))
            {
                _logger.LogInformation("Selling sucsess");
                return true;
            }
            _logger.LogInformation("Selling failed");
            return false;
        }
    }
}
