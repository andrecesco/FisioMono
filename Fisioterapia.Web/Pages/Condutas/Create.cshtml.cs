using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Fisioterapia.Web.Pages.Condutas
{
    public class CreateModel : PageModel
    {
        private readonly ICondutaService _condutaService;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ITratamentoRepository _tratamentoRepository;
        private readonly IMapper _mapper;

        public CreateModel(ICondutaService condutaService, IPacienteRepository pacienteRepository, ITratamentoRepository tratamentoRepository, IMapper mapper)
        {
            _condutaService = condutaService;
            _pacienteRepository = pacienteRepository;
            _tratamentoRepository = tratamentoRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public CondutaViewModel CondutaViewModel { get; set; }

        [BindProperty]
        public List<SelectListItem> TratamentosSelectItens { get; set; }

        [BindProperty]
        public List<string> TratamentosSelecionados { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid pacienteId)
        {
            var paciente = await _pacienteRepository.ObterPorId(pacienteId);
            if(paciente is null)
            {
                return NotFound();
            }

            await CarregarTela();

            CondutaViewModel = new CondutaViewModel
            {
                PacienteId = paciente.Id,
                Paciente = _mapper.Map<PacienteViewModel>(paciente)
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CarregarTela();

                return Page();
            }

            var conduta = _mapper.Map<Conduta>(CondutaViewModel);

            var condutaTratamentos = new List<CondutaTratamento>();

            var tratamentos = await _tratamentoRepository.ObterTodos();

            foreach (var tratamentoSelecionado in TratamentosSelecionados)
            {
                if(tratamentos.Any(a => a.Id == Guid.Parse(tratamentoSelecionado)))
                {
                    condutaTratamentos.Add(new CondutaTratamento
                    {
                        TratamentoId = Guid.Parse(tratamentoSelecionado)
                    });
                }
            }

            conduta.CondutaTratamentos = condutaTratamentos;

            await _condutaService.Adicionar(conduta);

            return RedirectToPage("./Index", new { pacienteId = conduta.PacienteId });
        }

        private async Task CarregarTela()
        {
            var tratamentos = await _tratamentoRepository.ObterTodos();
            TratamentosSelecionados = new List<string>();
            TratamentosSelectItens = new List<SelectListItem>();

            foreach (var item in tratamentos)
            {
                TratamentosSelectItens.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome });
            }
        }
    }
}
