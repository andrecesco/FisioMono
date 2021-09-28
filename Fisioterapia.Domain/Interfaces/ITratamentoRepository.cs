using Fisioterapia.Core.Data;
using Fisioterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces
{
    public interface ITratamentoRepository : IRepository<Tratamento>
    {
        Task<IEnumerable<Tratamento>> ObterTratamentosPorConduta(Guid condutaId);
    }
}
