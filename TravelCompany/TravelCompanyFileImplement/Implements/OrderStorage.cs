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
            .Select(x => AccessStorage(x.GetViewModel))
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
                        (!model.Status.HasValue || x.Status == model.Status)
                    )
                )
           .Select(x => AccessStorage(x.GetViewModel))
           .ToList();
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            return AccessStorage(source.Orders
            .FirstOrDefault(
                x => ((model.Id.HasValue && x.Id == model.Id) ||
                (model.ImplementerId.HasValue && model.Status.HasValue &&
                x.ImplementerId == model.ImplementerId && x.Status == model.Status)))?.GetViewModel);
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
            return AccessStorage(newOrder.GetViewModel);
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
            return AccessStorage(order.GetViewModel);
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(x => x.Id ==
           model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
                source.SaveOrders();
                return AccessStorage(element.GetViewModel);
            }
            return null;
        }

        public OrderViewModel AccessStorage(OrderViewModel model)
        {
            if (model == null)
                return null;
            var iceCream = source.Travels.FirstOrDefault(x => x.Id == model.Id);
            var client = source.Clients.FirstOrDefault(x => x.Id == model.Id);
            var implementer = source.Implementers.FirstOrDefault(x => x.Id == model.ImplementerId);
            if (iceCream != null)
                model.TravelName = iceCream.TravelName;
            if (client != null)
                model.ClientFIO = client.ClientFIO;
            if (implementer != null)
                model.ImplementerFIO = implementer.ImplementerFIO;
            return model;
        }
    }
}
