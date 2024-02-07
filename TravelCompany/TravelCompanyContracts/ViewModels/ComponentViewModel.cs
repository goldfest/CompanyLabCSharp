using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.ViewModels
{
    public class ComponentViewModel : IComponentModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; } = string.Empty;
        [DisplayName("Цена")]
        public double Cost { get; set; }
    }
}
