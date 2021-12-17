using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fisioterapia.Data;
using Fisioterapia.Domain.Models;

namespace Fisioterapia.Web.Pages.Anamneses
{
    public class DeleteModel : PageModel
    {
        private readonly Fisioterapia.Data.FisioterapiaDbContext _context;

        public DeleteModel(Fisioterapia.Data.FisioterapiaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Anamnese Anamnese { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Anamnese = await _context.Anamneses
                .Include(a => a.Paciente).FirstOrDefaultAsync(m => m.Id == id);

            if (Anamnese == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Anamnese = await _context.Anamneses.FindAsync(id);

            if (Anamnese != null)
            {
                _context.Anamneses.Remove(Anamnese);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
