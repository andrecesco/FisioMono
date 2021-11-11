using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes
{
    public class DeleteModel : PageModel
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPacienteService _pacienteService;

        public DeleteModel(IPacienteService pacienteService, IPacienteRepository pacienteRepository)
        {
            _pacienteService = pacienteService;
            _pacienteRepository = pacienteRepository;
        }

        [BindProperty]
        public PacienteViewModel PacienteViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var paciente = await _pacienteRepository.ObterPorId(id.Value);

            if (paciente is null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var paciente = await _pacienteRepository.ObterPorId(id.Value);

            if (paciente is not null)
            {
                await _pacienteService.Remover(paciente.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
