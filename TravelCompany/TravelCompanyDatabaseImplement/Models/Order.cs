using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace TravelCompanyDatabaseImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }

        [Required]
        public int ClientId { get; private set; }

        public virtual Client Client { get; private set; } = new();

        [Required]
        public int TravelId { get; private set; }

        public virtual Travel Travel { get; set; } = new();

        public int? ImplementerId { get; private set; }

        public virtual Implementer? Implementer { get; set; } = new();

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
                ClientId = model.ClientId,
                Client = context.Clients.First(x => x.Id == model.ClientId),
                TravelId = model.TravelId,
                Travel = context.Travels.First(x => x.Id == model.TravelId),
                ImplementerId = model.ImplementerId,
                Implementer = model.ImplementerId.HasValue ? context.Implementers.First(x => x.Id == model.ImplementerId) : null,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement,
            };
        }

        public void Update(TravelCompanyDataBase context, OrderBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            Status = model.Status;
            DateImplement = model.DateImplement;
            ImplementerId = model.ImplementerId;
            Implementer = model.ImplementerId.HasValue ? context.Implementers.First(x => x.Id == model.ImplementerId) : null;
        }

        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            ClientId = ClientId,
            ClientFIO = Client.ClientFIO,
            TravelId = TravelId,
            TravelName = Travel.TravelName,
            ImplementerId = ImplementerId,
            ImplementerFIO = Implementer != null ? Implementer.ImplementerFIO : null,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
        };
    }
}
