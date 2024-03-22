using TravelCompany.Forms;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyBusinessLogic.BusinessLogic;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyListImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TravelCompanyView;
using TravelCompanyBusinessLogic.BusinessLogics;

namespace TravelCompany
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;
        public static ServiceProvider? ServiceProvider => _serviceProvider;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });
            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<ITravelStorage, TravelStorage>();
            services.AddTransient<IComponentLogic, ComponentLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ITravelLogic, TravelLogic>();
            services.AddTransient<FormMain>();
            services.AddTransient<FormComponent>();
            services.AddTransient<FormComponents>();
            services.AddTransient<FormCreateOrder>();
            services.AddTransient<FormTravel>();
            services.AddTransient<FormTravelComponent>();
            services.AddTransient<FormTravels>();
            services.AddTransient<IShopStorage, ShopStorage>();
            services.AddTransient<IShopLogic, ShopLogic>();
            services.AddTransient<FormShop>();
            services.AddTransient<FormShops>();
            services.AddTransient<FormCreateSupply>();
        }
    }
}