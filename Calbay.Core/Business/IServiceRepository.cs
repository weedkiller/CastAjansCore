using Calbay.Core.Entities;
using Calbay.Core.Helper;
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

        void Add(TEntity entity, UserHelper userHelper);

        void Update(TEntity entity, UserHelper userHelper);

        void Delete(int id, UserHelper userHelper);

        Task AddAsync(TEntity entity, UserHelper userHelper);

        Task UpdateAsync(TEntity entity, UserHelper userHelper);

        Task SaveAsync(TEntity entity, UserHelper userHelper);

        Task DeleteAsync(int id, UserHelper userHelper);

        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);
    }
}
