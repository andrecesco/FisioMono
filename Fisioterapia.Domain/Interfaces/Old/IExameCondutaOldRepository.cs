using Fisioterapia.Core.Data.Old;
using Fisioterapia.Domain.Models.Old;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces.Old
{
    public interface IExameCondutaOldRepository : IRepositoryOld<ExameCondutaOld>
    {
        Task<IEnumerable<ExameCondutaOld>> ObterExameCondutaPorPacienteId(int pacienteId);
    }
}
