using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Calbay.Core.DataAccess;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace CastAjansCore.DataLayer.Concrete.EntityFramework
{
    public class EfKullaniciDal : EfEntityRepositoryBase<Kullanici, CastAjansContext>, IKullaniciDal
    {
        public override List<Kullanici> GetList(Expression<Func<Kullanici, bool>> filter = null)
        {
            using (var context = new CastAjansContext())
            {
                var query = filter == null
                    ? context.Set<Kullanici>()
                    : context.Set<Kullanici>().Where(filter);

                return query.Include("Kisi").ToList<Kullanici>();
            }
        }
    }
}
