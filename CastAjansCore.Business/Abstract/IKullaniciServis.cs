using Calbay.Core.Business;
using Calbay.Core.Helper;
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
        Task<List<SelectListItem>> GetSelectListAsync(Expression<Func<Kullanici, bool>> filter = null);
        Task<UserHelper> LoginAsync(string kullaniciAdi, string sifre);
        Task<string> SifremiUnuttum(string ePosta, UserHelper userHelper);        
        Task<Kullanici> GetByEPostaAsync(string ePosta);
        Task<string> GeneratePasswordResetTokenAsync(string url, int id, UserHelper userHelper);
    }
}
