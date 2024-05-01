using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataFileSingleton source;
        public OrderStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            return source.Orders
            .Select(x => AccessTravelStorage(x.GetViewModel))
           .ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel
model)
        {
            return source.Orders
               .Where(x => (
                        (!model.Id.HasValue || x.Id == model.Id) &&
                        (!model.DateFrom.HasValue || x.DateCreate >= model.DateFrom) &&
                        (!model.DateTo.HasValue || x.DateCreate <= model.DateTo)
                        &&
                        (!model.ClientId.HasValue || x.ClientId == model.ClientId)
                        &&
                        (!model.ImplementerId.HasValue || x.ImplementerId == model.ImplementerId)
                    )
                )
           .Select(x => AccessTravelStorage(x.GetViewModel))
           .ToList();
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            return AccessTravelStorage(source.Orders
            .FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))?.GetViewModel);
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = source.Orders.Count > 0 ? source.Orders.Max(x => x.Id) + 1 : 1;
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            source.Orders.Add(newOrder);
            source.SaveOrders();
            return AccessTravelStorage(newOrder.GetViewModel);
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            source.SaveOrders();
            return AccessTravelStorage(order.GetViewModel);
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(x => x.Id ==
           model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
                source.SaveOrders();
                return AccessTravelStorage(element.GetViewModel);
            }
            return null;
        }

        public OrderViewModel AccessTravelStorage(OrderViewModel model)
        {
            if (model == null)
                return null;
            foreach (var Travel in source.Travels)
            {
                if (Travel.Id == model.TravelId)
                {
                    model.TravelName = Travel.TravelName;
                    break;
                }
            }
            return model;
        }

        public OrderViewModel AccessClientStorage(OrderViewModel model)
        {
            if (model == null)
                return null;
            var client = source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client != null)
                model.ClientFIO = client.ClientFIO;
            return model;
        }
    }
}
