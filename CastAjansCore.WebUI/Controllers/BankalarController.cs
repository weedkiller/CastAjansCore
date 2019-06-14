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
    public class BankalarController : Controller
    {
        private readonly IBankaServis _BankaServis;

        public BankalarController(IBankaServis BankaServis)
        {
            _BankaServis = BankaServis;
        }

        // GET: Bankas
        //public async Task<IActionResult> Index()
        //{
        //    var Bankalar = await _BankaServis.GetListAsync();
        //    return View(Bankalar);
        //}

        public async Task<IActionResult> Index()
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            var Bankalar = await _BankaServis.GetListAsync();
            return View(Bankalar);
        }
        
        // GET: Bankas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            if (id == null)
            {
                return View(new Banka());
            }
            else
            {
                var entity = await _BankaServis.GetByIdAsync(id.Value);
                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }
        }

        // POST: Bankas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detaBankas see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Banka Banka)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Banka.GuncelleyenId = 1;
                    //Banka.GuncellemeZamani = DateTime.Now;
                    //Banka.Aktif = true;

                    if (id == null || id == 0)
                    {
                        //Banka.EkleyenId = 1;
                        //Banka.EklemeZamani = DateTime.Now;

                        await _BankaServis.AddAsync(Banka, HttpContext.Session.GetUserHelper());
                    }
                    else
                    {
                        if (id != Banka.Id)
                        {
                            return NotFound();
                        }
                        await _BankaServis.UpdateAsync(Banka, HttpContext.Session.GetUserHelper());
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BankaExistsAsync(Banka.Id))
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

            return View(Banka);
        }

        // GET: Bankas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            if (id == null)
            {
                return NotFound();
            }

            var Banka = await _BankaServis.GetByIdAsync(id.Value);
            if (Banka == null)
            {
                return NotFound();
            }

            return View(Banka);
        }

        // POST: Bankas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _BankaServis.DeleteAsync(id, HttpContext.Session.GetUserHelper());
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BankaExistsAsync(int id)
        {
            Banka entity = await _BankaServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}