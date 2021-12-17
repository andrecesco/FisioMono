using Fisioterapia.Domain.Interfaces.Old;
using Fisioterapia.Domain.Models.Old;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Data.Repository.Old
{
    public class ExameCondutaOldRepository : RepositoryOld<ExameCondutaOld>, IExameCondutaOldRepository
    {
        public ExameCondutaOldRepository(FisioterapiaDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<ExameCondutaOld>> ObterExameCondutaPorPacienteId(int pacienteId)
        {
            return await Db.Exame_Conduta
                .Where(e => e.Paciente_Id == pacienteId)
                .OrderByDescending(e => e.Data)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
