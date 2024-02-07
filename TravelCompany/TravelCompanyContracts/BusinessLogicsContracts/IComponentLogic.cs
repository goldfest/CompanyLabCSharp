using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface IComponentLogic
    {
        List<ComponentViewModel>? ReadList(ComponentSearchModel? model);
        ComponentViewModel? ReadElement(ComponentSearchModel model);
        bool Create(ComponentBindingModel model);
        bool Update(ComponentBindingModel model);
        bool Delete(ComponentBindingModel model);
    }
}
