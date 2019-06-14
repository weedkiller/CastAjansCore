using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly IKullaniciServis _kullaniciServis;

        public KullanicilarController(IKullaniciServis kullaniciServis)
        {
            _kullaniciServis = kullaniciServis;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            var kullanicilar = await _kullaniciServis.GetListAsync(i => i.Aktif == true);
            return View(kullanicilar.OrderBy(i => i.Kisi.Adi).ThenBy(i => i.Kisi.Soyadi));
        }

        // GET: Kullanicis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
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

        // GET: Kullanicis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, KullaniciEditDto kullaniciEditDto)
        {
            try
            {
                ModelState.Remove("KisiEditDto.Kisi.Ilce.Id");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.IlId");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.Adi");

                if (ModelState.IsValid)
                {
                    try
                    {
                        Kullanici kullanici = kullaniciEditDto.Kullanici;
                        kullanici.Kisi = kullaniciEditDto.KisiEditDto.Kisi;
                        if (id == null)
                        {
                            await _kullaniciServis.AddAsync(kullanici, HttpContext.Session.GetUserHelper());
                        }
                        else
                        {
                            if (id != kullanici.Id)
                            {
                                return NotFound();
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
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            return View(kullaniciEditDto);

        }

        // GET: Kullanicis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
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

        // POST: Kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _kullaniciServis.DeleteAsync(id, HttpContext.Session.GetUserHelper());
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> KullaniciExistsAsync(int id)
        {
            Kullanici entity = await _kullaniciServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}
