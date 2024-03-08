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
    public class TravelStorage : ITravelStorage
    {
        public List<TravelViewModel> GetFullList()
        {
            using var context = new TravelCompanyDataBase();
            return context.Travels
             .Include(x => x.Components)
            .ThenInclude(x => x.Component)
            .ToList()
            .Select(x => x.GetViewModel)
            .ToList();
        }
        public List<TravelViewModel> GetFilteredList(TravelSearchModel model)
        {
            if (string.IsNullOrEmpty(model.TravelName))
            {
                return new();
            }
            using var context = new TravelCompanyDataBase();
            return context.Travels.Include(x => x.Components)
            .ThenInclude(x => x.Component)
            .Where(x => x.TravelName.Contains(model.TravelName))
            .ToList()
            .Select(x => x.GetViewModel)
            .ToList();
        }
        public TravelViewModel? GetElement(TravelSearchModel model)
        {
            if (string.IsNullOrEmpty(model.TravelName) &&
            !model.Id.HasValue)
            {
                return null;
            }
            using var context = new TravelCompanyDataBase();
            return context.Travels
             .Include(x => x.Components)
             .ThenInclude(x => x.Component)
             .FirstOrDefault(x => (!string.IsNullOrEmpty(model.TravelName) &&
            x.TravelName == model.TravelName) ||
            (model.Id.HasValue && x.Id ==
            model.Id))
            ?.GetViewModel;
        }
        public TravelViewModel? Insert(TravelBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var newTravel = Travel.Create(context, model);
            if (newTravel == null)
            {
                return null;
            }
            context.Travels.Add(newTravel);
            context.SaveChanges();
            return newTravel.GetViewModel;
        }
        public TravelViewModel? Update(TravelBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var Travel = context.Travels.FirstOrDefault(rec =>
                rec.Id == model.Id);
                if (Travel == null)
                {
                    return null;
                }
                Travel.Update(model);
                context.SaveChanges();
                Travel.UpdateComponents(context, model);
                transaction.Commit();
                return Travel.GetViewModel;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public TravelViewModel? Delete(TravelBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var element = context.Travels
            .Include(x => x.Components)
            .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Travels.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}

