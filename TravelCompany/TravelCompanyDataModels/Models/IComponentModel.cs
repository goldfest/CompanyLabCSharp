namespace TravelCompanyDataModels.Models
{
    public interface IComponentModel : IId
    {
        string ComponentName { get; }
        double Cost { get; }
    }
}