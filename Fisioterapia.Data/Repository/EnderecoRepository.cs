using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(FisioterapiaDbContext context) : base(context) { }

        public async Task<IEnumerable<Endereco>> ObterEnderecosPorIdPaciente(Guid pacienteId)
        {
            return await Db.Enderecos
                .Include(c => c.Paciente)
                .Where(c => c.PacienteId.Equals(pacienteId))
                .OrderBy(c => c.Logradouro)
                .AsNoTracking()
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
