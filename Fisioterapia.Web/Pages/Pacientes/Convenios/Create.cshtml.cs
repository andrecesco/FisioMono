using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Convenios
{
    public class CreateModel : PageModel
    {
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public CreateModel(IPacienteService pacienteService, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        public IActionResult OnGet(Guid pacienteId)
        {
            ConvenioViewModel = new ConvenioViewModel
            {
                PacienteId = pacienteId
            };
            return Page();
        }

        [BindProperty]
        public ConvenioViewModel ConvenioViewModel { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var convenio = _mapper.Map<Convenio>(ConvenioViewModel);

            await _pacienteService.AdicionarConvenio(convenio);

            //return RedirectToPage("/Paciente/Convenios", new { pacienteId = convenio.PacienteId });
            var url = Url.Action("/Pacientes/Convenios", new { pacienteId = convenio.PacienteId });
            url = url.Replace("/Create", "");
            return new JsonResult(new { success = true, url });
        }
    }
}
