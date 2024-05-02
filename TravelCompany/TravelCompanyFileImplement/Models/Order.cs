using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Enums;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TravelCompanyFileImplement.Models
{
    public class Order : IOrderModel
    {
        public int TravelId { get; private set; }
        public int ClientId { get; private set; }
        public int? ImplementerId { get; private set; } = null;
        public int Count { get; private set; }

        public double Sum { get; private set; }

        public OrderStatus Status { get; private set; } 

        public DateTime DateCreate { get; private set; }

        public DateTime? DateImplement { get; private set; }

        public int Id { get; private set; }

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
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement,
                ImplementerId = model.ImplementerId,

            };
        }

        public static Order? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Order()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                TravelId = Convert.ToInt32(element.Element("TravelId")!.Value),
                ClientId = Convert.ToInt32(element.Element("ClientId")!.Value),
                ImplementerId = Convert.ToInt32(element.Element("ImplementerId")!.Value),
                Count = Convert.ToInt32(element.Element("Count")!.Value),
                Sum = Convert.ToDouble(element.Element("Sum")!.Value),
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), element.Element("Status")!.Value.ToString()),
                DateCreate = Convert.ToDateTime(element.Element("DateCreate")!.Value),
                DateImplement = string.IsNullOrEmpty(element.Element("DateImplement")!.Value) ? null : Convert.ToDateTime(element.Element("DateImplement")!.Value)
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
            ClientId = ClientId,
            ImplementerId = ImplementerId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };

        public XElement GetXElement => new("Order",
          new XAttribute("Id", Id),
          new XElement("TravelId", TravelId),
          new XElement("Count", Count.ToString()),
          new XElement("Sum", Sum.ToString()),
          new XElement("Status", Status.ToString()),
          new XElement("DateCreate", DateCreate.ToString()),
          new XElement("DateImplement", DateImplement.ToString()));
    }
}
