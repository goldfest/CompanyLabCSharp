using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyListImplement.Models
{
    public class Order : IOrderModel
    {
        public int Id { get; private set; }
        public int TravelId { get; private set; }
        public int Count { get; private set; }
        public double Sum { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime DateCreate { get; private set; }
        public DateTime? DateImplement { get; private set; }
        public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order()
            {
                Id = model.Id,
                TravelId = model.TravelId,
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
            TravelId = model.TravelId;
            Count = model.Count;
            Sum = model.Sum;
            Status = model.Status;
            DateCreate = model.DateCreate;
            DateImplement = model.DateImplement;
        }
        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            TravelId = TravelId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement,
        };
    }
}
