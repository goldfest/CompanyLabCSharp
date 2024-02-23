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

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            return GetViewModel(source.Orders.FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id));
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return new();
            }
            return source.Orders.Where(x => x.Id == model.Id).Select(x => GetViewModel(x)).ToList();
        }

        public List<OrderViewModel> GetFullList()
        {
            return source.Orders.Select(x => GetViewModel(x)).ToList();
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
            return GetViewModel(newOrder);
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
            return GetViewModel(order);
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            source.SaveOrders();
            return GetViewModel(order);
        }

        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;
            foreach (var comp in source.Travels)
            {
                if (comp.Id == order.TravelId)
                {
                    viewModel.TravelName = comp.TravelName;
                    break;
                }
            }
            return viewModel;
        }
    }
}
