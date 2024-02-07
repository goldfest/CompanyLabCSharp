using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.ViewModels
{
    public class TravelViewModel : ITravelModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string TravelName { get; set; }
        [DisplayName("Цена")]
        public double Price { get; set; }
        public Dictionary<int, (IComponentModel, int)> TravelComponents { get; set; } = new();

    }
}
