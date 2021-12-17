using Fisioterapia.Core.Messages.IntegrationEvents;
using Fisioterapia.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Service
{
    public class PacienteHandler : INotificationHandler<PacienteRemovidoEvent>
    {
        private readonly ICondutaService _condutaService;

        public PacienteHandler(ICondutaService condutaService)
        {
            _condutaService = condutaService;
        }

        public async Task Handle(PacienteRemovidoEvent notification, CancellationToken cancellationToken)
        {
            //foreach (var condutaId in notification.CondutaIds)
            //{
            //    await _condutaService.Remover(condutaId);
            //}
        }
    }
}
