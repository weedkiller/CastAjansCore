using Calbay.Core.Business;
using Calbay.Core.Entities;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class KullaniciManager : ManagerRepositoryBase<Kullanici>, IKullaniciServis
    {

        private readonly IKisiServis _kisiServis;
        private readonly IEmailServis _emailServis;
        private readonly IOptions<ParamereSettings> _paramereSettings;
        private readonly UserHelper _userHelper;
        public KullaniciManager(IKullaniciDal dal, IKisiServis kisiServis, IEmailServis emailServis, IOptions<ParamereSettings> paramereSettings) : base(dal)
        {
            _kisiServis = kisiServis;
            _emailServis = emailServis;
            _paramereSettings = paramereSettings;


        }

        private async Task Kontrol(Kullanici entity)
        {

            var tKullaniciAdi = GetAsync(i => (entity.Id == 0 || i.Id != entity.Id) && i.KullaniciAdi == entity.KullaniciAdi && i.Aktif == true && i.Kisi.Aktif == true);

            if (await tKullaniciAdi != null)
            {
                throw new Exception($"{entity.KullaniciAdi} kullanıcı adıyla kayıt mevcuttur.");
            }
        }

        public override async Task AddAsync(Kullanici entity, UserHelper userHelper)
        {
            await Kontrol(entity);
            Random rnd = new Random();
            entity.Sifre = rnd.Next(1200, 9980).ToString();
            entity.Token = entity.Sifre;


            await _kisiServis.AddAsync(entity.Kisi, userHelper);
            await base.AddAsync(entity, userHelper);
            //ResetlemeMailiGonder(entity.Id, entity.Token, entity.Kisi.EPosta);
        }

        public override async Task UpdateAsync(Kullanici entity, UserHelper userHelper)
        {
            await Kontrol(entity);
            var kullanici = await GetByIdAsync(entity.Id);
            if (entity.Sifre.IsNull())
            {
                entity.Sifre = kullanici.Sifre;
            }
            if (entity.Token.IsNull())
            {
                entity.Token = kullanici.Token;
            }

            if (userHelper.IsNull())
            {
                userHelper = new UserHelper();
            }
            Task[] tasks = new Task[2];
            if (entity.Kisi.IsNull())
            {
                tasks[0] = Task.CompletedTask;
            }
            else
            {
                tasks[0] = _kisiServis.UpdateAsync(entity.Kisi, userHelper);
            }

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
                return GetUserHelper(kullanici);
            }
        }

        public UserHelper GetUserHelper(Kullanici kullanici)
        {
            UserHelper userHelper = new UserHelper
            {
                Id = kullanici.Id,
                Adi = kullanici.Kisi.Adi,
                Soyadi = kullanici.Kisi.Soyadi,
                KullaniciAdi = kullanici.KullaniciAdi,
                Rol = kullanici.Rol,
                Menuler = GetMenu(kullanici.Rol)
            };
            return userHelper;
        }



        private List<MenuDto> GetMenu(EnuRol rol)
        {
            List<MenuDto> Menuler = new List<MenuDto>
            {
                new MenuDto { Adi = "Müşteriler", Icon = "mi-local-play", Renk="success", Link = "/Musteriler" },
                new MenuDto { Adi = "Oyuncular", Icon = "mi-people", Renk = "warning",Link = "/Oyuncular" },
                new MenuDto { Adi = "Projelerim", Icon = "mi-shop", Renk = "blue", Link = " /Projeler" }
            };

            if (rol == EnuRol.admin)
            {
                Menuler.Add(new MenuDto
                {
                    Adi = "Sistem",
                    Icon = "mi-settings",
                    Link = "#",
                    AltMenuler = new List<MenuDto> {
                                 new MenuDto { Adi = "Bankalar", Link = "/Bankalar" } ,
                                 //new MenuDto{ Adi="Firmalar", Link="/Firmalar" },
                                 new MenuDto { Adi = "İller", Link = "/Iller" } ,
                                 new MenuDto{ Adi="Kullanıcılar", Link="/Kullanicilar" },
                                 new MenuDto{ Adi="Uyruklar", Link="/Uyruklar" }
                            }
                });
            }

            return Menuler;
        }

        public Task<string> SifremiUnuttum(string ePosta, UserHelper userHelper)
        {
            throw new NotImplementedException();
        }

        public async Task<Kullanici> GetByEPostaAsync(string ePosta)
        {
            var kisi = await _kisiServis.GetAsync(i => i.EPosta == ePosta);

            return await _dal.GetAsync(new List<string> { "Kisi" }, x => x.Kisi.EPosta.Equals(ePosta) && x.Kisi.Aktif == true);
        }

        private void ResetlemeMailiGonder(int id, string token, string ePosta)
        {

            string callbackUrl = $"{_paramereSettings.Value.Url}/Kullanicilar/ResetPassword/{id}?code={token}";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("   <head></head>");
            sb.AppendLine("  <body>");
            sb.AppendLine("      <p><h3>Şifrenizi sıfırlamak için aşağıdaki kodu giriniz.</h3></p>");
            sb.AppendLine($"      <p><h2>{token}</h2></p>");
            sb.AppendLine($"      <p>veya şifrenizi sıfırlamak için <a href='{callbackUrl}'>tıklayınız.</a></p>");
            sb.AppendLine("  </body>");
            sb.AppendLine("</html>");


            _emailServis.SendEmail(ePosta, "Şifre Sıfırlama", sb.ToString());
        }

        public async Task<string> SifreUretmeTokeniUret(int id, UserHelper userHelper)
        {
            var kullanici = await GetWithKisi(id);
            Random rnd = new Random();
            kullanici.Token = rnd.Next(123456, 987654).ToString();//Guid.NewGuid().ToString(); ;

            Task tUpdate = UpdateAsync(kullanici, userHelper);

            ResetlemeMailiGonder(kullanici.Id, kullanici.Token, kullanici.Kisi.EPosta);
            await tUpdate;

            return "";
        }

        public async Task<Kullanici> GetByTokenAsync(string code)
        {
            return await GetAsync(i => i.Token.Equals(code) && i.Aktif == true && i.Kisi.Aktif == true);
        }

        public async Task SifreyiGuncelleAsync(int id, string sifre, UserHelper userHelper)
        {
            var kisi = await GetByIdAsync(id);
            kisi.Sifre = sifre;
            await UpdateAsync(kisi, userHelper ?? new UserHelper());
        }
    }
}
