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
    public class EditModel : PageModel
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public EditModel(IEnderecoRepository enderecoRepository, IPacienteService pacienteService, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _pacienteService = pacienteService;
            _mapper = mapper;
        }

        [BindProperty]
        public EnderecoViewModel EnderecoViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var endereco = await _enderecoRepository.ObterPorId(id);

            if (endereco == null)
            {
                return NotFound();
            }

            EnderecoViewModel = _mapper.Map<EnderecoViewModel>(endereco);
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

            var endereco = _mapper.Map<Endereco>(EnderecoViewModel);

            await _pacienteService.AtualizarEndereco(endereco);

            //return RedirectToPage("/Paciente/Enderecos", new { pacienteId = Endereco.PacienteId });
            var url = Url.Action("/Pacientes/Enderecos", new { pacienteId = endereco.PacienteId });
            url = url.Replace("/Edit", "");

            return new JsonResult(new { success = true, url });
        }
    }
}
