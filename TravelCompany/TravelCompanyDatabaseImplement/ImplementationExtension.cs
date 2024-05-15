using TravelCompanyContracts.DI;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyDatabaseImplement.Implements;

namespace TravelCompanyDatabaseImplement
{
    public class ImplementationExtension : IImplementationExtension
    {
        public int Priority => 3;

        public void RegisterServices()
        {
            DependencyManager.Instance.RegisterType<IClientStorage, ClientStorage>();
            DependencyManager.Instance.RegisterType<IComponentStorage, ComponentStorage>();
            DependencyManager.Instance.RegisterType<IImplementerStorage, ImplementerStorage>();
            DependencyManager.Instance.RegisterType<IMessageInfoStorage, MessageInfoStorage>();
            DependencyManager.Instance.RegisterType<IOrderStorage, OrderStorage>();
            DependencyManager.Instance.RegisterType<ITravelStorage, TravelStorage>();
            DependencyManager.Instance.RegisterType<IBackUpInfo, BackUpInfo>();
        }
    }
}
