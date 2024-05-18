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
using TravelCompanyContracts.DI;



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
            InitDependency();
            try
            {
                var mailSender = DependencyManager.Instance.Resolve<AbstractMailWorker>();
                mailSender?.MailConfig(new MailConfigBindingModel
                {
                    MailLogin = System.Configuration.ConfigurationManager.AppSettings["MailLogin"] ?? string.Empty,
                    MailPassword = System.Configuration.ConfigurationManager.AppSettings["MailPassword"] ?? string.Empty,
                    SmtpClientHost = System.Configuration.ConfigurationManager.AppSettings["SmtpClientHost"] ?? string.Empty,
                    SmtpClientPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"]),
                    PopHost = System.Configuration.ConfigurationManager.AppSettings["PopHost"] ?? string.Empty,
                    PopPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PopPort"])
                });

                var timer = new System.Threading.Timer(new TimerCallback(MailCheck!), null, 0, 100000);
            }
            catch (Exception ex)
            {
                var logger = DependencyManager.Instance.Resolve<ILogger>();
                logger?.LogError(ex, "Mails Problem");
            }
            Application.Run(DependencyManager.Instance.Resolve<FormMain>());
        }
        private static void InitDependency()
        {
            DependencyManager.InitDependency();

            DependencyManager.Instance.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });

            DependencyManager.Instance.RegisterType<IComponentLogic, ComponentLogic>();
            DependencyManager.Instance.RegisterType<IOrderLogic, OrderLogic>();
            DependencyManager.Instance.RegisterType<ITravelLogic, TravelLogic>();
            DependencyManager.Instance.RegisterType<IReportLogic, ReportLogic>();
            DependencyManager.Instance.RegisterType<IClientLogic, ClientLogic>();
            DependencyManager.Instance.RegisterType<IImplementerLogic, ImplementerLogic>();
            DependencyManager.Instance.RegisterType<IMessageInfoLogic, MessageInfoLogic>();
            DependencyManager.Instance.RegisterType<IBackUpLogic, BackUpLogic>();
            DependencyManager.Instance.RegisterType<IWorkProcess, WorkModeling>();

            DependencyManager.Instance.RegisterType<AbstractSaveToExcel, SaveToExcel>();
            DependencyManager.Instance.RegisterType<AbstractSaveToWord, SaveToWord>();
            DependencyManager.Instance.RegisterType<AbstractSaveToPdf, SaveToPdf>();
            DependencyManager.Instance.RegisterType<AbstractMailWorker, MailKitWorker>();

            DependencyManager.Instance.RegisterType<FormMain>();
            DependencyManager.Instance.RegisterType<FormComponent>();
            DependencyManager.Instance.RegisterType<FormComponents>();
            DependencyManager.Instance.RegisterType<FormCreateOrder>();
            DependencyManager.Instance.RegisterType<FormTravel>();
            DependencyManager.Instance.RegisterType<FormTravelComponent>();
            DependencyManager.Instance.RegisterType<FormTravels>();
            DependencyManager.Instance.RegisterType<FormReportTravelComponents>();
            DependencyManager.Instance.RegisterType<FormReportOrders>();
            DependencyManager.Instance.RegisterType<FormClients>();
            DependencyManager.Instance.RegisterType<ImplementersForm>();
            DependencyManager.Instance.RegisterType<ImplementerForm>();
            DependencyManager.Instance.RegisterType<FormViewMail>();

        }
        private static void MailCheck(object obj) => DependencyManager.Instance.Resolve<AbstractMailWorker>()?.MailCheck();
    }
}