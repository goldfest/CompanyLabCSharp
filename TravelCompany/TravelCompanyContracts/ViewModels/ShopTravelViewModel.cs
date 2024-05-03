namespace TravelCompanyContracts.ViewModels
{
    public class ShopTravelViewModel
    {
        public ShopViewModel Shop { get; set; } = new();
        public Dictionary<int, TravelCount> ShopTravel { get; set; } = new();
    }
}
