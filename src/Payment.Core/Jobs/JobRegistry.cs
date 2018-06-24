using FluentScheduler;
using Payment.Core.Configuration;

namespace Payment.Core.Jobs
{
    public class JobRegistry : Registry
    {
        public JobRegistry()
        {
            var configurationProvider = new ConfigurationProvider();

            Schedule<PaymentJob>().ToRunNow().AndEvery(1).Months().On(int.Parse(configurationProvider.PaymentFileExportDay)).At(8, 0);
        }
    }
}
