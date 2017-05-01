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
    public class TestModelRepository : GenericRepository<TestModel>, ITestModelRepository
    {
        public TestModelRepository() : base()
        {
        }

        public async Task<TestModel> Test()
        {
            var item = new TestModel
            {
                First = "1",
                Second = 2
            };

            var result = await base.InsertOneAsync(item);

            return item;
        }
    }
}
