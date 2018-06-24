using System;
using System.IO;
using System.Text;
using FluentScheduler;
using Payment.Core.Configuration;
using Payment.Core.FileSystem;
using Payment.Core.Services;
using ServiceStack;

namespace Payment.Core.Jobs
{
    public class PaymentFileExportJob : IJob
    {
        private readonly IEmployeeSalaryService _employeeSalaryService;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IDirectoryHandler _directoryHandler;

        public PaymentFileExportJob(
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
            var directoryInfo = _directoryHandler.Create(_configurationProvider.SecureFolderPath, _configurationProvider.PaymentFilePathIdentity);
            var filename = $"employee-salaries-{DateTime.Now.ToFileTime()}.csv";

            File.WriteAllText(Path.Combine(directoryInfo.FullName, filename), employeeSalaries.ToCsv(), Encoding.UTF8);
        }
    }
}
