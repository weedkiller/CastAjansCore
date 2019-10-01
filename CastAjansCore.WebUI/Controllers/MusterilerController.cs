using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize(Roles = "admin,calisan")]
    public class MusterilerController : Controller
    {
        private readonly IMusteriServis _MusteriServis;
        private readonly IIlServis _IlServis;
        private readonly IIlceServis _IlceServis;
        private readonly LoginHelper _loginHelper;

        public MusterilerController(IMusteriServis MusteriServis, IIlServis IlServis, IIlceServis IlceServis, LoginHelper loginHelper)
        {
            _MusteriServis = MusteriServis;
            _IlServis = IlServis;
            _IlceServis = IlceServis;
            _loginHelper = loginHelper;
            ViewData["UserHelper"] = _loginHelper.UserHelper;
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
            
            var model = new MusteriEditDto
            {
                Iller = (await _IlServis.GetSelectListAsync())
            };

            if (id == null)
            {
                return View(model);
            }
            else
            {
                model.Musteri = await _MusteriServis.GetByIdAsync(id.Value);                
                model.Musteri.Ilce = await _IlceServis.GetByIdAsync(model.Musteri.IlceId.Value);                      
                model.Ilceler = await _IlceServis.GetSelectListAsync(i => i.IlId == model.Musteri.Ilce.IlId && i.Aktif);

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
            }
        }

        // POST: Musteris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detaMusteris see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, MusteriEditDto musteriEditdto)
        {

            ModelState.Remove("Musteri.Ilce.Id");
            ModelState.Remove("Musteri.Ilce.IlId");
            ModelState.Remove("Musteri.Ilce.Adi");
            if (ModelState.IsValid)
            {
                try
                {
                    musteriEditdto.Musteri.GuncelleyenId = 1;
                    musteriEditdto.Musteri.GuncellemeZamani = DateTime.Now;
                    musteriEditdto.Musteri.Aktif = true;

                    if (id == null || id == 0)
                    {
                        musteriEditdto.Musteri.EkleyenId = 1;
                        musteriEditdto.Musteri.EklemeZamani = DateTime.Now;

                        await _MusteriServis.AddAsync(musteriEditdto.Musteri, _loginHelper.UserHelper);
                    }
                    else
                    {
                        if (id != musteriEditdto.Musteri.Id)
                        {
                            return NotFound();
                        }
                        await _MusteriServis.UpdateAsync(musteriEditdto.Musteri, _loginHelper.UserHelper);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MusteriExistsAsync(musteriEditdto.Musteri.Id))
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
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            return View(musteriEditdto);
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
            await _MusteriServis.DeleteAsync(id, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MusteriExistsAsync(int id)
        {
            Musteri entity = await _MusteriServis.GetByIdAsync(id);
            return entity != null;
        }

    }
}