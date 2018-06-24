using System.Configuration;
using Ninject.Modules;
using Payment.Core;
using Payment.Core.Configuration;
using Payment.Core.Services;
using Payment.Data;
using Payment.Data.Dapper;
using Payment.Data.Session;

namespace Payment.Service
{
    public class IocModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceHost>().To<ServiceHost>();
            Bind<IConfigurationProvider>().To<ConfigurationProvider>();
            Bind<ISession>().ToConstructor(x => new Session(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString));
            Bind<IDatabase>().To<Database>();
            Bind<IDapperContext>().To<DapperContext>();
            Bind<IEmployeeSalaryService>().To<EmployeeSalaryService>();
        }
    }
}
