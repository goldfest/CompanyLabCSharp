using Microsoft.EntityFrameworkCore;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;

namespace TravelCompanyDatabaseImplement.Implements
{
    public class ShopStorage : IShopStorage
    {
        public List<ShopViewModel> GetFullList()
        {
            using var context = new TravelCompanyDataBase();
            return context.Shops.Include(x => x.Travels).ThenInclude(x => x.Travel).ToList().
                Select(x => x.GetViewModel).ToList();
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }
            using var context = new TravelCompanyDataBase();
            return context.Shops.Include(x => x.Travels).ThenInclude(x => x.Travel).Where(x => x.ShopName.Contains(model.ShopName)).
                ToList().Select(x => x.GetViewModel).ToList();
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return new();
            }
            using var context = new TravelCompanyDataBase();
            return context.Shops.Include(x => x.Travels).ThenInclude(x => x.Travel)
                .FirstOrDefault(x =>
                (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) ||
                (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var newShop = Shop.Create(context, model);
            if (newShop == null)
            {
                return null;
            }
            context.Shops.Add(newShop);
            context.SaveChanges();
            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var shop = context.Shops.FirstOrDefault(x => x.Id == model.Id);
                if (shop == null)
                {
                    return null;
                }
                shop.Update(model);
                context.SaveChanges();
                shop.UpdateTravels(context, model);
                transaction.Commit();
                return shop.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public ShopViewModel? Delete(ShopBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var shop = context.Shops.Include(x => x.Travels).FirstOrDefault(x => x.Id == model.Id);
            if (shop != null)
            {
                context.Shops.Remove(shop);
                context.SaveChanges();
                return shop.GetViewModel;
            }
            return null;
        }

        public bool RestockingShops(SupplyBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var transaction = context.Database.BeginTransaction();
            var Shops = context.Shops.Include(x => x.Travels).ThenInclude(x => x.Travel).ToList().
                Where(x => x.TravelMaxCount > x.ShopTravels.Select(x => x.Value.Item2).Sum()).ToList();
            if (model == null)
            {
                return false;
            }
            try
            {
                foreach (Shop shop in Shops)
                {
                    int difference = shop.TravelMaxCount - shop.ShopTravels.Select(x => x.Value.Item2).Sum();
                    int refill = Math.Min(difference, model.Count);
                    model.Count -= refill;
                    if (shop.ShopTravels.ContainsKey(model.TravelId))
                    {
                        var datePair = shop.ShopTravels[model.TravelId];
                        datePair.Item2 += refill;
                        shop.ShopTravels[model.TravelId] = datePair;
                    }
                    else
                    {
                        var Travel = context.Travels.First(x => x.Id == model.TravelId);
                        shop.ShopTravels.Add(model.TravelId, (Travel, refill));
                    }
                    shop.TravelsDictionatyUpdate(context);
                    if (model.Count == 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                }
                transaction.Rollback();
                return false;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool Sale(SupplySearchModel model)
        {
            using var context = new TravelCompanyDataBase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var shops = context.Shops.Include(x => x.Travels).ThenInclude(x => x.Travel).ToList().
                    Where(x => x.ShopTravels.ContainsKey(model.TravelId.Value)).OrderByDescending(x => x.ShopTravels[model.TravelId.Value].Item2).ToList();

                foreach (var shop in shops)
                {
                    int residue = model.Count.Value - shop.ShopTravels[model.TravelId.Value].Item2;
                    if (residue > 0)
                    {
                        shop.ShopTravels.Remove(model.TravelId.Value);
                        shop.TravelsDictionatyUpdate(context);
                        context.SaveChanges();
                        model.Count = residue;

                    }
                    else
                    {
                        if (residue == 0)
                            shop.ShopTravels.Remove(model.TravelId.Value);
                        else
                        {
                            var dataPair = shop.ShopTravels[model.TravelId.Value];
                            dataPair.Item2 = -residue;
                            shop.ShopTravels[model.TravelId.Value] = dataPair;
                        }

                        shop.TravelsDictionatyUpdate(context);
                        transaction.Commit();
                        return true;
                    }
                }
                transaction.Rollback();
                return false;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

    }
}
