using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyListImplement.Models
{
	public class Implementer : IImplementerModel
	{
		public int Id { get; private set; }
		public string ImplementerFIO { get; private set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public int WorkExperience { get; set; } = 0;
		public int Qualification { get; set; } = 0;
		public static Implementer? Create(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Implementer()
			{
				Id = model.Id,
				ImplementerFIO = model.ImplementerFIO,
				Password = model.Password,
				WorkExperience = model.WorkExperience, 
				Qualification = model.Qualification
			};
		}
		public void Update(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			ImplementerFIO = model.ImplementerFIO;
			Password = model.Password;
			WorkExperience = model.WorkExperience;
			Qualification = model.Qualification;
		}
		public ImplementerViewModel GetViewModel => new()
		{
			Id = Id,
			ImplementerFIO = ImplementerFIO,
			Password = Password,
			WorkExperience = WorkExperience,
			Qualification = Qualification
		};
	}
}
