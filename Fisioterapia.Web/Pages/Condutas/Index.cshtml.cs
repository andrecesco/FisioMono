using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Condutas
{
    public class IndexModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ICondutaRepository _condutaRepository;
        private readonly IPacienteRepository _pacienteRepository;

        public IndexModel(ICondutaRepository condutaRepository, IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _condutaRepository = condutaRepository;
            _pacienteRepository = pacienteRepository;
        }

        public IList<CondutaViewModel> CondutasViewModels { get; set; }

        public Guid PacienteId { get; set; }

        public async Task OnGetAsync(Guid pacienteId)
        {
            PacienteId = pacienteId;
            var paciente = await _pacienteRepository.ObterPorId(pacienteId);
            CondutasViewModels = new List<CondutaViewModel>();
            if (paciente is not null)
            {
                ViewData["NomePaciente"] = paciente.NomeCompleto;
                CondutasViewModels = _mapper.Map<IList<CondutaViewModel>>(await _condutaRepository.ObterCondutasPorPacienteId(paciente.Id));
            }
        }
    }
}
