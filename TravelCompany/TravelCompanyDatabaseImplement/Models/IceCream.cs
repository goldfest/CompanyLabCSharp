using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyDatabaseImplement.Models
{
    public class Travel : ITravelModel
    {
        public int Id { get; set; }
        [Required]
        public string TravelName { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        private Dictionary<int, (IComponentModel, int)>? _TravelComponents =
       null;
        [NotMapped]
        public Dictionary<int, (IComponentModel, int)> TravelComponents
        {
            get
            {
                if (_TravelComponents == null)
                {
                    _TravelComponents = Components
                    .ToDictionary(recPC => recPC.ComponentId, recPC =>
                   (recPC.Component as IComponentModel, recPC.Count));
                }
                return _TravelComponents;
            }
        }
        [ForeignKey("TravelId")]
        public virtual List<TravelComponent> Components { get; set; } = new();
        [ForeignKey("TravelId")]
        public virtual List<Order> Orders { get; set; } = new();
        public static Travel Create(TravelCompanyDataBase context,
       TravelBindingModel model)
        {
            return new Travel()
            {
                Id = model.Id,
                TravelName = model.TravelName,
                Price = model.Price,
                Components = model.TravelComponents.Select(x => new
               TravelComponent
                {
                    Component = context.Components.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList()
            };
        }
        public void Update(TravelBindingModel model)
        {
            TravelName = model.TravelName;
            Price = model.Price;
        }
        public TravelViewModel GetViewModel => new()
        {
            Id = Id,
            TravelName = TravelName,
            Price = Price,
            TravelComponents = TravelComponents
        };
        public void UpdateComponents(TravelCompanyDataBase context,
       TravelBindingModel model)
        {
            var TravelComponents = context.TravelComponents.Where(rec =>
           rec.TravelId == model.Id).ToList();
            if (TravelComponents != null && TravelComponents.Count > 0)
            {
                context.TravelComponents.RemoveRange(TravelComponents.Where(rec
=> !model.TravelComponents.ContainsKey(rec.ComponentId)));

                context.SaveChanges();
                foreach (var updateComponent in TravelComponents)
                {
                    updateComponent.Count =
                   model.TravelComponents[updateComponent.ComponentId].Item2;
                    model.TravelComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            var Travel = context.Travels.First(x => x.Id == Id);
            foreach (var pc in model.TravelComponents)
            {
                context.TravelComponents.Add(new TravelComponent
                {
                    Travel = Travel,
                    Component = context.Components.First(x => x.Id == pc.Key),
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            _TravelComponents = null;
        }
    }
}

