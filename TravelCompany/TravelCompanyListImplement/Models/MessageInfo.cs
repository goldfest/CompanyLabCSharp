using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyListImplement.Models
{
    public class MessageInfo : IMessageInfoModel
    {
        public string MessageId { get; private set; } = string.Empty;

        public int? ClientId { get; private set; }

        public string SenderName { get; private set; } = string.Empty;

        public DateTime DateDelivery { get; private set; } = DateTime.Now;

        public string Subject { get; private set; } = string.Empty;

        public string Body { get; private set; } = string.Empty;

        public static MessageInfo? Create(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new()
            {
                Body = model.Body,
                Subject = model.Subject,
                ClientId = model.ClientId,
                MessageId = model.MessageId,
                SenderName = model.SenderName,
                DateDelivery = model.DateDelivery,
            };
        }

        public MessageInfoViewModel GetViewModel => new()
        {
            Body = Body,
            Subject = Subject,
            ClientId = ClientId,
            MessageId = MessageId,
            SenderName = SenderName,
            DateDelivery = DateDelivery,
        };
    }
}
