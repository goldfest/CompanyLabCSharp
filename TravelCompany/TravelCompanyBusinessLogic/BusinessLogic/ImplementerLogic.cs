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
	public class ImplementerLogic : IImplementerLogic
	{
		private readonly ILogger _logger;
		private readonly IImplementerStorage _implementerStorage;
		public ImplementerLogic(ILogger<ImplementerLogic> logger, IImplementerStorage
	   implementerStorage)
		{
			_logger = logger;
			_implementerStorage = implementerStorage;
		}
		public List<ImplementerViewModel>? ReadList(ImplementerSearchModel? model)
		{
			_logger.LogInformation("ReadList. ImplementerFIO:{ClientFIO}. Id:{ Id}", model?.ImplementerFIO, model?.Id);
			var list = model == null ? _implementerStorage.GetFullList() :
	_implementerStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}
		public ImplementerViewModel? ReadElement(ImplementerSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. ImplementerFIO:{ImplementerFIO}.Id:{ Id}", model.ImplementerFIO, model.Id);
			var element = _implementerStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}
		public bool Create(ImplementerBindingModel model)
		{
			CheckModel(model);
			if (_implementerStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}
		public bool Update(ImplementerBindingModel model)
		{
			CheckModel(model);
			if (_implementerStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}
		public bool Delete(ImplementerBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_implementerStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}
		private void CheckModel(ImplementerBindingModel model, bool withParams =
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
			if (string.IsNullOrEmpty(model.ImplementerFIO))
			{
				throw new ArgumentNullException("Нет ФИО исполнителя",
			   nameof(model.ImplementerFIO));
			}
			if (string.IsNullOrEmpty(model.Password))
			{
				throw new ArgumentNullException("Нет пароля клиента",
			   nameof(model.Password));
			}
			if (model.WorkExperience < 0)
			{
				throw new ArgumentNullException("Стаж меньше 0",
			   nameof(model.WorkExperience));
			}
			if (model.Qualification < 0)
			{
				throw new ArgumentException("Квалификация меньше 0", nameof(model.Qualification));
			}
			_logger.LogInformation("Implementer. ImplementerFIO:{ImplementerFIO}." +
				"Password:{ Password}. WorkExperience:{ WorkExperience}. Qualification:{ Qualification}. Id: { Id} ", 
				model.ImplementerFIO, model.Password, model.WorkExperience, model.Qualification, model.Id);
			var element = _implementerStorage.GetElement(new ImplementerSearchModel
			{
				ImplementerFIO = model.ImplementerFIO,
			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Исполнитель с таким ФИО уже есть");
			}
		}
	}
}
