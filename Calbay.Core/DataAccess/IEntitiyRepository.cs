using Calbay.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Calbay.Core.DataAccess
{
    public interface IEntitiyRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        Task<T> GetAsync(Expression<Func<T, bool>> filter = null);

        Task<T> GetAsync(List<string> includes, Expression<Func<T, bool>> filter);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        Task<List<T>> GetListAsync(List<string> includes, Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
