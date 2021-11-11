using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Condutas
{
    public class DeleteModel : PageModel
    {
        private readonly ICondutaService _condutaService;
        private readonly ICondutaRepository _condutaRepository;
        private readonly IMapper _mapper;

        public DeleteModel(ICondutaService condutaService, ICondutaRepository condutaRepository, IMapper mapper)
        {
            _condutaService = condutaService;
            _condutaRepository = condutaRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public CondutaViewModel CondutaViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            CondutaViewModel = _mapper.Map<CondutaViewModel>(await _condutaRepository.ObterCondutaCompletaPorId(id.Value));

            if (CondutaViewModel is null)
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

            var conduta = await _condutaRepository.ObterPorId(id.Value);

            if (conduta is null)
            {
                await _condutaService.Remover(conduta.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
