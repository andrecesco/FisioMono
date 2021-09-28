using Fisioterapia.Core.Data;
using Fisioterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<Paciente> ObterPacienteCompleto(Guid id);

        Task<IEnumerable<Paciente>> ObterPacientesCondutas();
    }
}
