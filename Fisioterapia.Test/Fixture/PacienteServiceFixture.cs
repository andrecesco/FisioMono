using Bogus;
using Bogus.DataSets;
using Fisioterapia.Domain.Models;
using Fisioterapia.Domain.Service;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using Xunit;

namespace Fisioterapia.Test.Fixture
{
    [CollectionDefinition(nameof(PacienteServiceCollection))]
    public class PacienteServiceCollection : ICollectionFixture<PacienteServiceFixture>
    {

    }

    public class PacienteServiceFixture : IDisposable
    {
        public PacienteService PacienteService;
        public AutoMocker Mocker;

        public PacienteService ObterPacienteSevice()
        {
            Mocker = new AutoMocker();
            PacienteService = Mocker.CreateInstance<PacienteService>();

            return PacienteService;
        }

        public static Paciente GerarPacienteValido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var pacienteFaker = new Faker<Paciente>("pt_BR");
            pacienteFaker.CustomInstantiator(f => new Paciente
            {
                Documento = f.Random.Int(1000, int.MaxValue).ToString(),
                NomeCompleto = f.Name.FullName(genero),
                Telefone = f.Phone.PhoneNumber(),
                Celular = f.Phone.PhoneNumber(),
                DataNascimento = f.Date.Past(80, DateTime.Now.AddYears(-18)),
                Profissao = f.Lorem.Word(),
                Ativo = true
            }).RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.NomeCompleto.ToLower()));
            return pacienteFaker;
        }

        public static Paciente GerarPacienteInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var pacienteFaker = new Faker<Paciente>("pt_BR");
            pacienteFaker.CustomInstantiator(f => new Paciente
            {
                Documento = string.Empty,
                NomeCompleto = string.Empty,
                Telefone = f.Phone.PhoneNumber(),
                Celular = f.Phone.PhoneNumber(),
                DataNascimento = f.Date.Past(80, DateTime.Now.AddYears(-18)),
                Profissao = f.Lorem.Word(),
                Ativo = true
            }).RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.NomeCompleto.ToLower()));
            return pacienteFaker;
        }

        public static IEnumerable<Paciente> GerarPacientesValidos()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var pacienteFaker = new Faker<Paciente>("pt_BR");
            pacienteFaker.CustomInstantiator(f => new Paciente
            {
                Documento = f.Random.Int(1000, int.MaxValue).ToString(),
                NomeCompleto = f.Name.FullName(genero),
                Telefone = f.Phone.PhoneNumber(),
                Celular = f.Phone.PhoneNumber(),
                DataNascimento = f.Date.Past(80, DateTime.Now.AddYears(-18)),
                Profissao = f.Lorem.Word(),
                Ativo = true
            }).RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.NomeCompleto.ToLower()));
            return pacienteFaker.Generate(100);
        }

        public static IEnumerable<Paciente> GerarPacientesInvalidos()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var pacienteFaker = new Faker<Paciente>("pt_BR");
            pacienteFaker.CustomInstantiator(f => new Paciente
            {
                Documento = string.Empty,
                NomeCompleto = string.Empty,
                Telefone = f.Phone.PhoneNumber(),
                Celular = f.Phone.PhoneNumber(),
                DataNascimento = f.Date.Past(80, DateTime.Now.AddYears(-18)),
                Profissao = f.Lorem.Word(),
                Ativo = true
            }).RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.NomeCompleto.ToLower()));
            return pacienteFaker.Generate(100);
        }

        public static Anamnese GerarAnamneseValido(Guid pacienteId)
        {
            var modelFaker = new Faker<Anamnese>("pt_BR");
            modelFaker.CustomInstantiator(f => new Anamnese
            {
                PacienteId = pacienteId
            });
            return modelFaker;
        }

        public static Anamnese GerarAnamneseInvalido()
        {
            var modelFaker = new Faker<Anamnese>("pt_BR");
            modelFaker.CustomInstantiator(f => new Anamnese());
            return modelFaker;
        }

        public static Convenio GerarConvenioValido(Guid pacienteId)
        {
            var modelFaker = new Faker<Convenio>("pt_BR");
            modelFaker.CustomInstantiator(f => new Convenio
            {
                PacienteId = pacienteId,
                Nome = f.Lorem.Word(),
                Ativo = true
            });
            return modelFaker;
        }

        public static Convenio GerarConvenioInvalido()
        {
            var modelFaker = new Faker<Convenio>("pt_BR");
            modelFaker.CustomInstantiator(f => new Convenio
            {
                Nome = string.Empty,
                Ativo = true
            });
            return modelFaker;
        }

        public static IEnumerable<Convenio> GerarConveniosValidos(Guid pacienteId)
        {
            var modelFaker = new Faker<Convenio>("pt_BR");
            modelFaker.CustomInstantiator(f => new Convenio
            {
                PacienteId = pacienteId,
                Nome = f.Lorem.Word(),
                Ativo = true
            });
            return modelFaker.Generate(10);
        }

        public static IEnumerable<Convenio> GerarConveniosInvalidos(Guid pacienteId)
        {
            var modelFaker = new Faker<Convenio>("pt_BR");
            modelFaker.CustomInstantiator(f => new Convenio
            {
                PacienteId = pacienteId,
                Nome = string.Empty,
                Ativo = true
            });
            return modelFaker.Generate(10);
        }

        public static Endereco GerarEnderecoValido(Guid pacienteId)
        {
            var modelFaker = new Faker<Endereco>("pt_BR");
            modelFaker.CustomInstantiator(f => new Endereco
            {
                PacienteId = pacienteId,
                Logradouro = f.Address.StreetAddress(),
                Numero = f.Address.StreetAddress(),
                Complemento = f.Address.SecondaryAddress(),
                Bairro = f.Address.Country(),
                Cidade = f.Address.City(),
                Estado = f.Address.State(),
                CEP = f.Address.ZipCode()
            });
            return modelFaker;
        }

        public static Endereco GerarEnderecoInvalido()
        {
            var modelFaker = new Faker<Endereco>("pt_BR");
            modelFaker.CustomInstantiator(f => new Endereco
            {
                Logradouro = string.Empty,
                Numero = string.Empty,
                Complemento = string.Empty,
                Bairro = string.Empty,
                Cidade = string.Empty,
                Estado = string.Empty,
                CEP = string.Empty
            });
            return modelFaker;
        }

        public static IEnumerable<Endereco> GerarEnderecosValidos(Guid pacienteId)
        {
            var modelFaker = new Faker<Endereco>("pt_BR");
            modelFaker.CustomInstantiator(f => new Endereco
            {
                PacienteId = pacienteId,
                Logradouro = f.Address.StreetAddress(),
                Numero = f.Address.StreetAddress(),
                Complemento = f.Address.SecondaryAddress(),
                Bairro = f.Address.Country(),
                Cidade = f.Address.City(),
                Estado = f.Address.State(),
                CEP = f.Address.ZipCode()
            });
            return modelFaker.Generate(10);
        }

        public static IEnumerable<Endereco> GerarEnderecosInvalidos(Guid pacienteId)
        {
            var modelFaker = new Faker<Endereco>("pt_BR");
            modelFaker.CustomInstantiator(f => new Endereco
            {
                PacienteId = pacienteId,
                Logradouro = string.Empty,
                Numero = string.Empty,
                Complemento = string.Empty,
                Bairro = string.Empty,
                Cidade = string.Empty,
                Estado = string.Empty,
                CEP = string.Empty
            });
            return modelFaker.Generate(10);
        }

        public static IEnumerable<Conduta> GerarCondutasValidas(Guid pacienteId)
        {
            var condutaFaker = new Faker<Conduta>("pt_BR");
            condutaFaker.CustomInstantiator(f => new Conduta
            {
                PacienteId = pacienteId,
                Descricao = f.Lorem.Text(),
                CondutaTratamentos = new List<CondutaTratamento> { new CondutaTratamento { TratamentoId = Guid.NewGuid() } }
            });
            condutaFaker.RuleFor(c => c.Descricao, (f, c) => f.Lorem.Text());
            return condutaFaker.Generate(15);
        }

        public void Dispose()
        {
            PacienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
