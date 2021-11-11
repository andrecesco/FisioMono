using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fisioterapia.Data;
using Fisioterapia.Domain.Models;

namespace Fisioterapia.Web.Pages.Convenios
{
    public class EditModel : PageModel
    {
        private readonly Fisioterapia.Data.FisioterapiaDbContext _context;

        public EditModel(Fisioterapia.Data.FisioterapiaDbContext context)
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
           ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Documento");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Convenio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConvenioExists(Convenio.Id))
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

        private bool ConvenioExists(Guid id)
        {
            return _context.Convenios.Any(e => e.Id == id);
        }
    }
}
