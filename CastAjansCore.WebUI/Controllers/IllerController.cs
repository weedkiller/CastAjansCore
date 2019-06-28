using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class IllerController : Controller
    {
        private readonly IIlServis _IlServis;
        private readonly LoginHelper _loginHelper;

        public IllerController(IIlServis IlServis, LoginHelper loginHelper)
        {
            _IlServis = IlServis;
            _loginHelper = loginHelper;
            ViewData["UserHelper"] = _loginHelper.UserHelper;
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
                    if (id == null || id == 0)
                    {                      
                        await _IlServis.AddAsync(Il, _loginHelper.UserHelper);
                    }
                    else
                    {
                        if (id != Il.Id)
                        {
                            return NotFound();
                        }
                        await _IlServis.UpdateAsync(Il, _loginHelper.UserHelper);
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
            await _IlServis.DeleteAsync(id, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IlExistsAsync(int id)
        {
            Il entity = await _IlServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}
