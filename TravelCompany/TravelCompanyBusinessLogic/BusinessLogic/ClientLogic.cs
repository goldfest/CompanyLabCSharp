using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyBusinessLogic.BusinessLogic
{
    public class ClientLogic : IClientLogic
    {
        private readonly ILogger _logger;
        private readonly IClientStorage _clientStorage;
        public ClientLogic(ILogger<ClientLogic> logger, IClientStorage
       componentStorage)
        {
            _logger = logger;
            _clientStorage = componentStorage;
        }
        public List<ClientViewModel>? ReadList(ClientSearchModel? model)
        {
            _logger.LogInformation("ReadList. ClientFIO:{ClientFIO}. Id:{ Id}", model?.ClientFIO, model?.Id);
            var list = model == null ? _clientStorage.GetFullList() :
    _clientStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public ClientViewModel? ReadElement(ClientSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ClientFIO:{ClientFIO}.Id:{ Id}", model.ClientFIO, model.Id);
            var element = _clientStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public bool Create(ClientBindingModel model)
        {
            CheckModel(model);
            if (_clientStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Update(ClientBindingModel model)
        {
            CheckModel(model);
            if (_clientStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(ClientBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_clientStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(ClientBindingModel model, bool withParams =
       true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ClientFIO))
            {
                throw new ArgumentNullException("Нет ФИО клиента",
               nameof(model.ClientFIO));
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new ArgumentNullException("Нет Email клиента",
               nameof(model.ClientFIO));
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentNullException("Нет пароля клиента",
               nameof(model.ClientFIO));
            }
            _logger.LogInformation("Client. ClientFIO:{ClientFIO}." +
                "Email:{ Email}. Password:{ Password}. Id: { Id} ", model.ClientFIO, model.Email, model.Password, model.Id);
            var element = _clientStorage.GetElement(new ClientSearchModel
            {
                Email = model.Email,          
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Клиент с таким лоигном уже есть");
            }
        }
    }
}
