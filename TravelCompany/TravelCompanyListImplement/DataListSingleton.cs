using TravelCompanyListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanyListImplement
{
    internal class DataListSingleton
    {
        private static DataListSingleton? _instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Travel> Travels { get; set; }
        public List<Client> Clients { get; set; }
        public List<Shop> Shops { get; set; }

        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Travels = new List<Travel>();
            Clients = new List<Client>();
            Shops = new List<Shop>();

        }
        public static DataListSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataListSingleton();
            }
            return _instance;
        }
    }
}
