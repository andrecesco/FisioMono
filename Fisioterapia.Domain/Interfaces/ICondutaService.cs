using Fisioterapia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Interfaces
{
    public interface ICondutaService
    {
        Task Adicionar(Conduta conduta);

        Task Atualizar(Conduta conduta);

        Task AdicionarCondutaTratamentos(Guid condutaId, IEnumerable<CondutaTratamento> condutaTratamentos);

        Task Remover(Guid id);

        Task AdicionarTratamento(Tratamento tratamento);

        Task AtualizarTratamento(Tratamento tratamento);

        Task RemoverTratamento(Guid id);
    }
}
