using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Condutas
{
    public class EditModel : PageModel
    {
        private readonly ICondutaService _condutaService;
        private readonly ICondutaRepository _condutaRepository;
        private readonly IMapper _mapper;

        public EditModel(ICondutaService condutaService, ICondutaRepository condutaRepository, IMapper mapper)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _condutaService.Atualizar(_mapper.Map<Conduta>(CondutaViewModel));

            return RedirectToPage("./Index");
        }
    }
}
