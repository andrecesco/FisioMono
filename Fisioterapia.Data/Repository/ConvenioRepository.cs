using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Data.Repository
{
    public class ConvenioRepository : Repository<Convenio>, IConvenioRepository
    {
        public ConvenioRepository(FisioterapiaDbContext context) : base(context) { }

        public async Task<IEnumerable<Convenio>> ObterConveniosPorIdPaciente(Guid pacienteId)
        {
            return await Db.Convenios
                .Include(c => c.Paciente)
                .Where(c => c.PacienteId.Equals(pacienteId))
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
