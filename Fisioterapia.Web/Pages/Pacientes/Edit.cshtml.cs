using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes
{
    public class EditModel : PageModel
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public EditModel(IPacienteService pacienteService, IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public PacienteViewModel PacienteViewModel { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? pacienteId)
        {
            if (pacienteId == null)
            {
                return NotFound();
            }

            var paciente = await _pacienteRepository.ObterPorId(pacienteId.Value);

            if (paciente is null)
            {
                return NotFound();
            }

            PacienteViewModel = _mapper.Map<PacienteViewModel>(paciente);

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

            var paciente = await _pacienteRepository.ObterPorId(PacienteViewModel.Id);

            if (paciente is not null)
            {
                await _pacienteService.Atualizar(_mapper.Map<Paciente>(PacienteViewModel));
            }

            StatusMessage = "Paciente foi alterado";
            return RedirectToPage(new { pacienteId = paciente.Id });
        }
    }
}
