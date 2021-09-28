using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fisioterapia.Data.Repository
{
    public class TratamentoRepository : Repository<Tratamento>, ITratamentoRepository
    {
        public TratamentoRepository(FisioterapiaDbContext context) : base(context) { }

        public async Task<IEnumerable<Tratamento>> ObterTratamentosPorConduta(Guid condutaId)
        {
            return await Db.Tratamentos
                .Include(t => t.CondutaTratamentos)
                .ThenInclude(ct => ct.Conduta)
                .AsNoTracking()
                .Where(t => t.CondutaTratamentos.Any(ct => ct.CondutaId.Equals(condutaId)))
                .ToListAsync();
        }
    }
}
