using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class IllerController : Controller
    {
        private readonly IIlServis _IlServis;        

        public IllerController(IIlServis IlServis)
        {
            _IlServis = IlServis;            
        }

        // GET: Ils
        //public async Task<IActionResult> Index()
        //{
        //    var Illar = await _IlServis.GetListAsync();
        //    return View(Illar);
        //}

        public async Task<IActionResult> Index()
        {
            var Illar = await _IlServis.GetListAsync();
            return View(Illar);
        }

        // GET: Ils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _IlServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Ils/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Ils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View(new Il());
            }
            else
            {
                var entity = await _IlServis.GetByIdAsync(id.Value);
                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }
        }

        // POST: Ils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Il Il)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    Il.GuncelleyenId = 1;
                    Il.GuncellemeZamani = DateTime.Now;
                    Il.Aktif = true;

                    if (id == null || id == 0)
                    {
                        Il.EkleyenId = 1;
                        Il.EklemeZamani = DateTime.Now;
                        
                        await _IlServis.AddAsync(Il);
                    }
                    else
                    {
                        if (id != Il.Id)
                        {
                            return NotFound();
                        }
                        await _IlServis.UpdateAsync(Il);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await IlExistsAsync(Il.Id))
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

            return View(Il);
        }

        // GET: Ils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Il = await _IlServis.GetByIdAsync(id.Value);
            if (Il == null)
            {
                return NotFound();
            }

            return View(Il);
        }

        // POST: Ils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _IlServis.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IlExistsAsync(int id)
        {
            Il entity = await _IlServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}
