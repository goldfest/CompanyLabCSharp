using TravelCompanyDataModels;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyDataModels.Models
{
    public interface IShopModel : IId
    {
        string ShopName { get; }
        string Adress { get; }
        DateTime OpeningDate { get; }
        Dictionary<int, (ITravelModel, int)> ShopTravels { get; }
        public int TravelMaxCount { get; }
    }
}