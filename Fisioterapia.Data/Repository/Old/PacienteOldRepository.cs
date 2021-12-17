using Fisioterapia.Domain.Interfaces.Old;
using Fisioterapia.Domain.Models.Old;

namespace Fisioterapia.Data.Repository.Old
{
    public class PacienteOldRepository : RepositoryOld<PacienteOld>, IPacienteOldRepository
    {
        public PacienteOldRepository(FisioterapiaDbContext db) : base(db)
        {
        }
    }
}
