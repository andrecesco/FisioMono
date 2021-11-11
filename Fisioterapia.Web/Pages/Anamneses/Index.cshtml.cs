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
    public class IndexModel : PageModel
    {
        private readonly Fisioterapia.Data.FisioterapiaDbContext _context;

        public IndexModel(Fisioterapia.Data.FisioterapiaDbContext context)
        {
            _context = context;
        }

        public IList<Anamnese> Anamnese { get;set; }

        public async Task OnGetAsync()
        {
            Anamnese = await _context.Anamneses
                .Include(a => a.Paciente).ToListAsync();
        }
    }
}
