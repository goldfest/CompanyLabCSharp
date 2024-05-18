using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TravelCompanyDatabaseImplement.Models
{
	public class MessageInfo : IMessageInfoModel
	{
        [NotMapped]
        public int Id { get; private set; }

        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MessageId { get; private set; } = string.Empty;

        [DataMember]
        public int? ClientId { get; private set; }

        [DataMember]
        [Required]
        public string SenderName { get; private set; } = string.Empty;

        [DataMember]
        [Required]
        public DateTime DateDelivery { get; private set; } = DateTime.Now;

        [DataMember]
        [Required]
        public string Subject { get; private set; } = string.Empty;

        [DataMember]
        [Required]
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
