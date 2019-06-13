using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class KullaniciManager : ManagerRepositoryBase<Kullanici>, IKullaniciServis
    {

        private readonly IKisiServis _kisiServis;
        public KullaniciManager(IKullaniciDal dal, IKisiServis kisiServis) : base(dal)
        {
            _kisiServis = kisiServis;
        }

        public override async Task AddAsync(Kullanici entity, UserHelper userHelper)
        {
            await _kisiServis.AddAsync(entity.Kisi, userHelper);
            await base.AddAsync(entity, userHelper);
        }

        public override async Task UpdateAsync(Kullanici entity, UserHelper userHelper)
        {
            Task[] tasks = new Task[2];
            tasks[0] = _kisiServis.UpdateAsync(entity.Kisi, userHelper);
            tasks[1] = base.UpdateAsync(entity, userHelper);

            await Task.WhenAll(tasks);
        }

        public async Task<Kullanici> GetWithKisi(int id)
        {
            return await _dal.GetAsync(new List<string> { "Kisi" }, (x => x.Id == id));
        }

        public async Task<KullaniciEditDto> GetEditDtoAsync(int? id)
        {
            KullaniciEditDto kullaniciEditDto = new KullaniciEditDto();
            Task<KisiEditDto> tKisiEditDto = _kisiServis.GetEditDtoAsync(id);
            if (id == null)
            {
                kullaniciEditDto.KisiEditDto = await tKisiEditDto;
            }
            else
            {
                Task<Kullanici> tkullanici = base.GetByIdAsync(id.Value);

                kullaniciEditDto.Kullanici = await tkullanici;
                kullaniciEditDto.KisiEditDto = await tKisiEditDto;
            }

            return kullaniciEditDto;
        }

        public async Task<List<SelectListItem>> GetSelectListAsync(Expression<Func<Kullanici, bool>> filter = null)
        {
            var tKullaniciler = (await base._dal.GetListAsync(new List<string> { "Kisi" }, filter)).OrderBy(i => i.Kisi.Adi).ThenBy(i => i.Kisi.Soyadi).ToList();
            List<SelectListItem> result = new List<SelectListItem>
            {
                new SelectListItem("Seçiniz", "")
            };
            foreach (var item in tKullaniciler)
            {
                result.Add(new SelectListItem(String.Format("{0} {1}", item.Kisi.Adi, item.Kisi.Soyadi), item.Id.ToString()));
            }

            return result;
        }

        public override async Task DeleteAsync(int id, UserHelper userHelper)
        {
            var entity = await base._dal.GetAsync(new List<string> { "Kisi" }, i => i.Id == id);
            
            entity.Aktif = false;
            entity.Kisi.Aktif = false;

            await UpdateAsync(entity, userHelper);
        }
    }
}
