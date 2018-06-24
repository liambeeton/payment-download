using System;
using log4net.Config;
using Ninject;
using Payment.Core.Configuration;
using Payment.Service.Ninject;
using Payment.Service.ServiceHost;
using Topshelf;
using Topshelf.Logging;
using Topshelf.Ninject;

namespace Payment.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            var service = HostFactory.Run(x =>
            {
                x.UseLog4Net();
                x.UseNinject(new IocModule());

                x.Service<IServiceHost>(y =>
                {
                    y.ConstructUsingNinject();
                    y.WhenStarted(z => z.Start());
                    y.WhenStopped(z => z.Stop());
                    y.WhenShutdown(z => z.Shutdown());
                });

                x.EnableShutdown();
                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.EnableServiceRecovery(y =>
                {
                    y.RestartService(0);
                    y.RestartService(1);
                    y.RestartService(2);
                    y.OnCrashOnly();
                    y.SetResetPeriod(1);
                });

                x.OnException(ex => {
                    HostLogger.Get<Program>().Error("Error occurred while the service was running", ex);
                });

                var configurationProvider = NinjectBuilderConfigurator.Kernel.Get<IConfigurationProvider>();

                x.SetDescription(configurationProvider.ServiceName);
                x.SetDisplayName(configurationProvider.ServiceName);
                x.SetServiceName(configurationProvider.ServiceName);
            });

            var exitCode = (int)Convert.ChangeType(service, service.GetTypeCode());

            Environment.ExitCode = exitCode;
        }
    }
}
