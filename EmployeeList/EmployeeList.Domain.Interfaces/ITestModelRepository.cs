using EmployeeList.Domain.Entities.Models;
using EmployeeList.Domain.Interfaces.Infrastructure;
using System.Threading.Tasks;

namespace EmployeeList.Domain.Interfaces
{
    public interface ITestModelRepository : IRepository<TestModel>
    {
        Task<TestModel> Test();
    }
}
