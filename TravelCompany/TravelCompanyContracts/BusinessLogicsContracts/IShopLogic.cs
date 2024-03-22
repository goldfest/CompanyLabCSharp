using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface IShopLogic
    {
        List<ShopViewModel>? ReadList(ShopSearchModel? model);
        ShopViewModel? ReadElement(ShopSearchModel model);
        bool Create(ShopBindingModel model);
        bool Update(ShopBindingModel model);
        bool Delete(ShopBindingModel model);
        bool MakeSupply(SupplyBindingModel model);
    }
}