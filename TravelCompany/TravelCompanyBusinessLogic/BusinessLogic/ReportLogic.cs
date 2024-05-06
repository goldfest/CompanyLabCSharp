using TravelCompanyBusinessLogic.OfficePackage.HelperModels;
using TravelCompanyBusinessLogic.OfficePackage;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyBusinessLogic.BusinessLogic
{
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly ITravelStorage _TravelStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IShopStorage _shopStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(ITravelStorage TravelStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, IShopStorage shopStorage,
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _TravelStorage = TravelStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _shopStorage = shopStorage;

            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        public List<ReportTravelComponentViewModel> GetTravelComponents()
        {
            return _TravelStorage.GetFullList().Select(x => new ReportTravelComponentViewModel
            {
                TravelName = x.TravelName,
                Components = x.TravelComponents.Select(x => (x.Value.Item1.ComponentName, x.Value.Item2)).ToList(),
                TotalCount = x.TravelComponents.Select(x => x.Value.Item2).Sum()
            }).ToList();
        }

        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderSearchModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
                    .Select(x => new ReportOrdersViewModel
                    {
                        Id = x.Id,
                        DateCreate = x.DateCreate,
                        TravelName = x.TravelName,
                        Sum = x.Sum,
                        OrderStatus = x.Status.ToString()
                    })
                    .ToList();
        }

        public void SaveTravelsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateTravelDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список путевок",
                Travels = _TravelStorage.GetFullList()
            });
        }

        public void SaveTravelComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список путевок",
                TravelComponents = GetTravelComponents()
            });
        }

        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom!.Value,
                DateTo = model.DateTo!.Value,
                Orders = GetOrders(model)
            });
        }

        public List<ReportShopsViewModel> GetShops()
        {
            return _shopStorage.GetFullList().Select(x => new ReportShopsViewModel
            {
                ShopName = x.ShopName,
                Travels = x.ShopTravels.Select(x => (x.Value.Item1.TravelName, x.Value.Item2)).ToList(),
                TotalCount = x.ShopTravels.Select(x => x.Value.Item2).Sum()
            }).ToList();
        }

        public List<ReportGroupOrdersViewModel> GetGroupedOrders()
        {
            return _orderStorage.GetFullList().GroupBy(x => x.DateCreate.Date).Select(x => new ReportGroupOrdersViewModel
            {
                Date = x.Key,
                OrdersCount = x.Count(),
                OrdersSum = x.Select(y => y.Sum).Sum()
            }).ToList();
        }

        public void SaveShopsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateShopsDoc(new WordShopInfo
            {
                FileName = model.FileName,
                Title = "Список магазинов",
                Shops = _shopStorage.GetFullList()
            });
        }

        public void SaveShopsToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateShopTravelsReport(new ExcelShop
            {
                FileName = model.FileName,
                Title = "Наполненость магазинов",
                ShopTravels = GetShops()
            });
        }

        public void SaveGroupedOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateGroupedOrdersDoc(new PdfGroupedOrdersInfo
            {
                FileName = model.FileName,
                Title = "Список заказов сгруппированных по дате заказов",
                GroupedOrders = GetGroupedOrders()
            });
        }
    }
}
