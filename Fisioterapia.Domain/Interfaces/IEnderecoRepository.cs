using Fisioterapia.Core.Data;
using Fisioterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<IEnumerable<Endereco>> ObterEnderecosPorIdPaciente(Guid pacienteId);
    }
}
