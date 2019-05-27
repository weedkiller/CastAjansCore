using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CastAjansCore.DataLayer.Concrete.EntityFramework;
using CastAjansCore.Entity;

namespace CastAjansCore.WebUI.Pages.Bankalar
{
    public class EditModel : PageModel
    {
        private readonly CastAjansCore.DataLayer.Concrete.EntityFramework.CastAjansContext _context;

        public EditModel(CastAjansCore.DataLayer.Concrete.EntityFramework.CastAjansContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Banka Banka { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Banka = await _context.Bankalar
                .Include(b => b.Ekleyen)
                .Include(b => b.Guncelleyen).FirstOrDefaultAsync(m => m.Id == id);

            if (Banka == null)
            {
                return NotFound();
            }
           ViewData["EkleyenId"] = new SelectList(_context.Kisiler, "Id", "Adi");
           ViewData["GuncelleyenId"] = new SelectList(_context.Kisiler, "Id", "Adi");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Banka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankaExists(Banka.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BankaExists(int id)
        {
            return _context.Bankalar.Any(e => e.Id == id);
        }
    }
}
