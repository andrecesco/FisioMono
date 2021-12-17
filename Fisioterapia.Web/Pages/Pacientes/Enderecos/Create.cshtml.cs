using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Enderecos
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
            EnderecoViewModel = new EnderecoViewModel
            {
                PacienteId = pacienteId
            };
            return Page();
        }

        [BindProperty]
        public EnderecoViewModel EnderecoViewModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var endereco = _mapper.Map<Endereco>(EnderecoViewModel);

            await _pacienteService.AdicionarEndereco(endereco);

            //return RedirectToPage("/Paciente/Convenios", new { pacienteId = convenio.PacienteId });
            var url = Url.Action("/Pacientes/Enderecos", new { pacienteId = endereco.PacienteId });
            url = url.Replace("/Create", "");
            return new JsonResult(new { success = true, url });
        }
    }
}
