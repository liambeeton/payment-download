using FluentScheduler;

namespace Payment.Core
{
    public class JobRegistry : Registry
    {
        public JobRegistry()
        {
            Schedule<PaymentJob>().ToRunNow().AndEvery(1).Months().On(24).At(3, 0);
        }
    }
}
