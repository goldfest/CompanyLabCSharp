using TravelCompanyDataModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.ViewModels
{
    public class OrderViewModel
    {
        [DisplayName("Номер")]
        public int Id { get; set; }
        public int TravelId { get; set; }
        [DisplayName("Изделие")]
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
