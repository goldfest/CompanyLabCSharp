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

namespace TravelCompanyBusinessLogic.BusinessLogic
{
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly ITravelStorage _TravelStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(ITravelStorage TravelStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _TravelStorage = TravelStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        public List<ReportTravelComponentViewModel> GetTravelComponents()
        {
            var components = _componentStorage.GetFullList();
            var Travels = _TravelStorage.GetFullList();
            var list = new List<ReportTravelComponentViewModel>();
            foreach (var Travel in Travels)
            {
                var record = new ReportTravelComponentViewModel
                {
                    TravelName = Travel.TravelName,
                    Components = new List<(string Component, int Count)>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (Travel.TravelComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new(component.ComponentName, Travel.TravelComponents[component.Id].Item2));
                        record.TotalCount += Travel.TravelComponents[component.Id].Item2;
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
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                Id = x.Id,
                DateCreate = x.DateCreate,
                TravelName = x.TravelName,
                Sum = x.Sum,
                Status = x.Status.ToString(),
            })
           .ToList();
        }

        public void SaveTravelsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список ЖИ",
                Travels = _TravelStorage.GetFullList()
            });
        }
        public void SaveTravelComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список ЖИ",
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

    }
}
