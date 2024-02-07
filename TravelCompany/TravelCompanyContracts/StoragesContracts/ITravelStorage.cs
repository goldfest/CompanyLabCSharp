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
    public interface ITravelStorage
    {
        List<TravelViewModel> GetFullList();
        List<TravelViewModel> GetFilteredList(TravelSearchModel model);
        TravelViewModel? GetElement(TravelSearchModel model);
        TravelViewModel? Insert(TravelBindingModel model);
        TravelViewModel? Update(TravelBindingModel model);
        TravelViewModel? Delete(TravelBindingModel model);
    }
}
