namespace TravelCompanyDataModels.Models
{
	public interface ITravelModel : IId
	{
		string TravelName { get; }
		double Price { get; }
		Dictionary<int, (IComponentModel, int)> TravelComponents { get; }
	}
}