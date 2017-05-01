using EmployeeList.Domain.Entities.Models;
using EmployeeList.Domain.Interfaces;
using EmployeeList.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList.Infrastructure.Data
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
    }
}
