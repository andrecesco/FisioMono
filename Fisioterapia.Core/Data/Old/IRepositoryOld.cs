using Fisioterapia.Core.DomainObjects.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisioterapia.Core.Data.Old
{
    public interface IRepositoryOld<TEntity> : IDisposable where TEntity : EntityOld
    {
        Task<TEntity> ObterPorId(int id);

        Task<IEnumerable<TEntity>> ObterTodos();
    }
}
