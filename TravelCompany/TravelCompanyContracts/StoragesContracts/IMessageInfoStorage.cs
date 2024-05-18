using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyContracts.StoragesContracts
{
	public interface IMessageInfoStorage
	{
		List<MessageInfoViewModel> GetFullList();

		List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model);

		MessageInfoViewModel? GetElement(MessageInfoSearchModel model);

		MessageInfoViewModel? Insert(MessageInfoBindingModel model);
	}
}