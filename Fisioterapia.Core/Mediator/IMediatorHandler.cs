using Fisioterapia.Core.Messages;
using System.Threading.Tasks;

namespace Fisioterapia.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
