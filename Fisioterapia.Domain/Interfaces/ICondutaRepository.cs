using Fisioterapia.Core.Data;
using Fisioterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces
{
    public interface ICondutaRepository : IRepository<Conduta>
    {
        Task<IEnumerable<Conduta>> ObterCondutasPorPacienteId(Guid pacienteId);

        Task<IEnumerable<Conduta>> ObterCondutasPorTratamentoId(Guid tratamentoId);

        Task<Conduta> ObterCondutaCompletaPorId(Guid condutaId);
    }
}
