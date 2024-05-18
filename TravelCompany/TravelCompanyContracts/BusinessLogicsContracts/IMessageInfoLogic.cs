using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyContracts.BusinessLogicsContracts
{
	public interface IMessageInfoLogic
	{
		List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model);

		bool Create(MessageInfoBindingModel model);
	}
}