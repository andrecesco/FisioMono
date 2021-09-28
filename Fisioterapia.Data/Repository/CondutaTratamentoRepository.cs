using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Data.Repository
{
    public class CondutaTratamentoRepository : Repository<CondutaTratamento>, ICondutaTratamentoRepository
    {
        public CondutaTratamentoRepository(FisioterapiaDbContext context) : base(context) { }

        public async Task<IEnumerable<CondutaTratamento>> ObterTodosPorConduta(Guid condutaId)
        {
            return await Db.CondutasTratamentos
                .Where(c => c.Id.Equals(condutaId))
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
