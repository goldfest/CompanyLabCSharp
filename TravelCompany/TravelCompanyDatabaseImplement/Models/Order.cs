using System.ComponentModel.DataAnnotations;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;

namespace TravelCompanyDatabaseImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }

        [Required]
        public int TravelId { get; private set; }

        public virtual Travel Travel { get; set; } = new();

        [Required]
        public int Count { get; private set; }

        [Required]
        public double Sum { get; private set; }

        [Required]
        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

        [Required]
        public DateTime DateCreate { get; private set; } = DateTime.Now;

        public DateTime? DateImplement { get; private set; }

        public static Order Create(TravelCompanyDataBase context, OrderBindingModel model)
        {
            return new Order()
            {
                Id = model.Id,
                TravelId = model.TravelId,
                Travel = context.Travels.First(x => x.Id == model.TravelId),
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement,
            };
        }

        public void Update(OrderBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            Status = model.Status;
            DateImplement = model.DateImplement;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            TravelId = TravelId,
            TravelName = Travel.TravelName,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
        };
    }
}
