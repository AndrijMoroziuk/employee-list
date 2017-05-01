using EmployeeList.Domain.Entities.Infrastructure;
using EmployeeList.Domain.Entities.Models;
using EmployeeList.Domain.Interfaces;
using EmployeeList.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList.Infrastructure.Business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetListAsync(string employerId, int skip = 0, int take = 50)
        {
            var result = await _employeeRepository.FindManyAsync(x => x.EmployerId == employerId, take, skip);

            return result;
        }

        public async Task<Employee> CreateAsync(Employee employee, string employerId)
        {
            employee.EmployerId = employerId;
            var result = await _employeeRepository.InsertOneAsync(employee);

            return employee;
        }

        public async Task<DatabaseResult> DeleteAsync(string id, string employerId)
        {
            var employee = await _employeeRepository.GetOneAsync(id);
            DatabaseResult result = new DatabaseResult();

            if (employee.EmployerId == employerId)
                result = await _employeeRepository.DeleteOneAsync(x => x.Id == id);
            else
            {
                result.Success = false;
                result.Message = "Access denied.";
            }

            return result;
        }
    }
}
