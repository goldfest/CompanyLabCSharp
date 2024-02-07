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
    public interface IComponentStorage
    {
        List<ComponentViewModel> GetFullList();
        List<ComponentViewModel> GetFilteredList(ComponentSearchModel model);
        ComponentViewModel? GetElement(ComponentSearchModel model);
        ComponentViewModel? Insert(ComponentBindingModel model);
        ComponentViewModel? Update(ComponentBindingModel model);
        ComponentViewModel? Delete(ComponentBindingModel model);

    }
}
