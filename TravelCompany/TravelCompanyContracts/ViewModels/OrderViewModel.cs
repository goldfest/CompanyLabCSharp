using TravelCompanyDataModels;
using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;

namespace TravelCompanyContracts.ViewModels
{
    public class OrderViewModel : IOrderModel
    {
        [DisplayName("Номер")]
        public int Id { get; set; }
        public int TravelId { get; set; }
        public int ClientId { get; set; }
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; } = string.Empty;
        [DisplayName("Путёвка")]
        public string TravelName { get; set; } = string.Empty;
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public double Sum { get; set; }
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
