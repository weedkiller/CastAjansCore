using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CastAjansCore.WebUI.Controllers
{
    public class UyruklarController : Controller
    {
        private readonly IUyrukServis _UyrukServis;

        public UyruklarController(IUyrukServis UyrukServis)
        {
            _UyrukServis = UyrukServis;
        }

        // GET: Uyruks
        //public async Task<IActionResult> Index()
        //{
        //    var Uyruklar = await _UyrukServis.GetListAsync();
        //    return View(Uyruklar);
        //}

        public async Task<IActionResult> Index()
        {
            var Uyruklar = await _UyrukServis.GetListAsync();
            return View(Uyruklar);
        }

        // GET: Uyruks/DetaUyruks/5
        public async Task<IActionResult> DetaUyruks(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _UyrukServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

         

        // GET: Uyruks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View(new Uyruk());
            }
            else
            {
                var entity = await _UyrukServis.GetByIdAsync(id.Value);
                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }
        }

        // POST: Uyruks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detaUyruks see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Uyruk Uyruk)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    //Uyruk.GuncelleyenId = 1;
                    //Uyruk.GuncellemeZamani = DateTime.Now;
                    //Uyruk.Aktif = true;

                    if (id == null || id == 0)
                    {
                        //Uyruk.EkleyenId = 1;
                        //Uyruk.EklemeZamani = DateTime.Now;

                        await _UyrukServis.AddAsync(Uyruk);
                    }
                    else
                    {
                        if (id != Uyruk.Id)
                        {
                            return NotFound();
                        }
                        await _UyrukServis.UpdateAsync(Uyruk);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UyrukExistsAsync(Uyruk.Id))
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

            return View(Uyruk);
        }

        // GET: Uyruks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Uyruk = await _UyrukServis.GetByIdAsync(id.Value);
            if (Uyruk == null)
            {
                return NotFound();
            }

            return View(Uyruk);
        }

        // POST: Uyruks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _UyrukServis.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UyrukExistsAsync(int id)
        {
            Uyruk entity = await _UyrukServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}