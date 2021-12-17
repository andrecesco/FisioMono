using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Data.Repository
{
    public class CondutaRepository : Repository<Conduta>, ICondutaRepository
    {
        public CondutaRepository(FisioterapiaDbContext context) : base(context) { }

        public async Task<Conduta> ObterCondutaCompletaPorId(Guid condutaId)
        {
            return await Db.Condutas
                .Include(c => c.CondutaTratamentos)
                .ThenInclude(ct => ct.Tratamento)
                .Include(c => c.Paciente)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id.Equals(condutaId))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Conduta>> ObterCondutasPorPacienteId(Guid pacienteId)
        {
            return await Db.Condutas
                .Include(c => c.Paciente)
                .Include(c => c.CondutaTratamentos)
                .ThenInclude(ct => ct.Tratamento)
                .Where(c => c.PacienteId.Equals(pacienteId))
                .OrderByDescending(c => c.DataConduta)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Conduta>> ObterCondutasPorTratamentoId(Guid tratamentoId)
        {
            return await Db.Condutas
                .Include(c => c.CondutaTratamentos)
                .ThenInclude(ct => ct.Tratamento)
                .Where(c => c.CondutaTratamentos.Any(ct => ct.TratamentoId.Equals(tratamentoId)))
                .OrderByDescending(c => c.DataConduta)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
