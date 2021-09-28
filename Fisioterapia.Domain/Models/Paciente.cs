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

        public Paciente()
        {

        }

        //public Paciente(string documento, string nomeCompleto, string email, string telefone, string celular, DateTime dataNascimento, string profissao, bool ativo)
        //{
        //    Documento = documento;
        //    NomeCompleto = nomeCompleto;
        //    Email = email;
        //    Telefone = telefone;
        //    Celular = celular;
        //    DataNascimento = dataNascimento;
        //    Profissao = profissao;
        //    Ativo = ativo;

        //    Validar();
        //}
        //public void Validar()
        //{
        //    Validacoes.ValidarSeVazio(Documento, "O documento do paciente não pode ser vazio");
        //    Validacoes.ValidarSeDiferente(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", Documento, "O documento não pode ser inválido");
        //    Validacoes.ValidarSeVazio(NomeCompleto, "O nome do paciente não pode ser vazio");
        //    if (!string.IsNullOrWhiteSpace(Email))
        //    {
        //        Validacoes.ValidarSeDiferente(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", Email, "O e-mail não pode ser inválido");
        //    }
        //}
    }
}
