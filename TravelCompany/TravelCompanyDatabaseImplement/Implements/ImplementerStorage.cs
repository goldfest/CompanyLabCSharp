using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyDatabaseImplement.Implements
{
	public class ImplementerStorage : IImplementerStorage
	{
		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			using var context = new TravelCompanyDataBase();
			var res = context.Implementers.FirstOrDefault(x => x.Id == model.Id);
			if (res != null)
			{
				context.Implementers.Remove(res);
				context.SaveChanges();
			}
			return res?.GetViewModel;
		}

		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ImplementerFIO) && string.IsNullOrEmpty(model.Password) &&
			   !model.Id.HasValue)
			{
				return null;
			}
			using var context = new TravelCompanyDataBase();
			return context.Implementers
			.FirstOrDefault(x => (string.IsNullOrEmpty(model.ImplementerFIO) || x.ImplementerFIO == model.ImplementerFIO) &&
								 (!model.Id.HasValue || x.Id == model.Id) &&
								 (string.IsNullOrEmpty(model.Password) || x.Password == model.Password))
			?.GetViewModel;
		}

		public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
		{
			if (model == null)
			{
				return new();
			}
			if (model.Id.HasValue)
			{
				var res = GetElement(model);
				return res != null ? new() { res } : new();
			}
			return new();
		}

		public List<ImplementerViewModel> GetFullList()
		{
			using var context = new TravelCompanyDataBase();
			return context.Implementers.Select(x => x.GetViewModel).ToList();
		}

		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			using var context = new TravelCompanyDataBase();
			var res = Implementer.Create(model);
			if (res != null)
			{
				context.Implementers.Add(res);
				context.SaveChanges();
			}
			return res?.GetViewModel;
		}

		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			using var context = new TravelCompanyDataBase();
			var res = context.Implementers.FirstOrDefault(x => x.Id == model.Id);
			if (res != null)
			{
				res.Update(model);
				context.SaveChanges();
			}
			return res?.GetViewModel;
		}
	}
}
