using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Condutas
{
    public class EditModel : PageModel
    {
        private readonly ICondutaService _condutaService;
        private readonly ICondutaRepository _condutaRepository;
        private readonly ITratamentoRepository _tratamentoRepository;
        private readonly IMapper _mapper;

        public EditModel(ICondutaService condutaService, ICondutaRepository condutaRepository, ITratamentoRepository tratamentoRepository, IMapper mapper)
        {
            _condutaService = condutaService;
            _condutaRepository = condutaRepository;
            _tratamentoRepository = tratamentoRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public CondutaViewModel CondutaViewModel { get; set; }

        [BindProperty]
        public List<SelectListItem> TratamentosSelectItens { get; set; }

        [BindProperty]
        public List<string> TratamentosSelecionados { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            CondutaViewModel = _mapper.Map<CondutaViewModel>(await _condutaRepository.ObterCondutaCompletaPorId(id.Value));
            
            await CarregarTela(CondutaViewModel.CondutaTratamentos);
            
            if (CondutaViewModel is null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CarregarTela(CondutaViewModel.CondutaTratamentos);

                return Page();
            }

            var conduta = _mapper.Map<Conduta>(CondutaViewModel);

            var condutaTratamentos = new List<CondutaTratamento>();

            var tratamentos = await _tratamentoRepository.ObterTodos();

            foreach (var tratamentoSelecionado in TratamentosSelecionados)
            {
                if (tratamentos.Any(a => a.Id == Guid.Parse(tratamentoSelecionado)))
                {
                    condutaTratamentos.Add(new CondutaTratamento
                    {
                        TratamentoId = Guid.Parse(tratamentoSelecionado),
                        CondutaId = conduta.Id
                    });
                }
            }

            await _condutaService.AdicionarCondutaTratamentos(conduta.Id, condutaTratamentos);
            await _condutaService.Atualizar(conduta);

            return RedirectToPage("./Index", new { pacienteId = conduta.PacienteId });
        }

        private async Task CarregarTela(IEnumerable<CondutaTratamentoViewModel> condutaTratamentoViewModels)
        {
            var tratamentos = await _tratamentoRepository.ObterTodos();
            TratamentosSelecionados = new List<string>();
            TratamentosSelectItens = new List<SelectListItem>();

            foreach (var item in tratamentos)
            {
                var selecionado = false;
                if(condutaTratamentoViewModels.Any(c => c.TratamentoId == item.Id))
                {
                    selecionado = true;
                }

                TratamentosSelectItens.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nome, Selected = selecionado });
            }
        }
    }
}
