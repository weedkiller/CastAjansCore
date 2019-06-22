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
using static Calbay.Core.Entities.Enums;

namespace CastAjansCore.Business.Concrete
{
    public class KullaniciManager : ManagerRepositoryBase<Kullanici>, IKullaniciServis
    {

        private readonly IKisiServis _kisiServis;
        private readonly IEmailServis _emailServis;
        public KullaniciManager(IKullaniciDal dal, IKisiServis kisiServis, IEmailServis emailServis) : base(dal)
        {
            _kisiServis = kisiServis;
            _emailServis = emailServis;
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

        public async Task<UserHelper> LoginAsync(string kullaniciAdi, string sifre)
        {
            var kullanici = await _dal.GetAsync(new List<string> { "Kisi" }, i => i.KullaniciAdi == kullaniciAdi && i.Sifre == sifre);
            if (kullanici == null)
            {
                return null;
            }
            else
            {
                UserHelper userHelper = new UserHelper
                {
                    Id = kullanici.Id,
                    Adi = kullanici.Kisi.Adi,
                    Soyadi = kullanici.Kisi.Soyadi,
                    KullaniciAdi = kullanici.KullaniciAdi,
                    Rol = EnuRol.admin,
                    Menuler = GetMenu(EnuRol.admin)
                };
                return userHelper;
            }


        }

        private List<MenuDto> GetMenu(EnuRol rol)
        {
            var Menuler = new List<MenuDto>();
            switch (rol)
            {
                case EnuRol.admin:


                    Menuler.Add(new MenuDto { Adi = "Müşteriler", Icon = "mi-local-play", Link = " /Musteriler" });
                    Menuler.Add(new MenuDto { Adi = "Oyuncular", Icon = "mi-people", Link = "/Oyuncular" });
                    Menuler.Add(new MenuDto { Adi = "Projelerim", Icon = "mi-shop", Link = " /Projeler" });
                    Menuler.Add(new MenuDto
                    {
                        Adi = "Sistem",
                        Icon = "mi-settings",
                        Link = "#",
                        AltMenuler = new List<MenuDto> {
                                 new MenuDto { Adi = "Bankalar", Link = "/Bankalar" } ,
                                 new MenuDto{ Adi="Firmalar", Link="/Firmalar" },
                                 new MenuDto { Adi = "İller", Link = "/Iller" } ,
                                 new MenuDto{ Adi="Kullanıcılar", Link="/Kullanicilar" },
                                 new MenuDto{ Adi="Uyruklar", Link="/Uyruklar" }
                            }
                    });
                    break;
                case EnuRol.calisan:
                    Menuler.Add(new MenuDto { Adi = "Müşteriler", Icon = "mi-local-play", Link = "/Musteriler" });
                    Menuler.Add(new MenuDto { Adi = "Oyuncular", Icon = "mi-people", Link = "/Oyuncular" });
                    Menuler.Add(new MenuDto { Adi = "Projelerim", Icon = "mi-shop", Link = " /Projeler" });
                    break;
                default:
                    break;
            }
            return Menuler;
        }

        public Task<string> SifremiUnuttum(string ePosta, UserHelper userHelper)
        {
            throw new NotImplementedException();
        }

        public async Task<Kullanici> GetByEPostaAsync(string ePosta)
        {
            return await _dal.GetAsync(new List<string> { "Kisi" }, x => x.Kisi.EPosta == ePosta && x.Kisi.Aktif == true);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string url, int id, UserHelper userHelper)
        {
            var kullanici = await GetByIdAsync(id);
            kullanici.Token = Guid.NewGuid().ToString(); ;

            var tUpdate = UpdateAsync(kullanici, userHelper);
            var callbackUrl = $"{url}/Kullanicilar/ResetPassword/{id}?code={kullanici.Token}";            
            var tMail = _emailServis.SendEmailAsync(kullanici.Kisi.EPosta, "Şifre Sıfırlama", $"Şifrenizi sıfırlamak için <a href=\"{callbackUrl}\">here</a> tıklayınız.");

            return "";
        }
    }
}
