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
    public class BankaManager : ManagerRepositoryBase<Banka>, IBankaServis
    {
        public BankaManager(IBankaDal dal) : base(dal)
        {

        }

        public async Task<List<SelectListItem>> GetSelectListAsync(Expression<Func<Banka, bool>> filter = null)
        {
            List<Banka> tBankalar = (await base.GetListAsync(filter)).OrderBy(i => i.Adi).ToList();
            List<SelectListItem> result = new List<SelectListItem>
            {
                new SelectListItem("Seçiniz", "")
            };
            foreach (var item in tBankalar)
            {
                result.Add(new SelectListItem(item.Adi, item.Id.ToString()));
            }

            return result;
        }
    }
}
