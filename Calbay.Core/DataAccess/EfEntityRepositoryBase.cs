﻿using Calbay.Core.Entities;
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
        public virtual void Add(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();                
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

        public virtual async Task DeleteAsync(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {

        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContex())
            {
                return context.Set<TEntity>().FirstOrDefault(SetFilter(filter));
            }
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContex())
            {
                var task = await context.Set<TEntity>().FirstOrDefaultAsync(SetFilter(filter));

                return task;
            }
        }

        public virtual async Task<TEntity> GetAsync(List<string> includes, Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContex())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }

                //var sql = query.Where(SetFilter(filter)).ToSql();
                //var test = query.Where(SetFilter(filter)).ToList();
                return await query.FirstOrDefaultAsync(SetFilter(filter));
            }
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {

            using (var context = new TContex())
            {
                return context.Set<TEntity>().Where(SetFilter(filter)).ToList<TEntity>();
            }
        }

        private Expression<Func<TEntity, bool>> SetFilter(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                Expression<Func<TEntity, bool>> clientWhere = c => true;
                filter = clientWhere;
            }

            //var prefix = filter.Compile();
            //Expression<Func<TEntity, bool>> defaultFilter = c => c.Aktif == true;
            //filter = filter = c => prefix(c) && c.Aktif == true;

            return filter;
        }

        public List<TEntity> GetList(List<string> includes, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContex())
            {
                var query = (filter == null
                    ? context.Set<TEntity>()
                    : context.Set<TEntity>().Where(SetFilter(filter)));

                foreach (var item in includes)
                {
                    query = query.Include(item);
                }

                return query.ToList<TEntity>();
            }
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContex())
            {
                //var query = await (filter == null
                //    ? context.Set<TEntity>().ToListAsync<TEntity>()
                //    : context.Set<TEntity>().Where(filter).ToListAsync<TEntity>());
                //var a = context.Set<TEntity>().Where(SetFilter(filter)).ToSql();
                var query = await context.Set<TEntity>().Where(SetFilter(filter)).ToListAsync<TEntity>();
                return query;
            }
        }

        public virtual async Task<List<TEntity>> GetListAsync(List<string> includes, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContex())
            {
                var query = (filter == null
                    ? context.Set<TEntity>()
                    : context.Set<TEntity>().Where(SetFilter(filter)));

                foreach (var item in includes)
                {
                    query = query.Include(item);
                }

                return await query.ToListAsync<TEntity>();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            using (var context = new TContex())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                //    scope.Complete();
                //}
            }
        }

        //public IQueryable<TEntity> IncludeMany(params Expression<Func<TEntity, object>>[] includes)
        //{
        //    return _entities.IncludeMultiple(includes);
        //}

        //public IEnumerable<TEntity> GetSql(string sql)
        //{
        //    return Entities.FromSql(sql);
        //}


    }
}
