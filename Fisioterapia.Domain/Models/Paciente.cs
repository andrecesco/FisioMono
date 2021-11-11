using Fisioterapia.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Fisioterapia.Domain.Models
{
    public class Paciente : Entity
    {
        public string Documento { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Profissao { get; set; }
        public bool Ativo { get; set; }

        //EF Relations
        public Anamnese Anamnese { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
        public IEnumerable<Conduta> Condutas { get; set; }
        public IEnumerable<Convenio> Convenios { get; set; }
    }
}
