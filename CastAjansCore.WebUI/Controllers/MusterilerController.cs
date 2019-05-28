using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class MusterilerController : Controller
    {
        private readonly IMusteriServis _MusteriServis;

        public MusterilerController(IMusteriServis MusteriServis)
        {
            _MusteriServis = MusteriServis;
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

        // GET: Musteris/DetaMusteris/5
        public async Task<IActionResult> DetaMusteris(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _MusteriServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Musteris/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Musteris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View(new Musteri());
            }
            else
            {
                var entity = await _MusteriServis.GetByIdAsync(id.Value);
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