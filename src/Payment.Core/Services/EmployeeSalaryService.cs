using System.Collections.Generic;
using Payment.Contracts;
using Payment.Core.Queries;
using Payment.Data;

namespace Payment.Core.Services
{
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly IDatabase _database;

        public EmployeeSalaryService(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<EmployeeSalary> GetAllEmployeeSalaries()
        {
            return _database.Query(new GetAllEmployeeSalaries());
        }
    }
}
