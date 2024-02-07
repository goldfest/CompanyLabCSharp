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
                result.Add(AttachTravelName(order.GetViewModel));
            }
            return result;
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            var result = new List<OrderViewModel>();
            if (model == null || !model.Id.HasValue)
            {
                return result;
            }
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    result.Add(AttachTravelName(order.GetViewModel));
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
                if (model.Id.HasValue && order.Id == model.Id)
                {
                    return AttachTravelName(order.GetViewModel);
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
            return AttachTravelName(newOrder.GetViewModel);
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            foreach (var order in _source.Orders)
            {
                if (order.Id == model.Id)
                {
                    order.Update(model);
                    return AttachTravelName(order.GetViewModel);
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
                    return AttachTravelName(element.GetViewModel);
                }
            }
            return null;
        }

        private OrderViewModel AttachTravelName(OrderViewModel model)
        {
            foreach (var Travel in _source.Travels)
            {
                if (Travel.Id == model.TravelId)
                {
                    model.TravelName = Travel.TravelName;
                    return model;
                }
            }
            return model;
        }
    }
}
