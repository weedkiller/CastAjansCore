using Calbay.Core.Entities;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly IKullaniciServis _kullaniciServis;
        private readonly LoginHelper _loginHelper;

        public KullanicilarController(IKullaniciServis kullaniciServis, LoginHelper loginHelper)
        {
            _kullaniciServis = kullaniciServis;
            _loginHelper = loginHelper;
            ViewData["UserHelper"] = _loginHelper.UserHelper;
        }

        public IActionResult Login()
        {
            var login = new LoginDto();
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginModel)
        {
            var userHelper = await _kullaniciServis.LoginAsync(loginModel.KullaniciAdi, loginModel.Sifre);
            if (userHelper == null)
            {
                MesajHelper.HataEkle(ViewBag, "Kullanıcı adı veya şifresi yanlış!");
                return View(loginModel);
            }
            else
            {
                await _loginHelper.Login(userHelper);
                //Just redirect to our index after logging in. 
                return RedirectToAction("Index", "Home");
            }
        }



        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {

            var kullanicilar = await _kullaniciServis.GetListAsync(i => i.Aktif == true);
            return View(kullanicilar.OrderBy(i => i.Kisi.Adi).ThenBy(i => i.Kisi.Soyadi));
        }

        [Authorize(Roles = "admin")]
        // GET: Kullanicis/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var entity = await _kullaniciServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [Authorize(Roles = "admin,calisan")]
        // GET: Kullanicis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (_loginHelper.UserHelper.Rol != EnuRol.admin)
            {
                if (_loginHelper.UserHelper.Id != id)
                {
                    return NotFound();
                }
            }


            KullaniciEditDto model = await _kullaniciServis.GetEditDtoAsync(id);

            if (model.Kullanici == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Kullanicis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin,calisan")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, KullaniciEditDto kullaniciEditDto)
        {
            try
            {
                if (_loginHelper.UserHelper.Rol != EnuRol.admin)
                {
                    if (_loginHelper.UserHelper.Id != id)
                    {
                        return Forbid();
                    }
                }

                ModelState.Remove("KisiEditDto.Kisi.Ilce.Id");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.IlId");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.Adi");
                ModelState.Remove("Kullanici.Sifre");
                if (kullaniciEditDto.KisiEditDto.Kisi.EPosta == null || kullaniciEditDto.KisiEditDto.Kisi.EPosta == "")
                {
                    ModelState.AddModelError("KisiEditDto.Kisi.EPosta", "E-Posta Alanı Zorunludur.");
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        Kullanici kullanici = kullaniciEditDto.Kullanici;
                        kullanici.Kisi = kullaniciEditDto.KisiEditDto.Kisi;
                        if (kullaniciEditDto.KisiEditDto.ProfilFotoFile != null)
                            kullaniciEditDto.KisiEditDto.Kisi.ProfilFotoUrl = kullaniciEditDto.KisiEditDto.ProfilFotoFile.SaveFile("OyuncuResimleri");

                        if (kullaniciEditDto.KisiEditDto.KimlikOnFile != null)
                            kullaniciEditDto.KisiEditDto.Kisi.KimlikOnUrl = kullaniciEditDto.KisiEditDto.KimlikOnFile.SaveFile("Kimlikler");

                        if (kullaniciEditDto.KisiEditDto.KimlikArkaFile != null)
                            kullaniciEditDto.KisiEditDto.Kisi.KimlikArkaUrl = kullaniciEditDto.KisiEditDto.KimlikArkaFile.SaveFile("Kimlikler");


                        if (id == null)
                        {
                            await _kullaniciServis.AddAsync(kullanici, _loginHelper.UserHelper);
                        }
                        else
                        {
                            if (id != kullanici.Id)
                            {
                                return Forbid();
                            }
                            await _kullaniciServis.UpdateAsync(kullanici, _loginHelper.UserHelper);
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await KullaniciExistsAsync(kullaniciEditDto.Kullanici.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    MesajHelper.HataEkle(ViewBag, ModelState);
                }
                var combolar = await _kullaniciServis.GetEditDtoAsync(id);
                kullaniciEditDto.KisiEditDto.Ilceler = combolar.KisiEditDto.Ilceler;
                kullaniciEditDto.KisiEditDto.Iller = combolar.KisiEditDto.Iller;
                kullaniciEditDto.KisiEditDto.Uyruklar = combolar.KisiEditDto.Uyruklar;
            }
            catch (Exception ex)
            {
                MesajHelper.HataEkle(ViewBag, ex.Message);
            }

            return View(kullaniciEditDto);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var kullanici = await _kullaniciServis.GetByIdAsync(id.Value);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _kullaniciServis.DeleteAsync(id, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Index));
        }

        // GET: Kullanicis/Edit/5
        public IActionResult AccessDenied(int? id)
        {
            return View(model: Request.Query["ReturnUrl"].ToString());
        }

        // GET: Kullanicis/Edit/5
        public IActionResult SifremiUnuttum()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SifremiUnuttum(LoginSifremiUnuttumDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Kullanici user = await _kullaniciServis.GetByEPostaAsync(dto.EPosta);

                    if (user == null)/* || !(await _kullaniciServis.IsEmailConfirmedAsync(user.Id)))*/
                    {
                        MesajHelper.HataEkle(ViewBag, "Kullanıcı adı bulunamadı.");
                        return View(new LoginSifremiUnuttumDto { EPosta = dto.EPosta });
                    }

                    await _kullaniciServis.SifreUretmeTokeniUret(user.Id, null);

                    MesajHelper.MesajEkle(ViewBag, "E-Posta adresinize gelen maili onaylayınız.");

                    return RedirectToAction("ResetPassword", "Kullanicilar", new { id = user.Id });
                }
            }
            catch (Exception ex)
            {
                MesajHelper.HataEkle(ViewBag, ex.Message);
            }

            return View(dto);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(int id, string code)
        {
            if (id == 0)
            {
                return View(new ResetPasswordDto { Kendim = true }); ;
            }

            Kullanici user = await _kullaniciServis.GetByIdAsync(id);

            if (user == null && (code.IsNull() || user.Token.Equals(code)))
            {
                MesajHelper.HataEkle(ViewBag, "Kullanıcı bulunamadı.");
                return RedirectToAction("SifremiUnuttum");
            }
            else if (code.IsNotNull() && !user.Token.Equals(code))
            {
                MesajHelper.HataEkle(ViewBag, "Kod geçersiz.");
                return RedirectToAction("SifremiUnuttum");
            }
            else
            {
                return View(new ResetPasswordDto { Code = code, Kendim = false });
            }
        }

        //[Authorize(Roles = "admin,calisan")]
        //public IActionResult ResetPassword()
        //{
        //    return View(new ResetPasswordDto());
        //}

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(int? id, ResetPasswordDto model)
        {
            try
            {
                if (id == null)
                {
                    ModelState.Remove("Code");
                }
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {

                    //var user = await _kullaniciServis.GetByTokenAsync(model.Code);
                    int userId;
                    if (id != null)
                    {
                        userId = id.Value;
                    }
                    else
                    {
                        userId = _loginHelper.UserHelper.Id;
                    }

                    var user = await _kullaniciServis.GetByIdAsync(userId);
                    if (id != null && user == null && model.Code != user.Token)
                    {
                        MesajHelper.HataEkle(ViewBag, "Yanlış kod girdiniz.");
                        return View();
                    }


                    await _kullaniciServis.SifreyiGuncelleAsync(userId, model.Sifre, null);
                    MesajHelper.MesajEkle(ViewBag, "Şifreniz başrıyla güncellenmiştir.");
                    var userHelper = await _kullaniciServis.LoginAsync(user.KullaniciAdi, model.Sifre);
                    await _loginHelper.Login(userHelper);
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception ex)
            {
                MesajHelper.HataEkle(ViewBag, ex.Message);
            }

            return View();
        }

        private async Task<bool> KullaniciExistsAsync(int id)
        {
            Kullanici entity = await _kullaniciServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}
