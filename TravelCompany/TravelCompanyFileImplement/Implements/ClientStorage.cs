using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyFileImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        private readonly DataFileSingleton source;
        public ClientStorage()
        {
            source = DataFileSingleton.GetInstance();
        }
        public List<ClientViewModel> GetFullList()
        {
            return source.Clients
            .Select(x => x.GetViewModel)
           .ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientSearchModel
       model)
        {
            if (string.IsNullOrEmpty(model.ClientFIO) && string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
            {
                return new();
            }
            return source.Clients
            .Where(x => (string.IsNullOrEmpty(model.ClientFIO) || x.ClientFIO.Contains(model.ClientFIO) &&
                         string.IsNullOrEmpty(model.Email) || x.ClientFIO.Contains(model.Email) &&
                         string.IsNullOrEmpty(model.Password) || x.ClientFIO.Contains(model.Password)))
           .Select(x => x.GetViewModel)
           .ToList();
        }
        public ClientViewModel? GetElement(ClientSearchModel model)
        {
			return source.Clients
			.FirstOrDefault(x => (string.IsNullOrEmpty(model.ClientFIO) || x.ClientFIO == model.ClientFIO) &&
								 (!model.Id.HasValue || x.Id == model.Id) && (string.IsNullOrEmpty(model.Email) || x.Email == model.Email) &&
								 (string.IsNullOrEmpty(model.Password) || x.Password == model.Password))
			?.GetViewModel;
		}
        public ClientViewModel? Insert(ClientBindingModel model)
        {
            model.Id = source.Clients.Count > 0 ? source.Clients.Max(x =>
           x.Id) + 1 : 1;
            var newClient = Client.Create(model);
            if (newClient == null)
            {
                return null;
            }
            source.Clients.Add(newClient);
            source.SaveClients();
            return newClient.GetViewModel;
        }
        public ClientViewModel? Update(ClientBindingModel model)
        {
            var client = source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            source.SaveClients();
            return client.GetViewModel;
        }
        public ClientViewModel? Delete(ClientBindingModel model)
        {
            var element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Clients.Remove(element);
                source.SaveClients();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
