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

        public ProjelerController(IProjeServis ProjeServis,IMusteriServis MusteriServis, IKullaniciServis KullaniciServis)
        {
            _ProjeServis = ProjeServis;
            _MusteriServis = MusteriServis;
            _KullaniciServis = KullaniciServis;
        }
        
        public async Task<IActionResult> Index(int? id)
        {
            ProjeListDto ProjeListDto = new ProjeListDto();
            if (id != null)
            {
                Task<Musteri> tMusteri = _MusteriServis.GetByIdAsync(id.Value);
            }
            Expression<Proje> expression;
            expression.fun                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          (i=>i.)
            Task<List<Proje>> tProje = _ProjeServis.GetListAsync(i => i.MusteriId == id);

            ProjeListDto.Il = await tIl;
            ProjeListDto.Projeler = await tProje;

            return View(ProjeListDto);
        }

        public async Task<JsonResult> GetJson(int id)
        {

            Task<List<Proje>> tProje = _ProjeServis.GetListAsync(i => i.IlId == id);
            var Projeler = await tProje;
            return Json(Projeler);
        }

        // GET: Projes/DetaProjes/5
        public async Task<IActionResult> DetaProjes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _ProjeServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Projes/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Projes/Edit/5
        public async Task<IActionResult> Edit(int? id, int ilId)
        {

            if (id == null)
            {
                var il = await _KullaniciServis.GetByIdAsync(ilId);
                return View(new Proje { IlId = ilId, Il = il });
            }
            else
            {

                var entity = await _ProjeServis.GetByIdAsync(id.Value);
                entity.Il = await _KullaniciServis.GetByIdAsync(entity.IlId);

                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
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
                        await _ProjeServis.AddAsync(Proje);
                    }
                    else
                    {
                        if (id != Proje.Id)
                        {
                            return NotFound();
                        }
                        await _ProjeServis.UpdateAsync(Proje);
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
                return RedirectToAction(nameof(Index) + "/" + Proje.IlId);
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
            await _ProjeServis.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProjeExistsAsync(int id)
        {
            Proje entity = await _ProjeServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}