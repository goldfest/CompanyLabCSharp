using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel>? ReadList(ImplementerSearchModel? model);
        ImplementerViewModel? ReadElement(ImplementerSearchModel model);
        bool Create(ImplementerBindingModel model);
        bool Update(ImplementerBindingModel model);
        bool Delete(ImplementerBindingModel model);
    }
}
