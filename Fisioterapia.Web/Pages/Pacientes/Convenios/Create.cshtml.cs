using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Fisioterapia.Data;
using Fisioterapia.Domain.Models;

namespace Fisioterapia.Web.Pages.Convenios
{
    public class CreateModel : PageModel
    {
        private readonly Fisioterapia.Data.FisioterapiaDbContext _context;

        public CreateModel(Fisioterapia.Data.FisioterapiaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Documento");
            return Page();
        }

        [BindProperty]
        public Convenio Convenio { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Convenios.Add(Convenio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
