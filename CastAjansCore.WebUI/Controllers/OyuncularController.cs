using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CastAjansCore.WebUI.Controllers
{
    public class OyuncularController : Controller
    {
        private readonly IOyuncuServis _OyuncuServis;

        public OyuncularController(IOyuncuServis OyuncuServis)
        {
            _OyuncuServis = OyuncuServis;
        }
        
        public async Task<IActionResult> Index()
        {
            var Oyuncular = await _OyuncuServis.GetListDtoAsync();
            return View(Oyuncular);
        }

        // GET: Oyuncus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _OyuncuServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Oyuncus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            OyuncuEditDto model = await _OyuncuServis.GetEditDtoAsync(id);

            if (id != null  && model.Oyuncu == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Oyuncus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, OyuncuEditDto OyuncuEditDto)
        {
            ModelState.Remove("Oyuncu.Id");
            ModelState.Remove("KisiEditDto.Kisi.Ilce.Id");
            ModelState.Remove("KisiEditDto.Kisi.Ilce.IlId");
            ModelState.Remove("KisiEditDto.Kisi.Ilce.Adi");

            if (ModelState.IsValid)
            {
                try
                {
                    Oyuncu Oyuncu = OyuncuEditDto.Oyuncu;
                    Oyuncu.Kisi = OyuncuEditDto.KisiEditDto.Kisi;
                    if (id == null)
                    {
                        await _OyuncuServis.AddAsync(Oyuncu, HttpContext.Session.GetUserHelper());
                    }
                    else
                    {
                        if (id != Oyuncu.Id)
                        {
                            return NotFound();
                        }
                        await _OyuncuServis.UpdateAsync(Oyuncu, HttpContext.Session.GetUserHelper());
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await OyuncuExistsAsync(OyuncuEditDto.Oyuncu.Id))
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
            var combolar = await _OyuncuServis.GetEditDtoAsync(id);
            OyuncuEditDto.KisiEditDto.Ilceler = combolar.KisiEditDto.Ilceler;
            OyuncuEditDto.KisiEditDto.Iller = combolar.KisiEditDto.Iller;
            OyuncuEditDto.KisiEditDto.Uyruklar = combolar.KisiEditDto.Uyruklar;
            return View(OyuncuEditDto);
        }

        // GET: Oyuncus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Oyuncu = await _OyuncuServis.GetByIdAsync(id.Value);
            if (Oyuncu == null)
            {
                return NotFound();
            }

            return View(Oyuncu);
        }

        // POST: Oyuncus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _OyuncuServis.DeleteAsync(id, HttpContext.Session.GetUserHelper());
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OyuncuExistsAsync(int id)
        {
            Oyuncu entity = await _OyuncuServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}
