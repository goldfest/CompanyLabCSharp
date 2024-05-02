using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        List<ReportTravelComponentViewModel> GetTravelComponents();
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        List<ReportShopsViewModel> GetShops();
        List<ReportGroupOrdersViewModel> GetGroupedOrders();
        void SaveTravelsToWordFile(ReportBindingModel model);
        void SaveTravelComponentToExcelFile(ReportBindingModel model);
        void SaveOrdersToPdfFile(ReportBindingModel model);
        void SaveShopsToWordFile(ReportBindingModel model);
        void SaveShopsToExcelFile(ReportBindingModel model);
        void SaveGroupedOrdersToPdfFile(ReportBindingModel model);
    }
}
