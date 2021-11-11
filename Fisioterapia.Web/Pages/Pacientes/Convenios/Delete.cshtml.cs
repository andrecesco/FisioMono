using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fisioterapia.Data;
using Fisioterapia.Domain.Models;

namespace Fisioterapia.Web.Pages.Convenios
{
    public class DeleteModel : PageModel
    {
        private readonly Fisioterapia.Data.FisioterapiaDbContext _context;

        public DeleteModel(Fisioterapia.Data.FisioterapiaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Convenio Convenio { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Convenio = await _context.Convenios
                .Include(c => c.Paciente).FirstOrDefaultAsync(m => m.Id == id);

            if (Convenio == null)
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

            Convenio = await _context.Convenios.FindAsync(id);

            if (Convenio != null)
            {
                _context.Convenios.Remove(Convenio);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
