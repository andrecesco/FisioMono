using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public IndexModel(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public IList<PacienteViewModel> PacientesViewModels { get;set; }

        public async Task OnGetAsync()
        {
            PacientesViewModels = _mapper.Map<IList<PacienteViewModel>>(await _pacienteRepository.ObterTodos());
        }
    }
}
