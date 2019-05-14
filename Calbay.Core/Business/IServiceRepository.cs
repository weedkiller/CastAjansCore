using Calbay.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Calbay.Core.Business
{
    public interface IEntitiyRepository<TList, TEdit>
        where TList : class, IEntity, new()
        where TEdit : class, IEntity, new()
    {
        TEdit Get(Expression<Func<TEdit, bool>> filter = null);

        List<TList> GetList(Expression<Func<TList, bool>> filter = null);

        void Add(TEdit entity);

        void Update(TEdit entity);

        void Delete(int id);
    }
}
