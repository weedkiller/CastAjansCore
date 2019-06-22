using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class UyruklarController : Controller
    {
        private readonly IUyrukServis _UyrukServis;

        public UyruklarController(IUyrukServis UyrukServis)
        {
            _UyrukServis = UyrukServis;
        }
        
        public async Task<IActionResult> Index()
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            var Uyruklar = await _UyrukServis.GetListAsync();
            return View(Uyruklar);
        }
        
        // GET: Uyruks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
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

                        await _UyrukServis.AddAsync(Uyruk, HttpContext.Session.GetUserHelper());
                    }
                    else
                    {
                        if (id != Uyruk.Id)
                        {
                            return NotFound();
                        }
                        await _UyrukServis.UpdateAsync(Uyruk, HttpContext.Session.GetUserHelper());
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
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
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
            await _UyrukServis.DeleteAsync(id, HttpContext.Session.GetUserHelper());
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UyrukExistsAsync(int id)
        {
            Uyruk entity = await _UyrukServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}