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
    public class EditModel : PageModel
    {
        private readonly IConvenioRepository _convenioRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public EditModel(IConvenioRepository convenioRepository, IPacienteService pacienteService, IMapper mapper)
        {
            _convenioRepository = convenioRepository;
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        [BindProperty]
        public ConvenioViewModel ConvenioViewModel { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var convenio = await _convenioRepository.ObterPorId(id);

            if (convenio == null)
            {
                return NotFound();
            }

            ConvenioViewModel = _mapper.Map<ConvenioViewModel>(convenio);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var convenio = _mapper.Map<Convenio>(ConvenioViewModel);

            await _pacienteService.AtualizarConvenio(convenio);

            //return RedirectToPage("/Paciente/Convenios", new { pacienteId = convenio.PacienteId });
            var url = Url.Action("/Pacientes/Convenios", new { pacienteId = convenio.PacienteId });
            url = url.Replace("/Edit", "");

            return new JsonResult(new { success = true, url });
        }
    }
}
