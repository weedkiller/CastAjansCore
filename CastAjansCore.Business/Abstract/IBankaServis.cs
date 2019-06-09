using Calbay.Core.Business;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IBankaServis : IServiceRepository<Banka>
    {
        Task<List<SelectListItem>> GetSelectListAsync(Expression<Func<Banka, bool>> filter = null);
    }
}
