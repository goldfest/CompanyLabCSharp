using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.SearchModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;

namespace TravelCompanyDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using var context = new TravelCompanyDataBase();
            return context.Clients
            .Select(x => x.GetViewModel)
           .ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ClientFIO) && string.IsNullOrEmpty(model.Email) &&
                string.IsNullOrEmpty(model.Password) &&
                string.IsNullOrEmpty(model.ClientFIO))
            {
                return new();
            }
            using var context = new TravelCompanyDataBase();
            return context.Clients
            .Where(x => (string.IsNullOrEmpty(model.ClientFIO) || x.ClientFIO.Contains(model.ClientFIO) &&
                         string.IsNullOrEmpty(model.Email) || x.ClientFIO.Contains(model.Email) &&
                         string.IsNullOrEmpty(model.Password) || x.ClientFIO.Contains(model.Password)))
           .Select(x => x.GetViewModel)
           .ToList();
        }
        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ClientFIO) && string.IsNullOrEmpty(model.Email) &&
               !model.Id.HasValue)
            {
                return null;
            }
            using var context = new TravelCompanyDataBase();
            return context.Clients
            .FirstOrDefault(x => (string.IsNullOrEmpty(model.ClientFIO) || x.ClientFIO == model.ClientFIO) &&
                                 (!model.Id.HasValue || x.Id == model.Id) && (string.IsNullOrEmpty(model.Email) || x.Email == model.Email) &&
                                 (string.IsNullOrEmpty(model.Password) || x.Password == model.Password))
            ?.GetViewModel;
        }
        public ClientViewModel? Insert(ClientBindingModel model)
        {
            var newClient = Client.Create(model);
            if (newClient == null)
            {
                return null;
            }
            using var context = new TravelCompanyDataBase();
            context.Clients.Add(newClient);
            context.SaveChanges();
            return newClient.GetViewModel;
        }
        public ClientViewModel? Update(ClientBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            context.SaveChanges();
            return client.GetViewModel;
        }
        public ClientViewModel? Delete(ClientBindingModel model)
        {
            using var context = new TravelCompanyDataBase();
            var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
