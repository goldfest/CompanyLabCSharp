using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyBusinessLogic.BusinessLogic
{
    public class TravelLogic : ITravelLogic
    {
        private readonly ILogger _logger;
        private readonly ITravelStorage _TravelStorage;
        public TravelLogic(ILogger<TravelLogic> logger, ITravelStorage TravelStorage)
        {
            _logger = logger;
            _TravelStorage = TravelStorage;
        }
        public List<TravelViewModel>? ReadList(TravelSearchModel? model)
        {
            _logger.LogInformation("ReadList. TravelName:{TravelName}.Id:{Id}", model?.TravelName, model?.Id);
            var list = model == null ? _TravelStorage.GetFullList() : _TravelStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public TravelViewModel? ReadElement(TravelSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. TravelName:{TravelName}.Id:{Id}", model.TravelName, model.Id);
            var element = _TravelStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(TravelBindingModel model)
        {
            CheckModel(model);
            if (_TravelStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(TravelBindingModel model)
        {
            CheckModel(model);
            if (_TravelStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(TravelBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_TravelStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(TravelBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.TravelName))
            {
                throw new ArgumentNullException("Нет названия изделия", nameof(model.TravelName));
            }
            if (model.Price <= 0)
            {
                throw new ArgumentNullException("Цена изделия должна быть больше 0", nameof(model.Price));
            }
            _logger.LogInformation("Travel. TravelName:{TravelName}.Price:{Cost}. Id: {Id}", model.TravelName, model.Price, model.Id);
            var element = _TravelStorage.GetElement(new TravelSearchModel
            {
                TravelName = model.TravelName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Изделие с таким названием уже есть");
            }
        }
    }
}
