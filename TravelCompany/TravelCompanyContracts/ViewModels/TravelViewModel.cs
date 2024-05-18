using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.Attributes;


namespace TravelCompanyContracts.ViewModels
{
    public class TravelViewModel : ITravelModel
    {
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string TravelName { get; set; }
        [Column(title: "Цена", width: 70)]
        public double Price { get; set; }
        [Column(visible: false)]
        public Dictionary<int, (IComponentModel, int)> TravelComponents { get; set; } = new();

    }
}
