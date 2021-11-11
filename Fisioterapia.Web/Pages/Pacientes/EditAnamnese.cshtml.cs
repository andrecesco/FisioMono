using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes
{
    public class EditAnamneseModel : PageModel
    {
        private readonly IPacienteService _pacienteService;
        private readonly IAnamneseRepository _anamneseRepository;
        private readonly IMapper _mapper;

        public EditAnamneseModel(IPacienteService pacienteService, IAnamneseRepository anamneseRepository, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _anamneseRepository = anamneseRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public AnamneseViewModel AnamneseViewModel { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? idPaciente, Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if(idPaciente == null)
            {
                return RedirectToPage("./Index");
            }

            AnamneseViewModel = _mapper.Map<AnamneseViewModel>(await _anamneseRepository.ObterPorId(id.Value));

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

            var anamnese = _mapper.Map<Anamnese>(AnamneseViewModel);

            await _pacienteService.AtualizarAnamnese(anamnese);

            StatusMessage = "Anamnase foi alterada";
            return RedirectToPage(new { idPaciente = AnamneseViewModel.PacienteId, id = AnamneseViewModel.Id });
        }
    }
}
