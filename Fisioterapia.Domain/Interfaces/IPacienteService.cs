using Fisioterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces
{
    public interface IPacienteService
    {
        Task Adicionar(Paciente paciente);
        
        Task Atualizar(Paciente paciente);
        
        Task Remover(Guid id);

        Task ImprimirGuia(Guid id);

        Task AdicionarAnamnese(Anamnese anamnese);
        Task AtualizarAnamnese(Anamnese anamnese);
        Task RemoverAnamnese(Guid id);

        Task AdicionarEndereco(Endereco endereco);
        Task AtualizarEndereco(Endereco endereco);
        Task RemoverEndereco(Guid id);

        Task AdicionarConvenio(Convenio convenio);
        Task AtualizarConvenio(Convenio convenio);
        Task RemoverConvenio(Guid id);
    }
}
