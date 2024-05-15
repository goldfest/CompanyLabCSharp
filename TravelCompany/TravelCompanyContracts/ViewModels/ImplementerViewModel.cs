using TravelCompanyDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.Attributes;


namespace TravelCompanyContracts.ViewModels
{
	public class ImplementerViewModel : IImplementerModel
	{
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ImplementerFIO { get; set; } = string.Empty;
        [Column(title: "Стаж работы", width: 60)]
        public int WorkExperience { get; set; } = 0;
        [Column(title: "Квалификация", width: 60)]
        public int Qualification { get; set; } = 0;
        [Column(title: "Пароль", width: 100)]
        public string Password { get; set; } = string.Empty;
	}
}
