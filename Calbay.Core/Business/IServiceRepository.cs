using Calbay.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Calbay.Core.Business
{
    public interface IServiceRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null);

        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);

        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);

        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);
    }
}
