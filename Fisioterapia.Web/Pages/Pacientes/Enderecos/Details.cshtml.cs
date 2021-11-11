using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fisioterapia.Data;
using Fisioterapia.Domain.Models;

namespace Fisioterapia.Web.Pages.Enderecos
{
    public class DetailsModel : PageModel
    {
        private readonly Fisioterapia.Data.FisioterapiaDbContext _context;

        public DetailsModel(Fisioterapia.Data.FisioterapiaDbContext context)
        {
            _context = context;
        }

        public Endereco Endereco { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Endereco = await _context.Enderecos
                .Include(e => e.Paciente).FirstOrDefaultAsync(m => m.Id == id);

            if (Endereco == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
