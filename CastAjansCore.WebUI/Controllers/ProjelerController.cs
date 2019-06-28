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
    [Authorize(Roles = "admin,calisan")]
    public class ProjelerController : Controller
    {
        private readonly IProjeServis _ProjeServis;
        private readonly IMusteriServis _MusteriServis;
        private readonly IKullaniciServis _KullaniciServis;
        private readonly IProjeKarakterServis _ProjeKarakterServis;
        private readonly IProjeKarakterOyuncuServis _ProjeKarakterOyuncuServis;
        private readonly IUyrukServis _UyrukServis;
        private readonly LoginHelper _loginHelper;

        public ProjelerController(IProjeServis ProjeServis,
            IMusteriServis musteriServis,
            IKullaniciServis kullaniciServis,
            IProjeKarakterServis projeKarakterServis,
            IProjeKarakterOyuncuServis projeKarakterOyuncuServis,
            IUyrukServis uyrukServis,
            LoginHelper loginHelper)
        {
            _ProjeServis = ProjeServis;
            _MusteriServis = musteriServis;
            _KullaniciServis = kullaniciServis;
            _ProjeKarakterServis = projeKarakterServis;
            _ProjeKarakterOyuncuServis = projeKarakterOyuncuServis;
            _UyrukServis = uyrukServis;
            _loginHelper = loginHelper;
            ViewData["UserHelper"] = _loginHelper.UserHelper;
        }

        public async Task<IActionResult> Index(int? id)
        {
            
            ProjeListDto ProjeListDto = new ProjeListDto();
            Task<Musteri> tMusteri = _MusteriServis.GetByIdAsync(id.Value);
            Task<List<Proje>> tProje = _ProjeServis.GetListAsync(i => (id == null || i.MusteriId == id));

            ProjeListDto.Musteri = await tMusteri;
            ProjeListDto.Projeler = await tProje;

            return View(ProjeListDto);
        }

        // GET: Projes/Edit/5
        public async Task<IActionResult> Edit(int? id, int musteriId)
        {
            
            var tKul = _KullaniciServis.GetSelectListAsync();
            var tUyruk = _UyrukServis.GetSelectListAsync();
            var projeEditDto = new ProjeEditDto()
            {
                Kullanicilar = await tKul,
                Uyruklar = await tUyruk
            };

            if (id == null)
            {
                projeEditDto.Proje = new Proje
                {
                    MusteriId = musteriId,
                    Musteri = await _MusteriServis.GetByIdAsync(musteriId),
                    ProjeKarakterleri = new List<ProjeKarakter>(),
                };

                return View(projeEditDto);
            }
            else
            {
                projeEditDto.Proje = await _ProjeServis.GetByIdAsync(id.Value);
                projeEditDto.Proje.Musteri = await _MusteriServis.GetByIdAsync(projeEditDto.Proje.MusteriId);
                projeEditDto.Proje.ProjeKarakterleri = await _ProjeKarakterServis.GetListByProjeIdAsync(id.Value);
                foreach (var item in projeEditDto.Proje.ProjeKarakterleri)
                {
                    item.ProjeKarakterOyunculari = await _ProjeKarakterOyuncuServis.GetListByProjeKarakterIdAsync(item.Id);
                }

                //Task[] tProjeKarakterOyunculari = new Task[projeEditDto.Proje.ProjeKarakterleri.Count];
                //foreach (var item in projeEditDto.Proje.ProjeKarakterleri)
                //{
                //    tProjeKarakterOyunculari[projeEditDto.Proje.ProjeKarakterleri.IndexOf(item)] = _ProjeKarakterOyuncuServis.GetListByProjeKarakterIdAsync(item.Id);
                //}

                //await Task.WhenAll(tProjeKarakterOyunculari);
                //foreach (var item in projeEditDto.Proje.ProjeKarakterleri)
                //{
                //    item.ProjeKarakterOyunculari = (List<ProjeKarakterOyuncu>)(await tProjeKarakterOyunculari[projeEditDto.Proje.ProjeKarakterleri.IndexOf(item)]);
                //}

                if (projeEditDto.Proje == null)
                {
                    return NotFound();
                }

                return View(projeEditDto);
            }
        }

        // POST: Projes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more detaProjes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Proje Proje)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == null || id == 0)
                    {
                        await _ProjeServis.AddAsync(Proje, _loginHelper.UserHelper);
                    }
                    else
                    {
                        if (id != Proje.Id)
                        {
                            return NotFound();
                        }
                        await _ProjeServis.UpdateAsync(Proje, _loginHelper.UserHelper);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProjeExistsAsync(Proje.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = Proje.MusteriId });
            }

            return View(Proje);
        }

        // GET: Projes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var Proje = await _ProjeServis.GetByIdAsync(id.Value);
            if (Proje == null)
            {
                return NotFound();
            }

            return View(Proje);
        }

        // POST: Projes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ProjeServis.DeleteAsync(id, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProjeExistsAsync(int id)
        {
            Proje entity = await _ProjeServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}