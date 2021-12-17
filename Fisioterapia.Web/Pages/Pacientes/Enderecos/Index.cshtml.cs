using AutoMapper;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Web.Pages.Pacientes.Enderecos
{
    public class IndexModel : PageModel
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public IndexModel(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [TempData]
        public Guid PacienteId { get; set; }

        public IList<EnderecoViewModel> EnderecosViewModels { get; set; }

        public async Task OnGetAsync(Guid pacienteId)
        {
            PacienteId = pacienteId;
            EnderecosViewModels = _mapper.Map<IList<EnderecoViewModel>>(await _enderecoRepository.ObterEnderecosPorIdPaciente(pacienteId));
        }
    }
}
