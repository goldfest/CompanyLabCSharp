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
        void SaveTravelsToWordFile(ReportBindingModel model);
        void SaveTravelComponentToExcelFile(ReportBindingModel model);
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
