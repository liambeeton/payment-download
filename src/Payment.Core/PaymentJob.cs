using System;
using FluentScheduler;
using Payment.Core.Services;

namespace Payment.Core
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
            try
            {
                var salaries = _employeeSalaryService.GetAllEmployeeSalaries();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
