using Calbay.Core.DataAccess;
using Calbay.Core.Entities;
using Calbay.Core.Helper;
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

        public virtual void Add(TEntity entity, UserHelper userHelper)
        {
            if (userHelper == null)
            {
                userHelper = new UserHelper();
            }
            entity.EkleyenId = userHelper.Id;
            entity.EklemeZamani = DateTime.Now;
            entity.GuncelleyenId = userHelper.Id;
            entity.GuncellemeZamani = DateTime.Now;
            entity.Aktif = true;

            _dal.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity, UserHelper userHelper)
        {
            if (userHelper == null)
            {
                userHelper = new UserHelper();
            }

            entity.EkleyenId = userHelper.Id;
            entity.EklemeZamani = DateTime.Now;
            entity.GuncelleyenId = userHelper.Id;
            entity.GuncellemeZamani = DateTime.Now;
            entity.Aktif = true;

            await _dal.AddAsync(entity);
        }

        public virtual void Delete(int id, UserHelper userHelper)
        {
            var entity = GetById(id);
            entity.Aktif = false;
            Update(entity, userHelper);
            //_dal.Delete(new TEntity { Id = id });
        }

        public virtual async Task DeleteAsync(int id, UserHelper userHelper)
        {
            var entity = await GetByIdAsync(id);
            entity.Aktif = false;
            await UpdateAsync(entity, userHelper);
            //await _dal.DeleteAsync(new TEntity { Id = id });
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

        public async Task<GridDto<TEntity>> GetGridAsync(int page, int pageCount, Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dal.GetGridAsync(page, pageCount, null, filter);
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dal.GetList(filter);
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _dal.GetListAsync(filter);
        }

        public virtual async Task SaveAsync(TEntity entity, UserHelper userHelper)
        {
            if (entity.Id == 0)
            {
                await AddAsync(entity, userHelper);
            }
            else
            {
                await UpdateAsync(entity, userHelper);
            }
        }

        public virtual void Update(TEntity entity, UserHelper userHelper)
        {
            if (userHelper == null)
            {
                userHelper = new UserHelper();
            }

            entity.GuncelleyenId = userHelper.Id;
            entity.GuncellemeZamani = DateTime.Now;

            _dal.Update(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity, UserHelper userHelper)
        {
            if (userHelper == null)
            {
                userHelper = new UserHelper();
            }
            entity.GuncelleyenId = userHelper.Id;
            entity.GuncellemeZamani = DateTime.Now;

            await _dal.UpdateAsync(entity);
        }
    }
}
