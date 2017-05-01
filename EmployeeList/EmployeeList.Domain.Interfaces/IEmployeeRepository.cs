using EmployeeList.Domain.Entities.Models;
using EmployeeList.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
