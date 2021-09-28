using System;
using System.Collections.Generic;

namespace Fisioterapia.Core.Messages.IntegrationEvents
{
    public class PacienteRemovidoEvent : IntegrationEvent
    {
        public IEnumerable<Guid> CondutaIds { get; private set; }

        public PacienteRemovidoEvent(IEnumerable<Guid> condutaIds)
        {
            CondutaIds = condutaIds;
        }
    }
}
