using TravelCompanyContracts.ViewModels;

namespace TravelCompanyBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelShop : IDocument
    {
        public string FileName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<ReportShopsViewModel> ShopTravels { get; set; } = new();
    }
}
