using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
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
            return context.Orders.Include(x => x.Travel)
            .Include(x => x.Client).Select(x => x.GetViewModel)
           .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {

            using var context = new TravelCompanyDataBase();
            return context.Orders
            .Include(x => x.Travel)
                .Include(x => x.Client).Where(x => (
                        (!model.Id.HasValue || x.Id == model.Id) &&
                        (!model.DateFrom.HasValue || x.DateCreate >= model.DateFrom) &&
                        (!model.DateTo.HasValue || x.DateCreate <= model.DateTo)
                        &&
                        (!model.ClientId.HasValue || x.ClientId == model.ClientId)
                    )
                )
           .Select(x => x.GetViewModel)
           .ToList();
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            using var context = new TravelCompanyDataBase();
            return context.Orders.Include(x => x.Travel).Include(x => x.Client).FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
        }
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
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
            var order = context.Orders.Include(x => x.Travel).Include(x => x.Client).FirstOrDefault(x => x.Id ==
           model.Id);
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
            var element = context.Orders.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
