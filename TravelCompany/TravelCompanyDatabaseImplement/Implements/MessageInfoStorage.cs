using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;

namespace TravelCompanyDatabaseImplement.Implements
{
	public class MessageInfoStorage : IMessageInfoStorage
	{

		public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
		{
			using var context = new TravelCompanyDataBase();
			if (model.MessageId != null)
			{
				return context.Messages.FirstOrDefault(x => x.MessageId == model.MessageId)?.GetViewModel;
			}
			return null;
		}

		public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
		{
			using var context = new TravelCompanyDataBase();
			return context.Messages
				.Where(x => x.ClientId == model.ClientId)
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<MessageInfoViewModel> GetFullList()
		{
			using var context = new TravelCompanyDataBase();
			return context.Messages
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
		{
			using var context = new TravelCompanyDataBase();
			var newMessage = MessageInfo.Create(context, model);
			if (newMessage == null || context.Messages.Any(x => x.MessageId.Equals(model.MessageId)))
			{
				return null;
			}
			context.Messages.Add(newMessage);
			context.SaveChanges();
			return newMessage.GetViewModel;
		}
	}
}
