using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class IlcelerController : Controller
    {
        private readonly IIlceServis _IlceServis;
        private readonly IIlServis _IlServis;
        private readonly LoginHelper _loginHelper;

        public IlcelerController(IIlceServis IlceServis, IIlServis IlServis, LoginHelper loginHelper)
        {
            _IlceServis = IlceServis;
            _IlServis = IlServis;
            _loginHelper = loginHelper;
            ViewData["UserHelper"] = _loginHelper.UserHelper;
        }

        // GET: Ilces
        //public async Task<IActionResult> Index()
        //{
        //    var Ilcelar = await _IlceServis.GetListAsync();
        //    return View(Ilcelar);
        //}

        public async Task<IActionResult> Index(int id)
        {
            
            IlceListDto ilceListDto = new IlceListDto();
            Task<Il> tIl = _IlServis.GetByIdAsync(id);
            Task<List<Ilce>> tIlce = _IlceServis.GetListAsync(i => i.IlId == id);

            ilceListDto.Il = await tIl;
            ilceListDto.Ilceler = await tIlce;

            return View(ilceListDto);
        }

        public async Task<JsonResult> GetJson(int id)
        {

            Task<List<Ilce>> tIlce = _IlceServis.GetListAsync(i => i.IlId == id);
            var ilceler = await tIlce;
            return Json(ilceler);
        }

        // GET: Ilces/DetaIlces/5
        public async Task<IActionResult> DetaIlces(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _IlceServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        
        // GET: Ilces/Edit/5
        public async Task<IActionResult> Edit(int? id, int ilId)
        {
            

            if (id == null)
            {
                var il = await _IlServis.GetByIdAsync(ilId);
                return View(new Ilce { IlId = ilId, Il = il });
            }
            else
            {

                var entity = await _IlceServis.GetByIdAsync(id.Value);
                entity.Il = await _IlServis.GetByIdAsync(entity.IlId);

                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }
        }

        // POST: Ilces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detaIlces see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Ilce Ilce)
        {
            if (ModelState.IsValid)
            {
                try
                { 
                    if (id == null || id == 0)
                    {                       
                        await _IlceServis.AddAsync(Ilce, _loginHelper.UserHelper);
                    }
                    else
                    {
                        if (id != Ilce.Id)
                        {
                            return NotFound();
                        }
                        await _IlceServis.UpdateAsync(Ilce, _loginHelper.UserHelper);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await IlceExistsAsync(Ilce.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index) + "/" + Ilce.IlId);
            }

            return View(Ilce);
        }

        // GET: Ilces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var Ilce = await _IlceServis.GetByIdAsync(id.Value);
            if (Ilce == null)
            {
                return NotFound();
            }

            return View(Ilce);
        }

        // POST: Ilces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _IlceServis.DeleteAsync(id, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IlceExistsAsync(int id)
        {
            Ilce entity = await _IlceServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}