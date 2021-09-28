using Fisioterapia.Core.DomainObjects;
using System;

namespace Fisioterapia.Domain.Models
{
    public class Endereco : Entity
    {
        public Guid PacienteId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        //EF: Relations
        public Paciente Paciente { get; set; }

        public Endereco()
        {

        }

        //public Endereco(Guid pacienteId, string logradouro, string numero, string complemento, string cidade, string estado, string cep)
        //{
        //    PacienteId = pacienteId;
        //    Logradouro = logradouro;
        //    Numero = numero;
        //    Complemento = complemento;
        //    Cidade = cidade;
        //    Estado = estado;
        //    CEP = cep;
        //}
    }
}
