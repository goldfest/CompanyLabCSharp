using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.ViewModels
{
    public class ShopViewModel : IShopModel
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        public string ShopName { get; set; } = string.Empty;
        [DisplayName("Адрес")]
        public string Adress { get; set; } = string.Empty;
        [DisplayName("Дата открытия")]
        public DateTime OpeningDate { get; set; }
        public Dictionary<int, (ITravelModel, int)> ShopTravels { get; set; } = new();
        [DisplayName("Вместимость")]
        public int TravelMaxCount { get; set; }
    }
}