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
    public class TravelStorage : ITravelStorage
    {
        private readonly DataFileSingleton source;

        public TravelStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public TravelViewModel? GetElement(TravelSearchModel model)
        {
            if (string.IsNullOrEmpty(model.TravelName) && !model.Id.HasValue)
            {
                return null;
            }
            return source.Travels.FirstOrDefault(x => (!string.IsNullOrEmpty(model.TravelName) && x.TravelName == model.TravelName) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public List<TravelViewModel> GetFilteredList(TravelSearchModel model)
        {
            if (string.IsNullOrEmpty(model.TravelName))
            {
                return new();
            }
            return source.Travels.Where(x => x.TravelName.Contains(model.TravelName)).Select(x => x.GetViewModel).ToList();
        }

        public List<TravelViewModel> GetFullList()
        {
            return source.Travels.Select(x => x.GetViewModel).ToList();
        }

        public TravelViewModel? Insert(TravelBindingModel model)
        {
            model.Id = source.Travels.Count > 0 ? source.Travels.Max(x => x.Id) + 1 : 1;
            var newDoc = Travel.Create(model);
            if (newDoc == null)
            {
                return null;
            }
            source.Travels.Add(newDoc);
            source.SaveTravels();
            return newDoc.GetViewModel;
        }

        public TravelViewModel? Update(TravelBindingModel model)
        {
            var document = source.Travels.FirstOrDefault(x => x.Id == model.Id);
            if (document == null)
            {
                return null;
            }
            document.Update(model);
            source.SaveTravels();
            return document.GetViewModel;
        }
        public TravelViewModel? Delete(TravelBindingModel model)
        {
            var document = source.Travels.FirstOrDefault(x => x.Id == model.Id);
            if (document == null)
            {
                return null;
            }
            document.Update(model);
            source.SaveTravels();
            return document.GetViewModel;
        }
    }
}
