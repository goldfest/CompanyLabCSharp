using TravelCompanyDataModels.Models;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TravelCompanyFileImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; private set; }
        public string ShopName { get; private set; } = string.Empty;
        public string Adress { get; private set; } = string.Empty;
        public DateTime OpeningDate { get; private set; }
        public Dictionary<int, int> Travels { get; private set; } = new();
        private Dictionary<int, (ITravelModel, int)>? _shopTravels = null;

        public Dictionary<int, (ITravelModel, int)> ShopTravels
        {
            get
            {
                if (_shopTravels == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _shopTravels = Travels.ToDictionary(x => x.Key, y => ((source.Travels.FirstOrDefault(z => z.Id == y.Key) as ITravelModel)!, y.Value));
                }
                return _shopTravels;
            }
        }

        public int TravelMaxCount { get; private set; }

        public static Shop? Create(ShopBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Adress = model.Adress,
                OpeningDate = model.OpeningDate,
                Travels = model.ShopTravels.ToDictionary(x => x.Key, x => x.Value.Item2),
                TravelMaxCount = model.TravelMaxCount
            };
        }

        public static Shop? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ShopName = element.Element("ShopName")!.Value,
                Adress = element.Element("Adress")!.Value,
                OpeningDate = Convert.ToDateTime(element.Element("OpeningDate")!.Value),
                Travels = element.Element("ShopTravels")!.Elements("ShopTravel")!.ToDictionary(x => Convert.ToInt32(x.Element("Key")?.Value),
                x => Convert.ToInt32(x.Element("Value")?.Value)),
                TravelMaxCount = Convert.ToInt32(element.Element("TravelMaxCount")!.Value)
            };
        }

        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Adress = model.Adress;
            OpeningDate = model.OpeningDate;
            TravelMaxCount = model.TravelMaxCount;
            Travels = model.ShopTravels.ToDictionary(x => x.Key, x => x.Value.Item2);
            _shopTravels = null;
        }

        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Adress = Adress,
            OpeningDate = OpeningDate,
            ShopTravels = ShopTravels,
            TravelMaxCount = TravelMaxCount
        };

        public XElement GetXElement => new("Shop",
            new XAttribute("Id", Id),
            new XElement("ShopName", ShopName),
            new XElement("Adress", Adress),
            new XElement("OpeningDate", OpeningDate.ToString()),
            new XElement("ShopTravels", Travels.Select(
                x => new XElement("ShopTravel", new XElement("Key", x.Key), new XElement("Value", x.Value))).ToArray()),
            new XElement("TravelMaxCount", TravelMaxCount.ToString())
            );

        public void TravelsUpdate()
        {
            _shopTravels = null;
        }
    }
}