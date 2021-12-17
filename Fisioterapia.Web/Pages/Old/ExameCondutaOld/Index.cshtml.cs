using AutoMapper;
using Fisioterapia.Domain.Interfaces.Old;
using Fisioterapia.Web.ViewModels.Old;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Old.ExameCondutaOld
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IPacienteOldRepository _pacienteOldRepository;
        private readonly IExameCondutaOldRepository _exameCondutaOldRepository;
        private readonly IMapper _mapper;

        public IndexModel(IPacienteOldRepository pacienteOldRepository, IExameCondutaOldRepository exameCondutaOldRepository, IMapper mapper)
        {
            _pacienteOldRepository = pacienteOldRepository;
            _exameCondutaOldRepository = exameCondutaOldRepository;
            _mapper = mapper;
        }

        public IList<ExameCondutaOldViewModel> ExameCondutaOldViewModels { get;set; }

        public PacienteOldViewModel PacienteOldViewModel { get; set; }

        public async Task OnGetAsync(int pacienteId)
        {
            var paciente = await _pacienteOldRepository.ObterPorId(pacienteId).ConfigureAwait(false);
            PacienteOldViewModel = _mapper.Map<PacienteOldViewModel>(paciente);

            var exameCondutaOld = await _exameCondutaOldRepository.ObterExameCondutaPorPacienteId(pacienteId).ConfigureAwait(false);
            ExameCondutaOldViewModels = _mapper.Map<IList<ExameCondutaOldViewModel>>(exameCondutaOld);
        }
    }
}
