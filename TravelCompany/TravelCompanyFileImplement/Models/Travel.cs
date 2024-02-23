using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TravelCompanyFileImplement.Models
{
    public class Travel : ITravelModel
    {
        public int Id { get; private set; }
        public string TravelName { get; private set; } = string.Empty;
        public double Price { get; private set; }
        public Dictionary<int, int> Components { get; private set; } = new();
        private Dictionary<int, (IComponentModel, int)>? _TravelComponents = null;
        public Dictionary<int, (IComponentModel, int)> TravelComponents
        {
            get
            {
                if (_TravelComponents == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _TravelComponents = Components.ToDictionary(x => x.Key, y =>
                    ((source.Components.FirstOrDefault(z => z.Id == y.Key) as IComponentModel)!,
                    y.Value));
                }
                return _TravelComponents;
            }
        }
        public static Travel? Create(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Travel()
            {
                Id = model.Id,
                TravelName = model.TravelName,
                Price = model.Price,
                Components = model.TravelComponents.ToDictionary(x => x.Key, x
               => x.Value.Item2)
            };
        }
        public static Travel? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Travel()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                TravelName = element.Element("TravelName")!.Value,
                Price = Convert.ToDouble(element.Element("Price")!.Value),
                Components =
           element.Element("TravelComponents")!.Elements("TravelComponent")
            .ToDictionary(x =>
           Convert.ToInt32(x.Element("Key")?.Value), x =>
           Convert.ToInt32(x.Element("Value")?.Value))
            };
        }
        public void Update(TravelBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            TravelName = model.TravelName;
            Price = model.Price;
            Components = model.TravelComponents.ToDictionary(x => x.Key, x =>
           x.Value.Item2);
            _TravelComponents = null;
        }
        public TravelViewModel GetViewModel => new()
        {
            Id = Id,
            TravelName = TravelName,
            Price = Price,
            TravelComponents = TravelComponents
        };
        public XElement GetXElement => new("Travel",
            new XAttribute("Id", Id),
            new XElement("TravelName", TravelName),
            new XElement("Price", Price.ToString()),
            new XElement("TravelComponents", Components.Select(x => new XElement("TravelComponent", new XElement("Key", x.Key), new XElement("Value", x.Value)))

       .ToArray()));

    }
}
