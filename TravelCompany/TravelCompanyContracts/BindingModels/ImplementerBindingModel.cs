using TravelCompanyDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BindingModels
{
	public class ImplementerBindingModel : IImplementerModel
	{
		public int Id { get; set; }
		public string ImplementerFIO { get; set; } = string.Empty;
		public int WorkExperience { get; set; } = 0;
		public int Qualification { get; set; } = 0;
		public string Password { get; set; } = string.Empty;
	}
}
