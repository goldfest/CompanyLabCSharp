using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyListImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton _source;
        public MessageInfoStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            List<MessageInfoViewModel> result = new();
            foreach (var item in _source.Messages)
            {
                result.Add(item.GetViewModel);
            }
            return result;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            List<MessageInfoViewModel> result = new();
            foreach (var item in _source.Messages)
            {
                if (item.ClientId.HasValue && item.ClientId == model.ClientId)
                {
                    result.Add(item.GetViewModel);
                }
            }
            return result;
        }

        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            foreach (var message in _source.Messages)
            {
                if (model.MessageId != null && model.MessageId.Equals(message.MessageId))
                {
                    return message.GetViewModel;
                }
            }
            return null;
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            var newMessage = MessageInfo.Create(model);
            if (newMessage == null)
            {
                return null;
            }
            _source.Messages.Add(newMessage);
            return newMessage.GetViewModel;
        }
    }
}
