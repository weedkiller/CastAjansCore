using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CastAjansCore.Business.Concrete
{
    public class IlManager : ManagerRepositoryBase<Il>, IIlServis
    {
        public IlManager(IIlDal dal) : base(dal)
        {

        }

        public async Task<List<SelectListItem>> GetSelectListAsync(Expression<Func<Il, bool>> filter = null)
        {
            var tIller = (await base.GetListAsync(filter)).OrderBy(i => i.Adi).ToList();
            List<SelectListItem> result = new List<SelectListItem>
            {
                new SelectListItem("Seçiniz", "")
            };
            foreach (var item in tIller)
            {
                result.Add(new SelectListItem(item.Adi, item.Id.ToString()));
            }

            return result;
        }
    }
}
