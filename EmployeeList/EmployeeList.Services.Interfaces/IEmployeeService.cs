using EmployeeList.Domain.Entities.Infrastructure;
using EmployeeList.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetListAsync(string employerId, int skip = 0, int take = 50);
        Task<Employee> CreateAsync(Employee employee, string employerId);
        Task<DatabaseResult> DeleteAsync(string id, string employerId);
    }
}
