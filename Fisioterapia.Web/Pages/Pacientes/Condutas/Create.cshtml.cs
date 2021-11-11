using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Condutas
{
    public class CreateModel : PageModel
    {
        private readonly ICondutaService _condutaService;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public CreateModel(ICondutaService condutaService, IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _condutaService = condutaService;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public CondutaViewModel CondutaViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid pacienteId)
        {
            var paciente = await _pacienteRepository.ObterPorId(pacienteId);
            if(paciente is null)
            {
                return NotFound();
            }

            CondutaViewModel = new CondutaViewModel
            {
                PacienteId = paciente.Id,
                Paciente = _mapper.Map<PacienteViewModel>(paciente)
            };

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _condutaService.Adicionar(_mapper.Map<Conduta>(CondutaViewModel));

            return RedirectToPage("./Index");
        }
    }
}
