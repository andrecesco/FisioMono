using Fisioterapia.Core.Data;
using Fisioterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces
{
    public interface IConvenioRepository : IRepository<Convenio>
    {
        Task<IEnumerable<Convenio>> ObterConveniosPorIdPaciente(Guid pacienteId);
    }
}
