using Ninject.Modules;
using Payment.Core;

namespace Payment.Service
{
    public class IocModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceHost>().To<ServiceHost>().InSingletonScope();
            Bind<IConfigurationProvider>().To<ConfigurationProvider>().InSingletonScope();
        }
    }
}
