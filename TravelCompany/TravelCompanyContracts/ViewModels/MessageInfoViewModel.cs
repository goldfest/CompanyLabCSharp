using TravelCompanyDataModels.Models;
using System.ComponentModel;

namespace TravelCompanyContracts.ViewModels
{
	public class MessageInfoViewModel : IMessageInfoModel
	{
		public string MessageId { get; set; } = string.Empty;

		public int? ClientId { get; set; }

		[DisplayName("Отправитель")]
		public string SenderName { get; set; } = string.Empty;

		[DisplayName("Дата письма")]
		public DateTime DateDelivery { get; set; }

		[DisplayName("Заголовок")]
		public string Subject { get; set; } = string.Empty;

		[DisplayName("Текст")]
		public string Body { get; set; } = string.Empty;
	}
}