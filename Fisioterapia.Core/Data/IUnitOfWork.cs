using System.Threading.Tasks;

namespace Fisioterapia.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
