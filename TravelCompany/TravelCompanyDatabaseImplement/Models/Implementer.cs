using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyDatabaseImplement.Models
{
	public class Implementer : IImplementerModel
	{
		public int Id { get; private set; }
		[Required]
		public string ImplementerFIO { get; private set; } = string.Empty;
		[Required]
		public string Password { get; set; } = string.Empty;
		[Required]
		public int Qualification { get; set; } = 0;
		[Required]
		public int WorkExperience { get; set; } = 0;
		[ForeignKey("ImplementerId")]
		public virtual List<Order> Orders { get; set; } =
	   new();
		public static Implementer? Create(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				Id = model.Id,
				Password = model.Password,
				Qualification = model.Qualification,
				ImplementerFIO = model.ImplementerFIO,
				WorkExperience = model.WorkExperience,
			};
		}

		public void Update(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			Password = model.Password;
			Qualification = model.Qualification;
			ImplementerFIO = model.ImplementerFIO;
			WorkExperience = model.WorkExperience;
		}

		public ImplementerViewModel GetViewModel => new()
		{
			Id = Id,
			Password = Password,
			Qualification = Qualification,
			ImplementerFIO = ImplementerFIO,
			WorkExperience = WorkExperience,
		};
	}
}
