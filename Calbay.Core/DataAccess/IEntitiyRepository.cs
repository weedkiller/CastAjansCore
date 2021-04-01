using Calbay.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Calbay.Core.DataAccess
{
    public interface IEntitiyRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetAsync(List<string> includes, Expression<Func<TEntity, bool>> filter);

        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);

        List<TEntity> GetList(List<string> includes, Expression<Func<TEntity, bool>> filter = null);

        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<List<TEntity>> GetListAsync(List<string> includes, Expression<Func<TEntity, bool>> filter = null);

        //Task<GridDto<T>> GetGridAsync(int start = 0, int pageSize = 0, List<string> includes = null, Expression<Func<T, bool>> filter = null);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
        
    }
}
