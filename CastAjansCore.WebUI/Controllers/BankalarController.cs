using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class BankalarController : Controller
    {
        private readonly IBankaServis _BankaServis;
        private readonly LoginHelper _loginHelper;

        public BankalarController(IBankaServis BankaServis, LoginHelper loginHelper)
        {
            _BankaServis = BankaServis;
            _loginHelper = loginHelper;
            ViewData["UserHelper"] = _loginHelper.UserHelper;
        }

        // GET: Bankas
        //public async Task<IActionResult> Index()
        //{
        //    var Bankalar = await _BankaServis.GetListAsync();
        //    return View(Bankalar);
        //}

        public async Task<IActionResult> Index()
        {            
            var Bankalar = await _BankaServis.GetListAsync(i=> i.Aktif);
            return View(Bankalar);
        }

        // GET: Bankas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {            
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

                        await _BankaServis.AddAsync(Banka, _loginHelper.UserHelper);
                    }
                    else
                    {
                        if (id != Banka.Id)
                        {
                            return NotFound();
                        }
                        await _BankaServis.UpdateAsync(Banka, _loginHelper.UserHelper);
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
            await _BankaServis.DeleteAsync(id, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BankaExistsAsync(int id)
        {
            Banka entity = await _BankaServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}