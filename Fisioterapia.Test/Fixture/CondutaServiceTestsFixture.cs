using Bogus;
using Fisioterapia.Domain.Models;
using Fisioterapia.Domain.Service;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using Xunit;

namespace Fisioterapia.Test.Fixture
{
    [CollectionDefinition(nameof(CondutaServiceTestsCollection))]
    public class CondutaServiceTestsCollection : ICollectionFixture<CondutaServiceTestsFixture>
    {

    }

    public class CondutaServiceTestsFixture : IDisposable
    {
        public CondutaService CondutaService;
        public AutoMocker Mocker;  

        public Conduta GerarCondutaValida()
        {
            var condutaFaker = new Faker<Conduta>("pt_BR");
            condutaFaker.CustomInstantiator(f => new Conduta
            {
                PacienteId = Guid.NewGuid(),
                Descricao = f.Lorem.Text()
            });
            condutaFaker.RuleFor(c => c.Descricao, (f, c) => f.Lorem.Text());
            return condutaFaker;
        }

        public static Conduta GerarCondutaInvalida()
        {
            return new Conduta
            {
                Descricao = string.Empty
            };
        }

        public Tratamento ObterTratamentoValido()
        {
            var tratamentoFaker = new Faker<Tratamento>("pt_BR");
            tratamentoFaker.CustomInstantiator(f => new Tratamento
            {
                Nome = f.Lorem.Word()
            });

            return tratamentoFaker;
        }

        public Tratamento ObterTratamentoInvalido()
        {
            return new Tratamento();
        }

        public IEnumerable<Tratamento> ObterTratamentos()
        {
            var tratamentoFaker = new Faker<Tratamento>("pt_BR");
            tratamentoFaker.CustomInstantiator(f => new Tratamento
            {
                Nome = f.Lorem.Word()
            });

            return tratamentoFaker.Generate(15);
        }

        public IEnumerable<CondutaTratamento> ObterCondutaTratamentosValidos(Guid condutaId)
        {
            var tratamentoFaker = new Faker<Tratamento>("pt_BR");
            tratamentoFaker.CustomInstantiator(f => new Tratamento
            {
                Nome = f.Lorem.Word()
            });

            var tratamentos = tratamentoFaker.Generate(15);

            var condutaTratamentos = new List<CondutaTratamento>(tratamentos.Count);
            foreach (var tratamento in tratamentos)
            {
                condutaTratamentos.Add(new CondutaTratamento { CondutaId = condutaId, TratamentoId = tratamento.Id });
            }

            return condutaTratamentos;
        }

        public IEnumerable<CondutaTratamento> ObterCondutaTratamentosInvalidos(Guid condutaId)
        {
            var tratamentoFaker = new Faker<Tratamento>("pt_BR");
            tratamentoFaker.CustomInstantiator(f => new Tratamento
            {
                Nome = f.Lorem.Word()
            });

            var tratamentos = tratamentoFaker.Generate(15);

            var condutaTratamentos = new List<CondutaTratamento>(tratamentos.Count);
            foreach (var tratamento in tratamentos)
            {
                condutaTratamentos.Add(new CondutaTratamento { CondutaId = condutaId });
            }

            return condutaTratamentos;
        }
        public IEnumerable<Conduta> ObterCondutasPorTratamento(Guid tratamentoId)
        {
            var condutaFaker = new Faker<Conduta>("pt_BR");
            condutaFaker.CustomInstantiator(f => new Conduta
            {
                PacienteId = Guid.NewGuid(),
                Descricao = f.Lorem.Text(),
                CondutaTratamentos = new List<CondutaTratamento> { new CondutaTratamento { TratamentoId = tratamentoId } }
            });
            return condutaFaker.Generate(15);
        }

        public CondutaService ObterCondutaSevice()
        {
            Mocker = new AutoMocker();
            CondutaService = Mocker.CreateInstance<CondutaService>();

            return CondutaService;
        }

        public void Dispose()
        {
            CondutaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
