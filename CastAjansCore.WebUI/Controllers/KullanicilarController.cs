using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly IKullaniciServis _kullaniciServis;
        private readonly IKullaniciDal _kullaniciDal;

        public KullanicilarController(IKullaniciServis kullaniciServis, IKullaniciDal kullaniciDal)
        {
            _kullaniciServis = kullaniciServis;
            _kullaniciDal = kullaniciDal;
        }

        // GET: Kullanicis
        //public async Task<IActionResult> Index()
        //{
        //    var kullanicilar = await _kullaniciServis.GetListAsync();
        //    return View(kullanicilar);
        //}

        public IActionResult Index()
        {
            var kullanicilar = _kullaniciServis.GetList();
            return View(kullanicilar);
        }

        // GET: Kullanicis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _kullaniciServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Kullanicis/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Kullanicis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View(new Kullanici { Kisi = new Kisi() });
            }
            else
            {
                var entity = await _kullaniciServis.GetByIdAsync(id.Value);
                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }
        }

        // POST: Kullanicis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Kullanici kullanici)
        {


            if (ModelState.IsValid)
            {
                try
                {

                    if (id == null)
                    {                        
                        await _kullaniciServis.AddAsync(kullanici);
                    }
                    else
                    {
                        if (id != kullanici.Id)
                        {
                            return NotFound();
                        }
                        await _kullaniciServis.UpdateAsync(kullanici);
                    } 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await KullaniciExistsAsync(kullanici.Id))
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

            return View(kullanici);
        }

        // GET: Kullanicis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanici = await _kullaniciServis.GetByIdAsync(id.Value);
            if (kullanici == null)
            {
                return NotFound();
            }

            return View(kullanici);
        }

        // POST: Kullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _kullaniciServis.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> KullaniciExistsAsync(int id)
        {
            Kullanici entity = await _kullaniciServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}
