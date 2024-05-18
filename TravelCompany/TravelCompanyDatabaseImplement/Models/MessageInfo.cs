using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace TravelCompanyDatabaseImplement.Models
{
	public class MessageInfo : IMessageInfoModel
	{
		[Key]
		public string MessageId { get; private set; } = string.Empty;

		public int? ClientId { get; private set; }

		public string SenderName { get; private set; } = string.Empty;

		public DateTime DateDelivery { get; private set; } = DateTime.Now;

		public string Subject { get; private set; } = string.Empty;

		public string Body { get; private set; } = string.Empty;

		public Client? Client { get; private set; }

		public static MessageInfo? Create(TravelCompanyDataBase context, MessageInfoBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				Body = model.Body,
				Subject = model.Subject,
				ClientId = context.Clients.FirstOrDefault(x => x.Email == model.SenderName).Id,
				Client = context.Clients.FirstOrDefault(x => x.Email == model.SenderName),
				MessageId = model.MessageId,
				SenderName = model.SenderName,
				DateDelivery = model.DateDelivery,
			};
		}

		public MessageInfoViewModel GetViewModel => new()
		{
			Body = Body,
			Subject = Subject,
			ClientId = ClientId,
			MessageId = MessageId,
			SenderName = SenderName,
			DateDelivery = DateDelivery,
		};
	}
}
