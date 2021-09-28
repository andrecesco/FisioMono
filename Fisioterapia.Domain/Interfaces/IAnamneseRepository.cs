using Fisioterapia.Core.Data;
using Fisioterapia.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces
{
    public interface IAnamneseRepository : IRepository<Anamnese>
    {
        Task<Anamnese> ObterAnamnesePorIdPaciente(Guid pacienteId);
    }
}
