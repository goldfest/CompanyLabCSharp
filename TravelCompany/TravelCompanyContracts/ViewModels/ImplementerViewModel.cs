using TravelCompanyDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.ViewModels
{
	public class ImplementerViewModel : IImplementerModel
	{
		public int Id { get; set; }
		[DisplayName("ФИО исполнителя")]
		public string ImplementerFIO { get; set; } = string.Empty;
		[DisplayName("Стаж работы")]
		public int WorkExperience { get; set; } = 0;
		[DisplayName("Квалификация")]
		public int Qualification { get; set; } = 0;
		[DisplayName("Пароль")]
		public string Password { get; set; } = string.Empty;
	}
}
