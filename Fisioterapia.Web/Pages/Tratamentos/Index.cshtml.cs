using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Tratamentos
{
    public class IndexModel : PageModel
    {
        private readonly ITratamentoRepository _tratamentoRepository;
        private readonly IMapper _mapper;

        public IndexModel(IMapper mapper, ITratamentoRepository tratamentoRepository)
        {
            _tratamentoRepository = tratamentoRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public List<TratamentoViewModel> TratamentosViewModels { get; set; }

        public async Task OnGetAsync()
        {
            TratamentosViewModels = _mapper.Map<List<TratamentoViewModel>>(await _tratamentoRepository.ObterTodos());
        }
    }
}
