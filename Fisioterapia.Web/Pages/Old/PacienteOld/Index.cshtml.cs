using AutoMapper;
using Fisioterapia.Domain.Interfaces.Old;
using Fisioterapia.Web.ViewModels.Old;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Old.PacienteOld
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IPacienteOldRepository _pacienteOldRepository;
        private readonly IMapper _mapper;

        public IndexModel(IPacienteOldRepository pacienteOldRepository, IMapper mapper)
        {
            _pacienteOldRepository = pacienteOldRepository;
            _mapper = mapper;
        }

        public IList<PacienteOldViewModel> PacienteOldViewModels { get;set; }

        public async Task OnGetAsync()
        {
            var pacienteOld = await _pacienteOldRepository.ObterTodos().ConfigureAwait(false);
            PacienteOldViewModels = _mapper.Map<IList<PacienteOldViewModel>>(pacienteOld.OrderBy(p => p.Nome));
        }
    }
}
