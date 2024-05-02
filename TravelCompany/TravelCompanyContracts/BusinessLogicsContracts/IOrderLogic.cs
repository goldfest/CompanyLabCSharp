using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface IOrderLogic
    {
        List<OrderViewModel>? ReadList(OrderSearchModel? model);
        OrderViewModel? ReadElement(OrderSearchModel model);
        bool CreateOrder(OrderBindingModel model);
        bool TakeOrderInWork(OrderBindingModel model);
        bool FinishOrder(OrderBindingModel model);
        bool DeliveryOrder(OrderBindingModel model);
    }
}
