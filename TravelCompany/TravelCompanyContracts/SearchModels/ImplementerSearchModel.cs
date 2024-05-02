using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.SearchModels
{
	public class ImplementerSearchModel
	{
		public int? Id { get; set; }
		public string? ImplementerFIO { get; set; } = string.Empty;
		public string? Password { get; set; } = string.Empty;
	}
}
