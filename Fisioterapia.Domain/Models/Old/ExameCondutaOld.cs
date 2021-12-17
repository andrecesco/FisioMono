using Fisioterapia.Core.DomainObjects.Old;
using System;

namespace Fisioterapia.Domain.Models.Old
{
    public class ExameCondutaOld : EntityOld
    {
        public int Paciente_Id { get; set; }

        public string Exame { get; set; }

        public string Conduta { get; set; }

        public DateTime? Data { get; set; }

        public DateTime Dthora { get; set; }
    }
}
