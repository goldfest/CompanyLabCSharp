using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.ViewModels
{
    public class ReportTravelComponentViewModel
    {
        public string ComponentName { get; set; } = string.Empty;
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Travels { get; set; } = new();

    }
}
