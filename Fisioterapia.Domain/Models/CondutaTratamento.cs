using Fisioterapia.Core.DomainObjects;
using System;

namespace Fisioterapia.Domain.Models
{
    public class CondutaTratamento : Entity
    {
        public Guid CondutaId { get; set; }
        public Guid TratamentoId { get; set; }

        //EF Relations
        public Conduta Conduta { get; set; }
        public Tratamento Tratamento { get; set; }


        public CondutaTratamento() { }

        //public CondutaTratamento(Guid condutaId, Guid tratamentoId)
        //{
        //    CondutaId = condutaId;
        //    TratamentoId = tratamentoId;
        //}
    }
}
