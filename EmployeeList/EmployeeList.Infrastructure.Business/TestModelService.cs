using MongoDB.Driver;
using EmployeeList.Domain.Entities.Models;
using EmployeeList.Domain.Interfaces;
using System.Threading.Tasks;
using EmployeeList.Services.Interfaces;

namespace EmployeeList.Infrastructure.Business
{
    public class TestModelService : ITestModelService
    {
        private readonly ITestModelRepository _testModelRepository;

        public TestModelService(ITestModelRepository _testModelRepository)
        {
            this._testModelRepository = _testModelRepository;
        }

        public async Task Test()
        {
            var model = await _testModelRepository.Test();

            var updateDefinition = Builders<TestModel>.Update.Set(u => u.First, "first").Set(u => u.Second, 999);
            //var result = await _testModelRepository.UpdateOneAsync(model.Id, updateDefinition);

            await _testModelRepository.DeleteOneAsync(x => x.Id == model.Id);
        }
    }
}
