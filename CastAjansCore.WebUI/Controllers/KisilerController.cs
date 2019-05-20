using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class KisilerController : Controller
    {
        IKisiServis _kisiServis;
        IUyrukServis _uyrukServis;
        public KisilerController(IKisiServis kisiServis, IUyrukServis uyrukServis)
        {
            _kisiServis = kisiServis;
            _uyrukServis = uyrukServis;
        }

        // GET: Kisiler
        public  Task<IActionResult> Index()
        {            
            return await View(_kisiServis.GetListAsync());
        }

        // GET: Kisiler/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = _kisiServis.GetById(id.ToInt());

            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

        // GET: Kisiler/Create
        public IActionResult Create()
        {
            ViewData["UyrukId"] = new SelectList(_uyrukServis.GetList(), "Id", "Adi");
            return View();
        }

        // POST: Kisiler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,TC,Adi,Soyadi,DogumTarihi,Cinsiyet,KanGrubu,UyrukId,EPosta,WebSitesi,FaceBook,Twitter,Instagram,Linkedin")] Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                _kisiServis.Add(kisi);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UyrukId"] = new SelectList(_uyrukServis.GetList(), "Id", "Adi", kisi.UyrukId);
            return View(kisi);
        }

        // GET: Kisiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = _kisiServis.GetById(id.ToInt());
            if (kisi == null)
            {
                return NotFound();
            }
            ViewData["UyrukId"] = new SelectList(_uyrukServis.GetList(), "Id", "Adi", kisi.UyrukId);
            return View(kisi);
        }

        // POST: Kisiler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TC,Adi,Soyadi,DogumTarihi,Cinsiyet,KanGrubu,UyrukId,EPosta,WebSitesi,FaceBook,Twitter,Instagram,Linkedin")] Kisi kisi)
        {
            if (id != kisi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _kisiServis.Update(kisi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KisiExists(kisi.Id))
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
            ViewData["UyrukId"] = new SelectList(_uyrukServis.GetList(), "Id", "Adi", kisi.UyrukId);
            return View(kisi);
        }

        // GET: Kisiler/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = _kisiServis.GetById(id.ToInt());
            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

        // POST: Kisiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        private bool KisiExists(int id)
        {
            return _kisiServis.Get(e => e.Id == id).IsNotNull();
        }
    }
}
