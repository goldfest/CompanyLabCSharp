using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyBusinessLogic.BusinessLogic;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TravelCompanyBusinessLogic.OfficePackage.Implements;
using TravelCompanyBusinessLogic.OfficePackage;


namespace TravelCompany.Forms
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
            services.AddTransient<IReportLogic, ReportLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IImplementerLogic, ImplementerLogic>();
            services.AddTransient<IImplementerStorage, ImplementerStorage>();
            services.AddTransient<IWorkProcess, WorkModeling>();

            services.AddTransient<IShopStorage, ShopStorage>();
            services.AddTransient<IShopLogic, ShopLogic>();
            services.AddTransient<FormShop>();
            services.AddTransient<FormShops>();
            services.AddTransient<FormCreateSupply>();
            services.AddTransient<FormSellTravels>();
            services.AddTransient<FormReportShop>();
            services.AddTransient<FormReportGroupedOrders>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormComponent>();
            services.AddTransient<FormComponents>();
            services.AddTransient<FormCreateOrder>();
            services.AddTransient<FormTravel>();
            services.AddTransient<FormTravelComponent>();
            services.AddTransient<FormTravels>();
            services.AddTransient<FormReportTravelComponents>();
            services.AddTransient<FormReportOrders>();
            services.AddTransient<AbstractSaveToExcel, SaveToExcel>();
            services.AddTransient<AbstractSaveToWord, SaveToWord>();
            services.AddTransient<AbstractSaveToPdf, SaveToPdf>();
            services.AddTransient<FormClients>();
            services.AddTransient<ImplementersForm>();
            services.AddTransient<ImplementerForm>();

        }
    }
}