using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.StoragesContracts
{
    public interface IShopStorage
    {
        List<ShopViewModel> GetFullList();
        List<ShopViewModel> GetFilteredList(ShopSearchModel model);
        ShopViewModel? GetElement(ShopSearchModel model);
        ShopViewModel? Insert(ShopBindingModel model);
        ShopViewModel? Update(ShopBindingModel model);
        ShopViewModel? Delete(ShopBindingModel model);
        bool Sale(SupplySearchModel model);
        bool RestockingShops(SupplyBindingModel model);
    }
}