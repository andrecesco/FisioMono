using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Data.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(FisioterapiaDbContext context) : base(context) { }

        public async Task<Paciente> ObterPacienteCompleto(Guid id)
        {
            return await Db.Pacientes
                .Include(p => p.Anamnese)
                .Include(p => p.Convenios)
                .Include(p => p.Enderecos)
                .Include(p => p.Condutas)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id.Equals(id))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Paciente>> ObterPacientesCondutas()
        {
            return await Db.Pacientes
                .Include(p => p.Condutas)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
