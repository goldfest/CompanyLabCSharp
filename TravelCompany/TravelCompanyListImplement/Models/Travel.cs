using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyListImplement.Models
{
    internal class Travel : ITravelModel
    {
        public int Id { get; private set; }
        public string TravelName { get; private set; } = string.Empty;
        public double Price { get; private set; }
        public Dictionary<int, (IComponentModel, int)> TravelComponents
        {
            get;
            private set;
        } = new Dictionary<int, (IComponentModel, int)>();
        public static Travel? Create(TravelBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Travel()
            {
                Id = model.Id,
                TravelName = model.TravelName,
                Price = model.Price,
                TravelComponents = model.TravelComponents
            };
        }
        public void Update(TravelBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            TravelName = model.TravelName;
            Price = model.Price;
            TravelComponents = model.TravelComponents;
        }
        public TravelViewModel GetViewModel => new()
        {
            Id = Id,
            TravelName = TravelName,
            Price = Price,
            TravelComponents = TravelComponents
        };

    }
}
