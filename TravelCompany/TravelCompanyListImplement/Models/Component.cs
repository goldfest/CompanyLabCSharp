using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Models;

namespace TravelCompanyListImplement.Models
{
    public class Component : IComponentModel
    {
        public int Id { get; private set; }
        public string ComponentName { get; private set; } = string.Empty;
        public double Cost { get; set; }
        public static Component? Create(ComponentBindingModel? model)
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
        public void Update(ComponentBindingModel? model)
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