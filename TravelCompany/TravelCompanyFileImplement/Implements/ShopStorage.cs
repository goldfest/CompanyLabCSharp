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
    public class ShopStorage : IShopStorage
    {
        private readonly DataFileSingleton source;

        public ShopStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public List<ShopViewModel> GetFullList()
        {
            return source.Shops.Select(x => x.GetViewModel).ToList();
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }
            return source.Shops.Where(x => x.ShopName.Contains(model.ShopName)).Select(x => x.GetViewModel).ToList();
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }
            return source.Shops.FirstOrDefault(x =>
            (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) ||
            (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            model.Id = source.Shops.Count > 0 ? source.Shops.Max(x => x.Id) + 1 : 1;
            var newShop = Shop.Create(model);
            if (newShop == null)
            {
                return null;
            }
            source.Shops.Add(newShop);
            source.SaveShops();
            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            var shop = source.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (shop == null)
            {
                return null;
            }
            shop.Update(model);
            source.SaveShops();
            return shop.GetViewModel;
        }

        public ShopViewModel? Delete(ShopBindingModel model)
        {
            var shop = source.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (shop != null)
            {
                source.Shops.Remove(shop);
                source.SaveShops();
                return shop.GetViewModel;
            }
            return null;
        }

        public bool Sale(SupplySearchModel model)
        {
            if (model == null || !model.TravelId.HasValue || !model.Count.HasValue)
                return false;
            int remainingSpace = source.Shops.Select(x => x.Travels.ContainsKey(model.TravelId.Value) ? x.Travels[model.TravelId.Value] : 0).Sum();
            if (remainingSpace < model.Count)
            {
                return false;
            }
            var shops = source.Shops.Where(x => x.Travels.ContainsKey(model.TravelId.Value)).OrderByDescending(x => x.Travels[model.TravelId.Value]).ToList();
            foreach (var shop in shops)
            {
                int residue = model.Count.Value - shop.Travels[model.TravelId.Value];
                if (residue > 0)
                {
                    shop.Travels.Remove(model.TravelId.Value);
                    shop.TravelsUpdate();
                    model.Count = residue;
                }
                else
                {
                    if (residue == 0)
                    {
                        shop.Travels.Remove(model.TravelId.Value);
                    }
                    else
                    {
                        shop.Travels[model.TravelId.Value] = -residue;
                    }
                    shop.TravelsUpdate();
                    source.SaveShops();
                    return true;
                }
            }
            source.SaveShops();
            return false;
        }

        public bool RestockingShops(SupplyBindingModel model)
        {
            if (model == null || source.Shops.Select(x => x.TravelMaxCount - x.ShopTravels.Select(y => y.Value.Item2).Sum()).Sum() < model.Count)
            {
                return false;
            }
            foreach (Shop shop in source.Shops)
            {
                int free_places = shop.TravelMaxCount - shop.ShopTravels.Select(x => x.Value.Item2).Sum();
                if (free_places <= 0)
                    continue;
                free_places = Math.Min(free_places, model.Count);
                model.Count -= free_places;
                if (shop.Travels.ContainsKey(model.TravelId))
                {
                    shop.Travels[model.TravelId] += free_places;
                }
                else
                {
                    shop.Travels.Add(model.TravelId, free_places);
                }
                shop.TravelsUpdate();
                if (model.Count == 0)
                {
                    source.SaveShops();
                    return true;
                }
            }
            return false;
        }
    }
}