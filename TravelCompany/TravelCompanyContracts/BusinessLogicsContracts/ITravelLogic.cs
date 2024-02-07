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
    public interface ITravelLogic
    {
        List<TravelViewModel>? ReadList(TravelSearchModel? model);
        TravelViewModel? ReadElement(TravelSearchModel model);
        bool Create(TravelBindingModel model);
        bool Update(TravelBindingModel model);
        bool Delete(TravelBindingModel model);
    }
}
