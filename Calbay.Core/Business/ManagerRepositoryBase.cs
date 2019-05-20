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

        public void Add(TEntity entity)
        {
            _dal.Add(entity);
        }

        public virtual Task AddAsync(TEntity entity)
        {
            return _dal.AddAsync(entity);
        }

        public void Delete(int id)
        {
            _dal.Delete(new TEntity { Id = id });
        }

        public Task DeleteAsync(int id)
        {
            return _dal.DeleteAsync(new TEntity { Id = id });
        }

        public void Dispose()
        {
            
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dal.Get(filter);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dal.GetAsync(filter);
        }

        public TEntity GetById(int id)
        {
            return _dal.Get(x => x.Id == id);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _dal.GetAsync(x => x.Id == id);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dal.GetList();
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dal.GetListAsync();
        }

        public void Update(TEntity entity)
        {
            _dal.Update(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
           return _dal.UpdateAsync(entity);
        }
    }
}
