using Calbay.Core.DataAccess;
using Calbay.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Calbay.Core.Business
{
    public class ManagerRepositoryBase<TEntity> : IServiceRepository<TEntity>, IDisposable
        where TEntity : class, IEntity, new()        
        //where TDal : class, IEntitiyRepository<TEntity>, new()
    {
        public IEntitiyRepository<TEntity> _dal;
        public ManagerRepositoryBase(IEntitiyRepository<TEntity> dal)
        {
            _dal = dal;
        }

        public virtual void Add(TEntity entity)
        {
            _dal.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dal.AddAsync(entity);
        }

        public virtual void Delete(int id)
        {
            _dal.Delete(new TEntity { Id = id });
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _dal.DeleteAsync(new TEntity { Id = id });
        }

        public void Dispose()
        {          
            GC.SuppressFinalize(this);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dal.Get(filter);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dal.GetAsync(filter);
        }

        public virtual TEntity GetById(int id)
        {
            return _dal.Get(x => x.Id == id);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dal.GetAsync(x => x.Id == id);
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dal.GetList();
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dal.GetListAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _dal.Update(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _dal.UpdateAsync(entity);
        }
    }
}
