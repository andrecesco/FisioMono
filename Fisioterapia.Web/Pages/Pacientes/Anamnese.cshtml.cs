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
    public class AnamneseModel : PageModel
    {
        private readonly IAnamneseRepository _anamneseRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public AnamneseModel(IAnamneseRepository anamneseRepository, IPacienteService pacienteService, IMapper mapper)
        {
            _anamneseRepository = anamneseRepository;
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync(Guid idPaciente)
        {
            var anamnese = await _anamneseRepository.ObterAnamnesePorIdPaciente(idPaciente);
            if(anamnese is not null)
            {
                return RedirectToPage("EditAnamnese", new { idPaciente = anamnese.PacienteId, id = anamnese.Id });
            }

            AnamneseViewModel = new AnamneseViewModel
            {
                PacienteId = idPaciente
            };

            return Page();
        }

        [BindProperty]
        public AnamneseViewModel AnamneseViewModel { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var anamnese = _mapper.Map<Anamnese>(AnamneseViewModel);

            await _pacienteService.AdicionarAnamnese(anamnese);

            StatusMessage = "Anamnase foi adicionada ao paciente com sucesso";
            return RedirectToPage("EditAnamnese", new { id = anamnese.Id });
        }
    }
}
