using Fisioterapia.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Fisioterapia.Domain.Models
{
    public class Conduta : Entity
    {
        public Guid PacienteId { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Tratamento> Tratamentos { get; set; }

        //EF Relations
        public Paciente Paciente { get; set; }
        public IEnumerable<CondutaTratamento> CondutaTratamentos { get; set; }

        public Conduta() { }

        //public Conduta(Guid pacienteId, string descricao)
        //{
        //    PacienteId = pacienteId;
        //    Descricao = descricao;
        //}
    }
}
