using Calbay.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Calbay.Core.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContex> : IEntitiyRepository<TEntity>, IDisposable
        where TEntity : class, IEntity, new()
        where TContex : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public Task AddAsync(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                return context.SaveChangesAsync();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                return context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContex())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContex())
            {
                return context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContex())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContex())
            {
                return filter == null
                    ? context.Set<TEntity>().ToListAsync()
                    : context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }



        public void Update(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Task UpdateAsync(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                return context.SaveChangesAsync();
            }
        }
    }
}
