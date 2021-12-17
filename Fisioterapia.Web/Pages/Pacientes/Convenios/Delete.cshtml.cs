using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fisioterapia.Data;
using Fisioterapia.Domain.Models;
using Fisioterapia.Domain.Interfaces;
using AutoMapper;
using Fisioterapia.Web.ViewModels;

namespace Fisioterapia.Web.Pages.Convenios
{
    public class DeleteModel : PageModel
    {
        private readonly IConvenioRepository _convenioRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public DeleteModel(IConvenioRepository convenioRepository, IPacienteService pacienteService, IMapper mapper)
        {
            _convenioRepository = convenioRepository;
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        [BindProperty]
        public ConvenioViewModel ConvenioViewModel { get; set; }

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
            await _pacienteService.RemoverConvenio(ConvenioViewModel.Id);

            //return RedirectToPage("/Paciente/Convenios", new { pacienteId = convenio.PacienteId });
            var url = Url.Action("/Pacientes/Convenios", new { pacienteId = ConvenioViewModel.PacienteId });
            url = url.Replace("/Delete", "");

            return new JsonResult(new { success = true, url });
        }
    }
}
