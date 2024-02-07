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
    public class TravelStorage : ITravelStorage
    {
        private readonly DataListSingleton _source;
        public TravelStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public TravelViewModel? Delete(TravelBindingModel model)
        {
            for (int i = 0; i < _source.Travels.Count; ++i)
            {
                if (_source.Travels[i].Id == model.Id)
                {
                    var element = _source.Travels[i];
                    _source.Travels.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }

        public TravelViewModel? GetElement(TravelSearchModel model)
        {
            if (string.IsNullOrEmpty(model.TravelName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var Travel in _source.Travels)
            {
                if ((!string.IsNullOrEmpty(model.TravelName) && Travel.TravelName == model.TravelName) ||
                (model.Id.HasValue && Travel.Id == model.Id))
                {
                    return Travel.GetViewModel;
                }
            }
            return null;
        }

        public List<TravelViewModel> GetFilteredList(TravelSearchModel model)
        {
            var result = new List<TravelViewModel>();
            if (string.IsNullOrEmpty(model.TravelName))
            {
                return result;
            }
            foreach (var Travel in _source.Travels)
            {
                if (Travel.TravelName.Contains(model.TravelName))
                {
                    result.Add(Travel.GetViewModel);
                }
            }
            return result;
        }

        public List<TravelViewModel> GetFullList()
        {
            var result = new List<TravelViewModel>();
            foreach (var Travel in _source.Travels)
            {
                result.Add(Travel.GetViewModel);
            }
            return result;
        }

        public TravelViewModel? Insert(TravelBindingModel model)
        {
            model.Id = 1;
            foreach (var Travel in _source.Travels)
            {
                if (model.Id <= Travel.Id)
                {
                    model.Id = Travel.Id + 1;
                }
            }
            var newTravel = Travel.Create(model);
            if (newTravel == null)
            {
                return null;
            }
            _source.Travels.Add(newTravel);
            return newTravel.GetViewModel;
        }

        public TravelViewModel? Update(TravelBindingModel model)
        {
            foreach (var Travel in _source.Travels)
            {
                if (Travel.Id == model.Id)
                {
                    Travel.Update(model);
                    return Travel.GetViewModel;
                }
            }
            return null;
        }
    }
}
