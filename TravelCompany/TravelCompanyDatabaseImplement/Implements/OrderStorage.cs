using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new TravelCompanyDataBase();
            return context.Orders
            .Select(x => AccessTravelStorage(x.GetViewModel))
           .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return new();
            }
            using var context = new TravelCompanyDataBase();
            return context.Orders
            .Where(x => x.Id == model.Id)
           .Select(x => AccessTravelStorage(x.GetViewModel))
           .ToList();
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            using var context = new TravelCompanyDataBase();
            return AccessTravelStorage(context.Orders.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel);
        }
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            using var context = new TravelCompanyDataBase();
            context.Orders.Add(newOrder);
            context.SaveChanges();
            return AccessTravelStorage(newOrder.GetViewModel);
        }
        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var order = context.Orders.FirstOrDefault(x => x.Id ==
           model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            context.SaveChanges();
            return AccessTravelStorage(order.GetViewModel);
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
                return AccessTravelStorage(element.GetViewModel);
            }
            return null;
        }

        public static OrderViewModel AccessTravelStorage(OrderViewModel model)
        {
            if (model == null)
                return null;
            using var context = new TravelCompanyDataBase();
            foreach (var Travel in context.Travels)
            {
                if (Travel.Id == model.TravelId)
                {
                    model.TravelName = Travel.TravelName;
                    break;
                }
            }
            return model;
        }
    }
}
