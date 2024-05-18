using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;
using System.ComponentModel;
using TravelCompanyContracts.Attributes;


namespace TravelCompanyContracts.ViewModels
{
    public class OrderViewModel : IOrderModel
    {
        [Column(title: "Номер", width: 90)]
        public int Id { get; set; }
        [Column(visible: false)]
        public int TravelId { get; set; }
        [Column(visible: false)]
        public int ClientId { get; set; }
        [Column(visible: false)]
        public int? ImplementerId { get; set; } = null;
        [Column(title: "Клиент", width: 190)]
        public string ClientFIO { get; set; } = string.Empty;
        [Column(title: "Путёвка", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string TravelName { get; set; } = string.Empty;
        [Column(title: "Исполнитель", width: 150)]
        public string ImplementerFIO { get; set; } = string.Empty;
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 120)]
        public double Sum { get; set; }
        [Column(title: "Статус", width: 70)]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        [Column(title: "Дата создания", width: 120)]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [Column(title: "Дата выполнения", width: 120)]
        public DateTime? DateImplement { get; set; }
    }
}
