using Calbay.Core.Business;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IKullaniciServis : IServiceRepository<Kullanici>
    {
        Task<Kullanici> GetWithKisi(int id);
        Task<KullaniciEditDto> GetEditDtoAsync(int? id);
        Task<List<SelectListItem>> GetSelectListAsync(Expression<Func<Kullanici, bool>> filter);
    }
}
