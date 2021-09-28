using Fisioterapia.Core.DomainObjects;
using System;

namespace Fisioterapia.Domain.Models
{
    public class Convenio : Entity
    {
        public Guid PacienteId { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public bool Ativo { get; set; }

        //EF Relations
        public Paciente Paciente { get; set; }

        public Convenio()
        {

        }

        //public Convenio(string nome, string matricula, bool ativo)
        //{
        //    Nome = nome;
        //    Matricula = matricula;
        //    Ativo = ativo;
        //}
    }
}
