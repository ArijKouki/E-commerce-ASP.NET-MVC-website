using System.Data.Entity;
using System.Linq.Expressions;

namespace project.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ProjectContext context1;
        public Repository(ProjectContext context)
        {
            this.context1 = context;
        }
        public bool Add(TEntity entity)
        {
            try
            {
                context1.Set<TEntity>().Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                context1.Set<TEntity>().AddRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context1.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context1.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await context1.Set<TEntity>().ToListAsync();
            return result;
        }


        public TEntity GetEntity(int id) => context1.Set<TEntity>().Find(id);

        public async Task<TEntity> GetEntityAsync(int id)
        {
            var result= await context1.Set<TEntity>().FindAsync(id);
            return result;
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                context1.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                context1.Set<TEntity>().RemoveRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }
    }
}