using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TravelCompanyDatabaseImplement.Models
{
    [DataContract]
    public class Component : IComponentModel
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        [Required]
        public string ComponentName { get; private set; } = string.Empty;

        [DataMember]
        [Required]
        public double Cost { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<TravelComponent> TravelComponents { get; set; } =
       new();
        public static Component? Create(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Component()
            {
                Id = model.Id,
                ComponentName = model.ComponentName,
                Cost = model.Cost
            };
        }
        public static Component Create(ComponentViewModel model)
        {
            return new Component
            {
                Id = model.Id,
                ComponentName = model.ComponentName,
                Cost = model.Cost
            };
        }
        public void Update(ComponentBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            ComponentName = model.ComponentName;
            Cost = model.Cost;
        }
        public ComponentViewModel GetViewModel => new()
        {
            Id = Id,
            ComponentName = ComponentName,
            Cost = Cost
        };
    }
}

