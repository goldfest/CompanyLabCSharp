using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanyDatabaseImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; set; }
        public string ShopName { get; set; } = string.Empty;

        public string Adress { get; set; } = string.Empty;

        public DateTime OpeningDate { get; set; }

        public int TravelMaxCount { get; set; }

        private Dictionary<int, (ITravelModel, int)>? _shopTravels = null;

        public Dictionary<int, (ITravelModel, int)> ShopTravels
        {
            get
            {
                if (_shopTravels == null)
                {
                    if (_shopTravels == null)
                    {
                        _shopTravels = Travels
                                .ToDictionary(recSP => recSP.TravelId, recSP => (recSP.Travel as ITravelModel, recSP.Count));
                    }
                    return _shopTravels;
                }
                return _shopTravels;
            }
        }

        [ForeignKey("ShopId")]
        public List<ShopTravels> Travels { get; set; } = new();

        public static Shop Create(TravelCompanyDataBase context, ShopBindingModel model)
        {
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Adress = model.Adress,
                OpeningDate = model.OpeningDate,
                Travels = model.ShopTravels.Select(x => new ShopTravels
                {
                    Travel = context.Travels.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList(),
                TravelMaxCount = model.TravelMaxCount
            };
        }

        public void Update(ShopBindingModel model)
        {
            ShopName = model.ShopName;
            Adress = model.Adress;
            OpeningDate = model.OpeningDate;
            TravelMaxCount = model.TravelMaxCount;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Adress = Adress,
            OpeningDate = OpeningDate,
            ShopTravels = ShopTravels,
            TravelMaxCount = TravelMaxCount
        };

        public void UpdateTravels(TravelCompanyDataBase context, ShopBindingModel model)
        {
            if (model.ShopTravels == null)
                return;
            var shopTravels = context.ShopTravels.Where(rec =>
           rec.ShopId == model.Id).ToList();
            if (shopTravels != null && shopTravels.Count > 0)
            {
                context.ShopTravels.RemoveRange(shopTravels.Where(rec
=> !model.ShopTravels.ContainsKey(rec.TravelId)));

                context.SaveChanges();
                foreach (var updateTravel in shopTravels)
                {
                    updateTravel.Count =
                   model.ShopTravels[updateTravel.TravelId].Item2;
                    model.ShopTravels.Remove(updateTravel.TravelId);
                }
                context.SaveChanges();
            }
            var shop = context.Shops.First(x => x.Id == Id);
            foreach (var pc in model.ShopTravels)
            {
                context.ShopTravels.Add(new ShopTravels
                {
                    Shop = shop,
                    Travel = context.Travels.First(x => x.Id == pc.Key),
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            _shopTravels = null;
        }

        public void TravelsDictionatyUpdate(TravelCompanyDataBase context)
        {
            UpdateTravels(context, new ShopBindingModel
            {
                Id = Id,
                ShopTravels = ShopTravels,
            });
        }
    }
}
