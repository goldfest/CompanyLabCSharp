using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BindingModels
{
    public class TravelBindingModel : ITravelModel
    {
        public int Id { get; set; }
        public string TravelName { get; set; } = string.Empty;
        public double Price { get; set; }
        public Dictionary<int, (IComponentModel, int)> TravelComponents { get; set; } = new();
    }
}
