using Calbay.Core.Business;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IIlceServis : IServiceRepository<Ilce>
    {
        Task<List<SelectListItem>> GetSelectListAsync(Expression<Func<Ilce, bool>> filter = null);
    }
}
