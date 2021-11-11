using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Tratamentos
{
    public class DeleteModel : PageModel
    {
        private readonly ICondutaService _condutaService;
        private readonly ITratamentoRepository _tratamentoRepository;
        private readonly IMapper _mapper;

        public DeleteModel(ICondutaService condutaService, IMapper mapper, ITratamentoRepository tratamentoRepository)
        {
            _condutaService = condutaService;
            _tratamentoRepository = tratamentoRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public TratamentoViewModel TratamentoViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            TratamentoViewModel = _mapper.Map<TratamentoViewModel>(await _tratamentoRepository.ObterPorId(id.Value));

            if(TratamentoViewModel is null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            TratamentoViewModel = _mapper.Map<TratamentoViewModel>(await _tratamentoRepository.ObterPorId(id.Value));

            if (TratamentoViewModel is not null)
            {
                await _condutaService.RemoverTratamento(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
