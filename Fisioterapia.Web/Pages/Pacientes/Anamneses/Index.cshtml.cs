using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes.Anamneses
{
    public class IndexModel : PageModel
    {
        private readonly IAnamneseRepository _anamneseRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public IndexModel(IAnamneseRepository anamneseRepository, IPacienteService pacienteService, IMapper mapper)
        {
            _anamneseRepository = anamneseRepository;
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync(Guid pacienteId)
        {
            var anamnese = await _anamneseRepository.ObterAnamnesePorIdPaciente(pacienteId);
            if(anamnese is not null)
            {
                return RedirectToPage("Edit", new { pacienteId = anamnese.PacienteId, id = anamnese.Id });
            }

            AnamneseViewModel = new AnamneseViewModel
            {
                PacienteId = pacienteId
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
            return RedirectToPage("Edit", new { pacienteId = anamnese.PacienteId, id = anamnese.Id });
        }
    }
}
