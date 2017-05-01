using MongoDB.Driver;
using EmployeeList.Domain.Entities.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList.Domain.Interfaces.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class //IBaseEntity що б програміст не допустив помилку було
    {
        Task<List<TEntity>> GetAllAsync(int limit = 50, int skip = 0);
        Task<TEntity> GetOneAsync(string id);
        Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> predicate, int limit = 50, int skip = 0);

        Task<DatabaseResult> InsertOneAsync(TEntity entity);

        Task<DatabaseResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
