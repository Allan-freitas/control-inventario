namespace Qualite.Ingenieria.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(long id);
        Task<long> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(long id);
    }
}
