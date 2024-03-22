using TravelCompanyDataModels.Models;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyListImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; private set; }
        public string ShopName { get; private set; } = string.Empty;
        public string Adress { get; private set; } = string.Empty;
        public DateTime OpeningDate { get; private set; }
        public Dictionary<int, (ITravelModel, int)> ShopTravels { get; private set; } = new();

        public static Shop? Create(ShopBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Adress = model.Adress,
                OpeningDate = model.OpeningDate
            };
        }

        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Adress = model.Adress;
            OpeningDate = model.OpeningDate;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Adress = Adress,
            OpeningDate = OpeningDate,
            ShopTravels = ShopTravels
        };
    }
}