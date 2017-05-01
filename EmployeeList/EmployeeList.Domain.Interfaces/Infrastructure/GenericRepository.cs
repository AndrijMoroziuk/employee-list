using MongoDB.Bson;
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
    public abstract class GenericRepository<TEntity> where TEntity : class //IBaseEntity
    {
        private DatabaseFactory _mongoDbContext = null;
        public GenericRepository(DatabaseFactory mongoDbContext = null)
        {
            _mongoDbContext = mongoDbContext != null ? mongoDbContext : new DatabaseFactory();
        }

        private IMongoCollection<TEntity> collection
        {
            get { return _mongoDbContext.GetCollection<TEntity>(); }
        }

        public virtual async Task<List<TEntity>> GetAllAsync(int limit = 50, int skip = 0)
        {
            var entities = await collection.Find(new BsonDocument()).Limit(limit).Skip(skip).ToListAsync();
            return entities;
        }

        public virtual async Task<TEntity> GetOneAsync(string id)
        {
            var entity = await collection.Find(new BsonDocument("_id", new ObjectId(id))).SingleOrDefaultAsync();
            return entity;
        }

        public virtual async Task<List<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>> predicate, int limit = 50, int skip = 0)
        {
            var entities = await collection.Find(predicate).Limit(limit).Skip(skip).ToListAsync();
            return entities;
        }


        public virtual async Task<DatabaseResult> InsertOneAsync(TEntity entity)
        {
            var dbResult = new DatabaseResult();

            try
            {
                await collection.InsertOneAsync(entity);
                dbResult.Success = true;
                return dbResult;
            }
            catch (Exception ex)
            {
                dbResult.Message = "Exception InsertOneAsync " + typeof(TEntity).Name;
                dbResult.Exception = ex;
                return dbResult;
            }
        }

        public virtual async Task<DatabaseResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var dbResult = new DatabaseResult();

            try
            {
                var res = await collection.DeleteOneAsync(predicate);
                if (res.DeletedCount < 1)
                {
                    dbResult.Message = "ERROR: DeletedCount < 1 for entity: " + typeof(TEntity).Name;
                    return dbResult;
                }

                dbResult.Success = true;
                return dbResult;
            }
            catch (Exception ex)
            {
                dbResult.Message = "Exception DeleteOneAsync " + typeof(TEntity).Name;
                dbResult.Exception = ex;
                return dbResult;
            }
        }
    }
}
