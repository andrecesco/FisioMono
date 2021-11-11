using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes.Convenios
{
    public class IndexModel : PageModel
    {
        private readonly IConvenioRepository _convenioRepository;
        private readonly IMapper _mapper;

        public IndexModel(IConvenioRepository convenioRepository, IMapper mapper)
        {
            _convenioRepository = convenioRepository;
            _mapper = mapper;
        }

        public IList<ConvenioViewModel> ConveniosViewModels { get; set; }

        public async Task OnGetAsync(Guid idPaciente)
        {
            ConveniosViewModels = _mapper.Map<IList<ConvenioViewModel>>(await _convenioRepository.ObterConveniosPorIdPaciente(idPaciente));
        }
    }
}
