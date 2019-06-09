using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CastAjansCore.Dto;
using System.Linq.Expressions;

namespace CastAjansCore.WebUI.Controllers
{
    public class ProjelerController : Controller
    {
        private readonly IProjeServis _ProjeServis;
        private readonly IMusteriServis _MusteriServis;
        private readonly IKullaniciServis _KullaniciServis;

        public ProjelerController(IProjeServis ProjeServis, IMusteriServis MusteriServis, IKullaniciServis KullaniciServis)
        {
            _ProjeServis = ProjeServis;
            _MusteriServis = MusteriServis;
            _KullaniciServis = KullaniciServis;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ProjeListDto ProjeListDto = new ProjeListDto();
            Task<Musteri> tMusteri = _MusteriServis.GetByIdAsync(id.Value);
            Task<List<Proje>> tProje = _ProjeServis.GetListAsync(i => (id == null || i.MusteriId == id));

            ProjeListDto.Musteri = await tMusteri;
            ProjeListDto.Projeler = await tProje;

            return View(ProjeListDto);
        }

        // GET: Projes/Edit/5
        public async Task<IActionResult> Edit(int? id, int musteriId)
        {
            var tMusteri = _MusteriServis.GetByIdAsync(musteriId);
            var projeEditDto = new ProjeEditDto
            {
                Kullanicilar = await _KullaniciServis.GetSelectListAsync(i => i.Kisi.Aktif == true)
            };

            if (id == null)
            {
                projeEditDto.Proje = new Proje { Musteri = await tMusteri, MusteriId = musteriId };

                return View(projeEditDto);
            }
            else
            {   
                projeEditDto.Proje = await _ProjeServis.GetByIdAsync(id.Value);
                projeEditDto.Proje.Musteri = await tMusteri;
                if (projeEditDto.Proje == null)
                {
                    return NotFound();
                }

                return View(projeEditDto);
            }
        }

        // POST: Projes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detaProjes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Proje Proje)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == null || id == 0)
                    {
                        await _ProjeServis.AddAsync(Proje, HttpContext.Session.GetUserHelper());
                    }
                    else
                    {
                        if (id != Proje.Id)
                        {
                            return NotFound();
                        }
                        await _ProjeServis.UpdateAsync(Proje, HttpContext.Session.GetUserHelper());
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProjeExistsAsync(Proje.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index) + "/" + Proje.MusteriId);
            }

            return View(Proje);
        }

        // GET: Projes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Proje = await _ProjeServis.GetByIdAsync(id.Value);
            if (Proje == null)
            {
                return NotFound();
            }

            return View(Proje);
        }

        // POST: Projes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ProjeServis.DeleteAsync(id, HttpContext.Session.GetUserHelper());
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProjeExistsAsync(int id)
        {
            Proje entity = await _ProjeServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}