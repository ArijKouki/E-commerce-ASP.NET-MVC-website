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


#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        public TEntity GetEntity(int id) => context1.Set<TEntity>().Find(id);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.

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