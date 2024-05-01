using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;

namespace TravelCompanyDatabaseImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        public List<ImplementerViewModel> GetFullList()
        {
            using var context = new TravelCompanyDataBase();
            return context.Implementers.Select(x => x.GetViewModel).ToList();
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ImplementerFIO))
            {
                return new();
            }
            using var context = new TravelCompanyDataBase();
            return context.Implementers.Where(x => x.ImplementerFIO.Contains(model.ImplementerFIO)).Select(x => x.GetViewModel).ToList();
        }

        public ImplementerViewModel? GetElement(ImplementerSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ImplementerFIO) && !model.Id.HasValue)
            {
                return null;
            }
            using var context = new TravelCompanyDataBase();
            return context.Implementers.FirstOrDefault(x =>
                (!string.IsNullOrEmpty(model.ImplementerFIO) && x.ImplementerFIO == model.ImplementerFIO && (!string.IsNullOrEmpty(model.Password) ? x.Password == model.Password : true)) ||
                (model.Id.HasValue && x.Id == model.Id))
                ?.GetViewModel;
        }

        public ImplementerViewModel? Insert(ImplementerBindingModel model)
        {
            var newImplementer = Implementer.Create(model);
            if (newImplementer == null)
            {
                return null;
            }
            using var context = new TravelCompanyDataBase();
            context.Implementers.Add(newImplementer);
            context.SaveChanges();
            return newImplementer.GetViewModel;
        }

        public ImplementerViewModel? Update(ImplementerBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var implementer = context.Implementers.FirstOrDefault(x => x.Id == model.Id);
            if (implementer == null)
            {
                return null;
            }
            implementer.Update(model);
            context.SaveChanges();
            return implementer.GetViewModel;
        }

        public ImplementerViewModel? Delete(ImplementerBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var implementer = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (implementer != null)
            {
                context.Implementers.Remove(implementer);
                context.SaveChanges();
                return implementer.GetViewModel;
            }
            return null;
        }
    }
}
