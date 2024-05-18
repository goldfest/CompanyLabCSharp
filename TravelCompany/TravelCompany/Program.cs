using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyBusinessLogic.BusinessLogic;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using TravelCompanyBusinessLogic.OfficePackage.Implements;
using TravelCompanyBusinessLogic.OfficePackage;
using TravelCompanyBusinessLogic.MailWorker;
using TravelCompanyContracts.BindingModels;


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
            try
            {
                var mailSender =
                _serviceProvider.GetService<AbstractMailWorker>();
                mailSender?.MailConfig(new MailConfigBindingModel
                {
                    MailLogin =
                System.Configuration.ConfigurationManager.AppSettings["MailLogin"] ??
                string.Empty,
                    MailPassword =
                System.Configuration.ConfigurationManager.AppSettings["MailPassword"] ??
                string.Empty,
                    SmtpClientHost =
                System.Configuration.ConfigurationManager.AppSettings["SmtpClientHost"] ??
                string.Empty,
                    SmtpClientPort =
                Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"]),
                    PopHost =
                System.Configuration.ConfigurationManager.AppSettings["PopHost"] ?? string.Empty,
                    PopPort =
                Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PopPort"])
                });
                // создаем таймер
                var timer = new System.Threading.Timer(new
                TimerCallback(MailCheck!), null, 0, 100000);
            }
            catch (Exception ex)
            {
                var logger = _serviceProvider.GetService<ILogger>();
                logger?.LogError(ex, "Ошибка работы с почтой");
            }

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
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();

            services.AddTransient<IComponentLogic, ComponentLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ITravelLogic, TravelLogic>();
            services.AddTransient<IReportLogic, ReportLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IImplementerLogic, ImplementerLogic>();
            services.AddTransient<IImplementerStorage, ImplementerStorage>();
            services.AddTransient<IWorkProcess, WorkModeling>();
            services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();

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
            services.AddSingleton<AbstractMailWorker, MailKitWorker>();
            services.AddTransient<FormClients>();
            services.AddTransient<ImplementersForm>();
            services.AddTransient<ImplementerForm>();
            services.AddTransient<FormViewMail>();

        }
        private static void MailCheck(object obj) =>
ServiceProvider?.GetService<AbstractMailWorker>()?.MailCheck();
    }
}