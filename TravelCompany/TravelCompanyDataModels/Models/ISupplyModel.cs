using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyDataModels.Models
{
    public interface ISupplyModel
    {
        int ShopId { get; }
        int TravelId { get; }
        int Count { get; }
    }
}