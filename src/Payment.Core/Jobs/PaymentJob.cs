using FluentScheduler;
using Payment.Core.Services;

namespace Payment.Core.Jobs
{
    public class PaymentJob : IJob
    {
        private readonly IEmployeeSalaryService _employeeSalaryService;

        public PaymentJob(IEmployeeSalaryService employeeSalaryService)
        {
            _employeeSalaryService = employeeSalaryService;
        }

        public void Execute()
        {
            var employeeSalaries = _employeeSalaryService.GetAllEmployeeSalaries();
        }
    }
}
