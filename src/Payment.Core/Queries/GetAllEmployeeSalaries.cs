using System.Collections.Generic;
using System.Linq;
using Payment.Contracts;
using Payment.Data;
using Payment.Data.Session;

namespace Payment.Core.Queries
{
    public class GetAllEmployeeSalaries : IQuery<IList<EmployeeSalary>>
    {
        public IList<EmployeeSalary> Execute(ISession session)
        {
            return session.Query<EmployeeSalary>("SELECT * FROM Employee INNER JOIN Salary ON Employee.Id = Salary.EmployeeId").ToList();
        }
    }
}
