using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes
{
    public class CreateModel : PageModel
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public CreateModel(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PacienteViewModel PacienteViewModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _pacienteService.Adicionar(_mapper.Map<Paciente>(PacienteViewModel));

            return RedirectToPage("./Index");
        }
    }
}
