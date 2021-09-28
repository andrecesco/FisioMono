using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Data.Repository
{
    public class AnamneseRepository : Repository<Anamnese>, IAnamneseRepository
    {
        public AnamneseRepository(FisioterapiaDbContext context) : base(context) { }

        public async Task<Anamnese> ObterAnamnesePorIdPaciente(Guid pacienteId)
        {
            return await Db.Anamneses
                .Include(c => c.Paciente)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.PacienteId.Equals(pacienteId))
                .ConfigureAwait(false);
        }
    }
}
