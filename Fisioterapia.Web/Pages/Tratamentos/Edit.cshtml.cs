using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Tratamentos
{
    public class EditModel : PageModel
    {
        private readonly ICondutaService _condutaService;
        private readonly ITratamentoRepository _tratamentoRepository;
        private readonly IMapper _mapper;

        public EditModel(ICondutaService condutaService, IMapper mapper, ITratamentoRepository tratamentoRepository)
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

            if (TratamentoViewModel is null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _condutaService.AtualizarTratamento(_mapper.Map<Tratamento>(TratamentoViewModel));

            return RedirectToPage("./Index");
        }
    }
}
