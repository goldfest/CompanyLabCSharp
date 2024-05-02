using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BindingModels
{
    public class OrderBindingModel : IOrderModel
    {
        public int Id { get; set; }
        public int TravelId { get; set; }
        public int? ImplementerId { get; set; } = null;
        public int ClientId { get; set; }
        public int Count { get; set; }
        public double Sum {  get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public DateTime? DateImplement { get; set; }
    }
}
