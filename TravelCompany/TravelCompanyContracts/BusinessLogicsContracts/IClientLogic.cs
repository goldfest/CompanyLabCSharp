using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyContracts.SearchModels;

namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface IClientLogic
    {
        List<ClientViewModel>? ReadList(ClientSearchModel? model);
        ClientViewModel? ReadElement(ClientSearchModel model);
        bool Create(ClientBindingModel model);
        bool Update(ClientBindingModel model);
        bool Delete(ClientBindingModel model);
    }
}
