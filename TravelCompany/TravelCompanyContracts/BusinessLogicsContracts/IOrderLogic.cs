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
        bool CreateOrder(OrderBindingModel model);
        bool TakeOrderInWork(OrderBindingModel model);
        /// <summary>
        /// Готов
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool FinishOrder(OrderBindingModel model);
        /// <summary>
        /// Доставлен
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool DeliveryOrder(OrderBindingModel model);
    }
}
