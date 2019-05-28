using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly IKullaniciServis _kullaniciServis;
        private readonly IUyrukServis _uyrukServis;
        private readonly IKisiServis _kisiServis;

        public KullanicilarController(IKullaniciServis kullaniciServis, IKisiServis kisiServis, IUyrukServis uyrukServis)
        {
            _kullaniciServis = kullaniciServis;
            _uyrukServis = uyrukServis;
            _kisiServis = kisiServis;
        }

        // GET: Kullanicis
        //public async Task<IActionResult> Index()
        //{
        //    var kullanicilar = await _kullaniciServis.GetListAsync();
        //    return View(kullanicilar);
        //}

        public async Task<IActionResult> Index()
        {
            var kullanicilar = await _kullaniciServis.GetListAsync();
            return View(kullanicilar);
        }

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

        // GET: Kullanicis/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Kullanicis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        { 
            Task<List<Uyruk>> tUyruk = _uyrukServis.GetListAsync();

            KullaniciEditDto model = new KullaniciEditDto();
            model.Kisi = new KisiEditDto();
            if (id == null)
            {
                
            }
            else
            {
                Task<Kullanici> tKullanici = _kullaniciServis.GetByIdAsync(id.Value);
                Task<Kisi> tkisi = _kisiServis.GetByIdAsync(id.Value);

                model.Kullanici = await tKullanici;
                model.Kisi.Kisi = await tkisi;                
                if (model.Kullanici == null)
                {
                    return NotFound();
                }
            }
            model.Kisi.Uyruklar.Add(new SelectListItem("Seçiniz", ""));

            //await Task.WhenAll(tkisi, tKullanici, tUyruk);
            foreach (var item in await tUyruk)
            {
                model.Kisi.Uyruklar.Add(new SelectListItem(item.Adi, item.Id.ToString()));
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
            if (ModelState.IsValid)
            {
                try
                {
                    Kullanici kullanici = kullaniciEditDto.Kullanici;
                    kullanici.Kisi = kullaniciEditDto.Kisi.Kisi;
                    if (id == null)
                    {
                        await _kullaniciServis.AddAsync(kullanici);
                    }
                    else
                    {
                        if (id != kullanici.Id)
                        {
                            return NotFound();
                        }
                        await _kullaniciServis.UpdateAsync(kullanici);
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

            return View(kullaniciEditDto);
        }

        // GET: Kullanicis/Delete/5
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

        // POST: Kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _kullaniciServis.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> KullaniciExistsAsync(int id)
        {
            Kullanici entity = await _kullaniciServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}
