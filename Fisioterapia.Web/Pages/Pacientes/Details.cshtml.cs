using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes
{
    public class DetailsModel : PageModel
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public DetailsModel(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

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

            PacienteViewModel = _mapper.Map<PacienteViewModel>(paciente);

            return Page();
        }
    }
}
