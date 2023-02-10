using System.Linq.Expressions;

namespace project.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetEntity(int id);
        Task<TEntity> GetEntityAsync(int id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entities);
    }
}