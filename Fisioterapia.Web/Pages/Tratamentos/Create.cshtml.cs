using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Tratamentos
{
    public class CreateModel : PageModel
    {
        private readonly ICondutaService _condutaService;
        private readonly IMapper _mapper;

        public CreateModel(ICondutaService condutaService, IMapper mapper)
        {
            _condutaService = condutaService;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TratamentoViewModel TratamentoViewModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _condutaService.AdicionarTratamento(_mapper.Map<Tratamento>(TratamentoViewModel));

            return RedirectToPage("./Index");
        }
    }
}
