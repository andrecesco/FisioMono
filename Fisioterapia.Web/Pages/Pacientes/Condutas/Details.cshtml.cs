using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Condutas
{
    public class DetailsModel : PageModel
    {
        private readonly ICondutaRepository _condutaRepository;
        private readonly IMapper _mapper;

        public DetailsModel(ICondutaRepository condutaRepository, IMapper mapper)
        {
            _condutaRepository = condutaRepository;
            _mapper = mapper;
        }

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
    }
}
