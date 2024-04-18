using DocumentFormat.OpenXml.Office2010.Excel;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace TravelCompanyRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : Controller
    {
        private readonly ILogger _logger;
        private readonly IOrderLogic _order;
        private readonly ITravelLogic _Travel;
        public MainController(ILogger<MainController> logger, IOrderLogic order,
       ITravelLogic Travel)
        {
            _logger = logger;
            _order = order;
            _Travel = Travel;
        }
        [HttpGet]
        public List<TravelViewModel>? GetTravelList()
        {
            try
            {
                return _Travel.ReadList(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка мороженного");
                throw;
            }
        }
        [HttpGet]
        public TravelViewModel? GetTravel(int TravelId)
        {
            try
            {
                return _Travel.ReadElement(new TravelSearchModel
                {
                    Id =
			   TravelId
				});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения продукта по id={Id}",
			   TravelId);
                throw;
            }
        }
        [HttpGet]
        public List<OrderViewModel>? GetOrders(int clientId)
        {
            try
            {
                return _order.ReadList(new OrderSearchModel
                {
                    ClientId = clientId
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка заказов клиента id ={ Id}", clientId);
            throw;
            }
        }
        [HttpPost]
        public void CreateOrder(OrderBindingModel model)
        {
            try
            {
                _order.CreateOrder(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания заказа");
                throw;
            }
        }
    }
}
