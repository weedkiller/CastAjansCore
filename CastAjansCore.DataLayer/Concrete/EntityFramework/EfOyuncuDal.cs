using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Calbay.Core.DataAccess;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace CastAjansCore.DataLayer.Concrete.EntityFramework
{
    public class EfOyuncuDal : EfEntityRepositoryBase<Oyuncu, CastAjansContext>, IOyuncuDal
    {
        public override async Task<List<Oyuncu>> GetListAsync(Expression<Func<Oyuncu, bool>> filter = null)
        {
            using (var context = new CastAjansContext())
            {
                var query = (filter == null
                    ? context.Oyuncular
                    : context.Oyuncular.Where(filter));

                query = query.Include(i => i.Kisi);
                query = query.Include(i => i.Kisi.Uyruk);
                query = query.Include(i => i.OyuncuResimleri);

                return await query.ToListAsync<Oyuncu>();
            }
        }
    }
}
