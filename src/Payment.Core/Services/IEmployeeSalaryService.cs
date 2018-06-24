using System.Collections.Generic;
using Payment.Contracts;

namespace Payment.Core.Services
{
    public interface IEmployeeSalaryService
    {
        IEnumerable<EmployeeSalary> GetAllEmployeeSalaries();
    }
}