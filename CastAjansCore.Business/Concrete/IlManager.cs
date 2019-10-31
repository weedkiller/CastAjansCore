using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class IlManager : ManagerRepositoryBase<Il>, IIlServis
    {
        public IlManager(IIlDal dal) : base(dal)
        {

        }

        public async Task<List<SelectListItem>> GetSelectListAsync(Expression<Func<Il, bool>> filter = null)
        {
            var result = (await base.GetListAsync(filter))
                .Select(i => new
                {
                    Id = i.Id,
                    Adi = i.Adi,
                    Order = i.Adi == "İSTANBUL" ? 0 : 99
                })
                .OrderBy(i => i.Order)
                .ThenBy(i => i.Adi)
                .Select(i => new SelectListItem(i.Adi, i.Id.ToString()))
                .ToList();

            result.Insert(0, new SelectListItem("Seçiniz", ""));
            //List<SelectListItem> result = new List<SelectListItem>
            //{
            //    new SelectListItem("Seçiniz", "")
            //};
            //foreach (var item in tIller)
            //{
            //    result.Add(new SelectListItem(item.Adi, item.Id.ToString()));
            //}

            return result;
        }
    }
}
