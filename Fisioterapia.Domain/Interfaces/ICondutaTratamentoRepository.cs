using Fisioterapia.Core.Data;
using Fisioterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces
{
    public interface ICondutaTratamentoRepository : IRepository<CondutaTratamento>
    {
        Task<IEnumerable<CondutaTratamento>> ObterTodosPorConduta(Guid id);
    }
}
