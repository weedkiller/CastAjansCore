using Calbay.Core.Business;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IUyrukServis : IServiceRepository<Uyruk>
    {
        Task<List<SelectListItem>> GetSelectListAsync(Expression<Func<Uyruk, bool>> filter = null);
    }
}
