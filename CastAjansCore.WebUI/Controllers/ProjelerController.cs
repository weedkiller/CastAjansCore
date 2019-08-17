using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
            Task<List<Proje>> tProje = _ProjeServis.GetListAsync(i => (id == null || i.MusteriId == id) && i.Aktif == true);
            if (id != null)
            {
                ProjeListDto.Musteri = await _MusteriServis.GetByIdAsync(id.Value); ;
            }

            ProjeListDto.Projeler = await tProje;

            return View(ProjeListDto);
        }


        public async Task<IActionResult> Detail(string id)
        {
            ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);

            return View(model);
        }

        //public ViewAsPdf Pdf(string id)
        //{
        //    ViewAsPdf pdf = new ViewAsPdf("Detail", id)
        //    {
        //        FileName = "File.pdf",
        //        PageSize = Rotativa.Options.Size.A4,
        //        PageMargins = { Left = 0, Right = 0 }
        //    };

        //    return pdf;
        //}


        public async Task<IActionResult> Edit(int? id, int musteriId)
        {
            ProjeEditDto projeEditDto = await _ProjeServis.GetEditDtoAsync(id, musteriId);
            if (projeEditDto.Proje.GuidId == Guid.Empty)
            {
                projeEditDto.Proje.GuidId = Guid.NewGuid();
            }
            if (projeEditDto.Proje == null)
            {
                return NotFound();
            }
            if (projeEditDto.Proje.IsiTakipEdenId == 0)
            {
                projeEditDto.Proje.IsiTakipEdenId = _loginHelper.UserHelper.Id;
            }
            return View(projeEditDto);
        }

        private async Task Save(int? id, Proje Proje)
        {
            if (id == null || id == 0)
            {
                await _ProjeServis.AddAsync(Proje, _loginHelper.UserHelper);
            }
            else
            {
                await _ProjeServis.UpdateAsync(Proje, _loginHelper.UserHelper);
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Proje Proje)
        {
            if (ModelState.IsValid)
            {
                await Save(id, Proje);
                return RedirectToAction(nameof(Index), new { id = Proje.MusteriId });
            }
            return View(Proje);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndDetail(int? id, Proje Proje)
        {
            await Save(id, Proje);
            return RedirectToAction(nameof(Detail), new { id = Proje.GuidId});
        }

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