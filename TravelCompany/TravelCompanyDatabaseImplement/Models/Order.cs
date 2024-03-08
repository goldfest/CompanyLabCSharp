using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static Order? Create(OrderBindingModel model)
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
            TravelId = TravelId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
            Id = Id,
        };

    }
}
