using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes.Anamneses
{
    public class EditModel : PageModel
    {
        private readonly IPacienteService _pacienteService;
        private readonly IAnamneseRepository _anamneseRepository;
        private readonly IMapper _mapper;

        public EditModel(IPacienteService pacienteService, IAnamneseRepository anamneseRepository, IMapper mapper)
        {
            _pacienteService = pacienteService;
            _anamneseRepository = anamneseRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public AnamneseViewModel AnamneseViewModel { get; set; }

        [BindProperty]
        public string PressaoAltaRadio { get; set; }

        [BindProperty]
        public string PraticaAtividadeFisicaRadio { get; set; }

        [BindProperty]
        public string ConsumeSubstanciasRadio { get; set; }

        [BindProperty]
        public string ContraturaMuscularRadio { get; set; }

        [BindProperty]
        public string RetracaoMuscularRadio { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? pacienteId, Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if(pacienteId == null)
            {
                return RedirectToPage("./Index");
            }

            AnamneseViewModel = _mapper.Map<AnamneseViewModel>(await _anamneseRepository.ObterPorId(id.Value));

            PreencherRadiosValues(AnamneseViewModel);

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

            PreencherPropriedadesBoleans(anamnese);

            await _pacienteService.AtualizarAnamnese(anamnese);

            StatusMessage = "Anamnase foi alterada";
            return RedirectToPage(new { pacienteId = AnamneseViewModel.PacienteId, id = AnamneseViewModel.Id });
        }

        private void PreencherPropriedadesBoleans(Anamnese anamnese)
        {
            if (!string.IsNullOrWhiteSpace(PressaoAltaRadio) && !PressaoAltaRadio.Equals("N�o sei"))
            {
                anamnese.PressaoAlta = PressaoAltaRadio.Equals("Sim");
            }

            if (!string.IsNullOrWhiteSpace(PraticaAtividadeFisicaRadio) && !PraticaAtividadeFisicaRadio.Equals("N�o sei"))
            {
                anamnese.PraticaAtividadeFisica = PraticaAtividadeFisicaRadio.Equals("Sim");
            }

            if (!string.IsNullOrWhiteSpace(ConsumeSubstanciasRadio) && !ConsumeSubstanciasRadio.Equals("N�o sei"))
            {
                anamnese.ConsumeSubstancias = ConsumeSubstanciasRadio.Equals("Sim");
            }

            if (!string.IsNullOrWhiteSpace(ContraturaMuscularRadio) && !ContraturaMuscularRadio.Equals("N�o sei"))
            {
                anamnese.ContraturaMuscular = ContraturaMuscularRadio.Equals("Sim");
            }

            if (!string.IsNullOrWhiteSpace(RetracaoMuscularRadio) && !RetracaoMuscularRadio.Equals("N�o sei"))
            {
                anamnese.RetracaoMuscular = RetracaoMuscularRadio.Equals("Sim");
            }
        }

        private void PreencherRadiosValues(AnamneseViewModel anamnese)
        {
            if (anamnese.PressaoAlta.HasValue)
            {
                PressaoAltaRadio = anamnese.PressaoAlta.Value ? "Sim" : "N�o";
            }

            if (anamnese.PraticaAtividadeFisica.HasValue)
            {
                PraticaAtividadeFisicaRadio = anamnese.PraticaAtividadeFisica.Value ? "Sim" : "N�o";
            }

            if (anamnese.ConsumeSubstancias.HasValue)
            {
                ConsumeSubstanciasRadio = anamnese.ConsumeSubstancias.Value ? "Sim" : "N�o";
            }

            if (anamnese.ContraturaMuscular.HasValue)
            {
                ContraturaMuscularRadio = anamnese.ContraturaMuscular.Value ? "Sim" : "N�o";
            }
            
            if (anamnese.RetracaoMuscular.HasValue)
            {
                RetracaoMuscularRadio = anamnese.RetracaoMuscular.Value ? "Sim" : "N�o";
            }
        }
    }
}
