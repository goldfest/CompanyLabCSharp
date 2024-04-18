using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelCompanyDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using var context = new TravelCompanyDataBase();
            return context.Orders.Include(x => x.Travel).Select(x => x.GetViewModel).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (!model.Id.HasValue || !model.DateFrom.HasValue || !model.DateTo.HasValue)
            {
                return new();
            }
            using var context = new TravelCompanyDataBase();
            if (model.DateFrom.HasValue)
            {
                return context.Orders.Include(x => x.Travel).Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo).Select(x => x.GetViewModel).ToList();
            }
            return context.Orders.Include(x => x.Travel).Where(x => x.Id == model.Id).Select(x => x.GetViewModel).ToList();
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return new();
            }
            using var context = new TravelCompanyDataBase();
            return context.Orders.Include(x => x.Travel).FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            if (model == null)
                return null;
            var newOrder = Order.Create(context, model);
            if (newOrder == null)
            {
                return null;
            }
            context.Orders.Add(newOrder);
            context.SaveChanges();
            return newOrder.GetViewModel;
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var order = context.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            context.SaveChanges();
            return order.GetViewModel;
        }

        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
                return order.GetViewModel;
            }
            return null;
        }
    }
}
