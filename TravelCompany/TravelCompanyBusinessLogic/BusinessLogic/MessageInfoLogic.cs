using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace TravelCompanyBusinessLogic.BusinessLogic
{
	public class MessageInfoLogic : IMessageInfoLogic
	{
		private readonly ILogger _logger;
		private readonly IMessageInfoStorage _messageInfoStorage;
		public MessageInfoLogic(ILogger<MessageInfoLogic> logger, IMessageInfoStorage MessageInfoStorage)
		{
			_logger = logger;
			_messageInfoStorage = MessageInfoStorage;
		}

		public bool Create(MessageInfoBindingModel model)
		{
			if (_messageInfoStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}

		public List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model)
		{
			_logger.LogInformation("ReadList. MessageId:{MessageId}.ClientId:{ClientId} ", model?.MessageId, model?.ClientId);
			var list = (model == null) ? _messageInfoStorage.GetFullList() : _messageInfoStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}
	}
}
