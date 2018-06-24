using FluentScheduler;
using Payment.Core.Configuration;
using Payment.Core.FileSystem;
using Payment.Core.Services;

namespace Payment.Core.Jobs
{
    public class PaymentJob : IJob
    {
        private readonly IEmployeeSalaryService _employeeSalaryService;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IDirectoryHandler _directoryHandler;

        public PaymentJob(
            IEmployeeSalaryService employeeSalaryService, 
            IConfigurationProvider configurationProvider, 
            IDirectoryHandler directoryHandler)
        {
            _employeeSalaryService = employeeSalaryService;
            _directoryHandler = directoryHandler;
            _configurationProvider = configurationProvider;
        }

        public void Execute()
        {
            var employeeSalaries = _employeeSalaryService.GetAllEmployeeSalaries();

            var directory = _directoryHandler.Create(_configurationProvider.SecureFolderPath);
        }
    }
}
