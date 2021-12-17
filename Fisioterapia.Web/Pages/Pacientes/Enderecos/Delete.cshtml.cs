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

namespace Fisioterapia.Web.Pages.Enderecos
{
    public class DeleteModel : PageModel
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IPacienteService _pacienteService;
        private readonly IMapper _mapper;

        public DeleteModel(IEnderecoRepository enderecoRepository, IPacienteService pacienteService, IMapper mapper)
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

        public async Task<IActionResult> OnPostAsync()
        {
            await _pacienteService.RemoverEndereco(EnderecoViewModel.Id);

            //return RedirectToPage("/Paciente/Enderecos", new { pacienteId = Endereco.PacienteId });
            var url = Url.Action("/Pacientes/Enderecos", new { pacienteId = EnderecoViewModel.PacienteId });
            url = url.Replace("/Delete", "");

            return new JsonResult(new { success = true, url });
        }
    }
}
