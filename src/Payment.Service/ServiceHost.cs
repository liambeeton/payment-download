using FluentScheduler;
using Payment.Core;

namespace Payment.Service
{
    public class ServiceHost : IServiceHost
    {
        public void Start()
        {
            JobManager.Initialize(new JobRegistry());
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
