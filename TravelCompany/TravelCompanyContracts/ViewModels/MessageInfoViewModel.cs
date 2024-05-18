using TravelCompanyDataModels.Models;
using System.ComponentModel;
using TravelCompanyContracts.Attributes;


namespace TravelCompanyContracts.ViewModels
{
	public class MessageInfoViewModel : IMessageInfoModel
	{
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(visible: false)]
        public string MessageId { get; set; } = string.Empty;
        [Column(visible: false)]
        public int? ClientId { get; set; }
        [Column(title: "Отправитель", width: 150)]
        public string SenderName { get; set; } = string.Empty;
        [Column(title: "Дата письма", width: 120)]
        public DateTime DateDelivery { get; set; }
        [Column(title: "Заголовок", width: 120)]
        public string Subject { get; set; } = string.Empty;
        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string Body { get; set; } = string.Empty;
	}
}