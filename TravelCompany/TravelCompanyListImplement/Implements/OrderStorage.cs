using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton _source;
        public OrderStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();
            foreach (var order in _source.Orders)
            {
                result.Add(AccessStorage(order.GetViewModel));
            }
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel
       model)
        {
            var result = new List<OrderViewModel>();
            foreach (var order in _source.Orders)
            {
                if ((!model.Id.HasValue || order.Id == model.Id) &&
                        (!model.DateFrom.HasValue || order.DateCreate >= model.DateFrom) &&
                        (!model.DateTo.HasValue || order.DateCreate <= model.DateTo) &&
                        (!model.ClientId.HasValue || order.ClientId == model.ClientId)) ;
                {
                    result.Add(AccessStorage(order.GetViewModel));
                }
            }
            return result;
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            foreach (var order in _source.Orders)
            {
                if ((model.Id.HasValue && order.Id == model.Id) ||
                (model.ImplementerId.HasValue && model.Status.HasValue &&
                order.ImplementerId == model.ImplementerId && order.Status == model.Status))
                {
                    return AccessStorage(order.GetViewModel);
                }
            }
            return null;
        }
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = 1;
            foreach (var order in _source.Orders)
            {
                if (model.Id <= order.Id)
                {
                    model.Id = order.Id + 1;
                }
            }
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            _source.Orders.Add(newOrder);
            return newOrder.GetViewModel;
        }
        public OrderViewModel? Update(OrderBindingModel model)
        {
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    order.Update(model);
                    return order.GetViewModel;
                }
            }
            return null;
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            for (int i = 0; i < _source.Orders.Count; ++i)
            {
                if (_source.Orders[i].Id == model.Id)
                {
                    var element = _source.Orders[i];
                    _source.Orders.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }

        public OrderViewModel AccessStorage(OrderViewModel model)
        {
            if (model == null)
                return null;
            var travel = _source.Travels.FirstOrDefault(x => x.Id == model.Id);
            var client = _source.Clients.FirstOrDefault(x => x.Id == model.Id);
            var implementer = _source.Implementers.FirstOrDefault(x => x.Id == model.ImplementerId);
            if (travel != null)
                model.TravelName = travel.TravelName;
            if (client != null)
                model.ClientFIO = client.ClientFIO;
            if (implementer != null)
                model.ImplementerFIO = implementer.ImplementerFIO;
            return model;
        }

    }

}
