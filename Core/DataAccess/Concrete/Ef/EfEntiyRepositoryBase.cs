using BiruniEdu.Core.DataAccess.Abstract;
using BiruniEdu.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BiruniEdu.Core.DataAccess.Concrete.Ef
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var record = context.Set<TEntity>().FirstOrDefault(filter);

                return record;
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
        {
            using (var context = new TContext())
            {
                if (filter == null)
                {
                    var record = context.Set<TEntity>();
                    return record.ToList();
                }
                else
                {
                    var record = context.Set<TEntity>().Where(filter);
                    return record.ToList();
                }
            }
        }

        public TEntity Create(TEntity entity)
        {
            using (var context = new TContext())
            {
                var table = context.Set<TEntity>();
                table.Add(entity);
                context.SaveChanges();
                return entity;
            }

        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var table = context.Set<TEntity>();
                table.Update(entity);
                context.SaveChanges();
                return entity;
            }
           
        }

        public TEntity Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var table = context.Set<TEntity>();
                table.Remove(entity);
                context.SaveChanges();
                return entity;
            }

        }
    }
}
