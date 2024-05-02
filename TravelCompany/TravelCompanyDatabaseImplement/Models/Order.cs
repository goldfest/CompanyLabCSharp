using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelCompanyDatabaseImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }
        [Required]
        public int Count { get; private set; }
        [Required]
        public double Sum { get; private set; }
        [Required]
        public OrderStatus Status { get; private set; }
        [Required]
        public DateTime DateCreate { get; private set; }
        public DateTime? DateImplement { get; private set; }
        [Required]
        public int TravelId { get; private set; }
        public virtual Travel Travel { get; private set; }
        [Required]
        public int ClientId { get; private set; }
        public virtual Client Client { get; private set; }
        public int? ImplementerId { get; private set; } = null;
        public virtual Implementer? Implementer { get; private set; }
        public static Order? Create(TravelCompanyDataBase context, OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order()
            {
                Id = model.Id,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement,
                TravelId = model.TravelId,
                Travel = context.Travels.FirstOrDefault(x => x.Id == model.TravelId),
                ClientId = model.ClientId,
                Client = context.Clients.FirstOrDefault(x => x.Id == model.ClientId),
                ImplementerId = model.ImplementerId,
                Implementer = (model.ImplementerId.HasValue ? context.Implementers.FirstOrDefault(x => x.Id == model.ImplementerId)
                : null),
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
            ImplementerId = model.ImplementerId;
        }

        public OrderViewModel GetViewModel => new()
        {
            TravelId = TravelId,
            ClientId = ClientId,
            ImplementerId = ImplementerId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
            TravelName = Travel.TravelName,
            Id = Id,
            ClientFIO = Client.ClientFIO,
            ImplementerFIO = (Implementer != null ? Implementer.ImplementerFIO : string.Empty)

        };

    }
}
