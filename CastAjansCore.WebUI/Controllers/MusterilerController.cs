using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class MusterilerController : Controller
    {
        private readonly IMusteriServis _MusteriServis;
        private readonly IIlServis _IlServis;

        public MusterilerController(IMusteriServis MusteriServis, IIlServis IlServis)
        {
            _MusteriServis = MusteriServis;
            _IlServis = IlServis;
        }

        // GET: Musteris
        //public async Task<IActionResult> Index()
        //{
        //    var Musterilar = await _MusteriServis.GetListAsync();
        //    return View(Musterilar);
        //}

        public async Task<IActionResult> Index()
        {
            var Musterilar = await _MusteriServis.GetListAsync();
            return View(Musterilar);
        }


        // GET: Musteris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var entity = new MusteriEditDto();
            entity.Iller = (await _IlServis.GetListAsync(i => i.Aktif == true)).OrderBy(i => i.Adi).ToList();

            if (id == null)
            {
                return View(entity);
            }
            else
            {

                Task<Musteri> tMusteri = _MusteriServis.GetByIdAsync(id.Value);
                
                entity.Musteri = await tMusteri;


                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }
        }

        // POST: Musteris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detaMusteris see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Musteri Musteri)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    Musteri.GuncelleyenId = 1;
                    Musteri.GuncellemeZamani = DateTime.Now;
                    Musteri.Aktif = true;

                    if (id == null || id == 0)
                    {
                        Musteri.EkleyenId = 1;
                        Musteri.EklemeZamani = DateTime.Now;

                        await _MusteriServis.AddAsync(Musteri);
                    }
                    else
                    {
                        if (id != Musteri.Id)
                        {
                            return NotFound();
                        }
                        await _MusteriServis.UpdateAsync(Musteri);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MusteriExistsAsync(Musteri.Id))
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

            return View(Musteri);
        }

        // GET: Musteris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Musteri = await _MusteriServis.GetByIdAsync(id.Value);
            if (Musteri == null)
            {
                return NotFound();
            }

            return View(Musteri);
        }

        // POST: Musteris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _MusteriServis.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MusteriExistsAsync(int id)
        {
            Musteri entity = await _MusteriServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}