using Fisioterapia.Core.Data.Old;
using Fisioterapia.Domain.Interfaces.Old;
using Fisioterapia.Domain.Models.Old;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fisioterapia.Data.Repository.Old
{
    public class ConfiguracaoOldRepository : RepositoryOld<ConfiguracaoOld>, IConfiguracaoOldRepository
    {
        public ConfiguracaoOldRepository(FisioterapiaDbContext db) : base(db)
        {
        }
    }
}
