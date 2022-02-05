using Dommel;
using MySql.Data.MySqlClient;
using Qualite.Ingenieria.Domain.Repositories;
using System.Data;

namespace Qualite.Ingenieria.Data.Repositories
{
    public class Repository<TEntity> : RepositoryBase, IRepository<TEntity> where TEntity : class
    {        
        public Repository(IDbTransaction dbTransaction) : base(dbTransaction) { }

        public async Task<long> CreateAsync(TEntity entity)
        {            
            try
            {
                var inserted = await Connection.InsertAsync(entity, Transaction);                
                return Convert.ToInt64(inserted); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await Connection.DeleteAsync(id, Transaction);
        }

        public async Task<IQueryable<TEntity>> FindAllAsync()
        {
            IEnumerable<TEntity> results = await Connection.GetAllAsync<TEntity>();
            return results.AsQueryable();
        }

        public async Task<TEntity> FindByIdAsync(long id)
        {
            return await Connection.GetAsync<TEntity>(id);            
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                return await Connection.UpdateAsync(entity, Transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
