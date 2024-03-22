using TravelCompanyBusinessLogic.OfficePackage.HelperModels;
using TravelCompanyBusinessLogic.OfficePackage;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly ITravelStorage _productStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(ITravelStorage productStorage, IComponentStorage
       componentStorage, IOrderStorage orderStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord,
       AbstractSaveToPdf saveToPdf)
        {
            _productStorage = productStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }
        public List<ReportTravelComponentViewModel> GetTravelComponent()
        {
            var components = _componentStorage.GetFullList();
            var products = _productStorage.GetFullList();
            var list = new List<ReportTravelComponentViewModel>();
            foreach (var component in components)
            {
                var record = new ReportTravelComponentViewModel
                {
                    ComponentName = component.ComponentName,
                    Travels = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var travel in products)
                {
                    if (travel.TravelComponents.ContainsKey(component.Id))
                    {
                        record.Travels.Add(new Tuple<string,
                       int>(travel.TravelName, travel.TravelComponents[component.Id].Item2));
                        record.TotalCount +=
                       travel.TravelComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderSearchModel
            {
                DateFrom
           = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                Id = x.Id,
                DateCreate = x.DateCreate,
                TravelName = x.TravelName,
                Sum = x.Sum
            })
           .ToList();
        }
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Components = _componentStorage.GetFullList()
            });
        }
        public void SaveTravelComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                TravelComponents = GetTravelComponent()
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
    }
}
