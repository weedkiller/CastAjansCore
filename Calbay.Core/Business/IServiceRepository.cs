using Calbay.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calbay.Core.Business
{
    public interface IServiceRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter = null);

        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id); 

        TEntity GetById(int id);
    }
}
