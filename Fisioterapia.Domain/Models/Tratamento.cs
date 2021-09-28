using Fisioterapia.Core.DomainObjects;
using System.Collections.Generic;

namespace Fisioterapia.Domain.Models
{
    public class Tratamento : Entity
    {
        public string Nome { get; set; }

        //EF Relations
        public IEnumerable<CondutaTratamento> CondutaTratamentos { get; set; }

        public Tratamento()
        {

        }

        //public Tratamento(string nome)
        //{
        //    Nome = nome;
        //}
    }
}
