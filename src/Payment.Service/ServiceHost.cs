using FluentScheduler;
using Ninject;
using Payment.Core;
using Topshelf.Logging;

namespace Payment.Service
{
    public class ServiceHost : IServiceHost
    {
        private readonly LogWriter _logger = HostLogger.Get<ServiceHost>();

        public void Start()
        {
            JobManager.JobFactory = new JobFactory(new StandardKernel(new IocModule()));
            JobManager.Initialize(new JobRegistry());
            JobManager.JobException += info => _logger.Fatal("An error just happened with a scheduled job: " + info.Exception);
        }

        public void Stop()
        {
            JobManager.Stop();
        }

        public void Shutdown()
        {
            JobManager.StopAndBlock();
        }
    }
}
