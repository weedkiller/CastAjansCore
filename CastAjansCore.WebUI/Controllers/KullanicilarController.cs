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
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly IKullaniciServis _kullaniciServis;
        public UserHelper _userHelper
        {
            get
            {
                return HttpContext.Session.GetUserHelper();
            }
            set
            {
                HttpContext.Session.SetUserHelper(value);
            }
        }

        public KullanicilarController(IKullaniciServis kullaniciServis)
        {
            _kullaniciServis = kullaniciServis;
        }

        public IActionResult Login()
        {
            var login = new LoginDto();
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginModel)
        {

            var kullanici = await _kullaniciServis.LoginAsync(loginModel.KullaniciAdi, loginModel.Sifre);
            if (kullanici == null)
            {
                MesajHelper.HataEkle(ViewBag, "Kullanıcı adı veya şifresi yanlış!");
                return View(loginModel);
            }
            else
            {
                HttpContext.Session.SetUserHelper(kullanici);


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, kullanici.Adi),
                    new Claim(ClaimTypes.Surname, kullanici.Soyadi),
                    new Claim(ClaimTypes.Role,kullanici.Rol.ToString())
                };
                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "asd")]
        public async Task<IActionResult> Index()
        {
            ViewData["UserHelper"] = _userHelper;
            var kullanicilar = await _kullaniciServis.GetListAsync(i => i.Aktif == true);
            return View(kullanicilar.OrderBy(i => i.Kisi.Adi).ThenBy(i => i.Kisi.Soyadi));
        }

        [Authorize(Roles = "admin")]
        // GET: Kullanicis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["UserHelper"] = _userHelper;
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

            if (_userHelper.Rol != Enums.EnuRol.admin)
            {
                if (_userHelper.Id != id)
                {
                    return NotFound();
                }
            }

            ViewData["UserHelper"] = _userHelper;
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
                if (_userHelper.Rol != Enums.EnuRol.admin)
                {
                    if (_userHelper.Id != id)
                    {
                        return Forbid();
                    }
                }

                ModelState.Remove("KisiEditDto.Kisi.Ilce.Id");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.IlId");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.Adi");
                ModelState.Remove("KisiEditDto.Sifre");

                if (ModelState.IsValid)
                {
                    try
                    {
                        Kullanici kullanici = kullaniciEditDto.Kullanici;
                        kullanici.Kisi = kullaniciEditDto.KisiEditDto.Kisi;
                        if (kullaniciEditDto.KisiEditDto.KimlikOnFile != null)
                            kullaniciEditDto.KisiEditDto.Kisi.KimlikOnUrl = kullaniciEditDto.KisiEditDto.KimlikOnFile.SaveFile("Kimlikler");

                        if (kullaniciEditDto.KisiEditDto.KimlikArkaFile != null)
                            kullaniciEditDto.KisiEditDto.Kisi.KimlikArkaUrl = kullaniciEditDto.KisiEditDto.KimlikArkaFile.SaveFile("Kimlikler");


                        if (id == null)
                        {
                            await _kullaniciServis.AddAsync(kullanici, HttpContext.Session.GetUserHelper());
                        }
                        else
                        {
                            if (id != kullanici.Id)
                            {
                                return Forbid();
                            }
                            await _kullaniciServis.UpdateAsync(kullanici, HttpContext.Session.GetUserHelper());
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
            ViewData["UserHelper"] = _userHelper;
            return View(kullaniciEditDto);

        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["UserHelper"] = _userHelper;
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
            await _kullaniciServis.DeleteAsync(id, HttpContext.Session.GetUserHelper());
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
        public async Task<IActionResult> SifremiUnuttum(LoginSifremiUnuttum dto)
        {
            //await _kullaniciServis.SifremiUnuttum(dto.EPosta, HttpContext.Session.GetUserHelper());
            //return RedirectToAction(nameof(Index));

            if (ModelState.IsValid)
            {
                Kullanici user = await _kullaniciServis.GetByEPostaAsync(dto.EPosta);

                if (user == null)/* || !(await _kullaniciServis.IsEmailConfirmedAsync(user.Id)))*/
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                await _kullaniciServis.GeneratePasswordResetTokenAsync("localhost:8090", user.Id, _userHelper);

                MesajHelper.MesajEkle(ViewBag, "Mail adresinizden gelen maili onaylayınız.");

                return RedirectToAction("Login", "Kullanicilar");
            }

            // If we got this far, something failed, redisplay form
            return View(dto);
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(LoginSifremiUnuttum dto)
        {
            //await _kullaniciServis.SifremiUnuttum(dto.EPosta, HttpContext.Session.GetUserHelper());
            //return RedirectToAction(nameof(Index));

            if (ModelState.IsValid)
            {
                Kullanici user = await _kullaniciServis.GetByEPostaAsync(dto.EPosta);

                if (user == null)/* || !(await _kullaniciServis.IsEmailConfirmedAsync(user.Id)))*/
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                await _kullaniciServis.GeneratePasswordResetTokenAsync("localhost:8090", user.Id, _userHelper);

                MesajHelper.MesajEkle(ViewBag, "Mail adresinizden gelen maili onaylayınız.");

                return RedirectToAction("Login", "Kullanicilar");
            }

            // If we got this far, something failed, redisplay form
            return View(dto);
        }

        private async Task<bool> KullaniciExistsAsync(int id)
        {
            Kullanici entity = await _kullaniciServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}
