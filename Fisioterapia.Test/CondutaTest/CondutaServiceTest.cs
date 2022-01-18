using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Domain.Notificacoes;
using Fisioterapia.Test.Fixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Fisioterapia.Test.CondutaTest
{
    [Collection(nameof(CondutaServiceTestsCollection))]
    public class CondutaServiceTest
    {
        private readonly CondutaServiceTestsFixture _condutaServiceTestsFixture;

        public CondutaServiceTest(CondutaServiceTestsFixture condutaServiceTestsFixture)
        {
            _condutaServiceTestsFixture = condutaServiceTestsFixture;
        }

        [Fact]
        public void CondutaService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var conduta = _condutaServiceTestsFixture.GerarCondutaValida();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;

            //Act
            var result = condutaService.Adicionar(conduta);

            //Assert
            mocker.GetMock<ICondutaRepository>().Verify(r => r.Adicionar(conduta), Times.Once);
        }

        [Fact]
        public void CondutaService_Adicionar_DeveExecutarComErro()
        {
            //Arrange
            var conduta = CondutaServiceTestsFixture.GerarCondutaInvalida();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;

            //Act
            var result = condutaService.Adicionar(conduta);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Exactly(3));
            mocker.GetMock<ICondutaRepository>().Verify(r => r.Adicionar(conduta), Times.Never);
        }

        [Fact]
        public void CondutaService_Atualizar_DeveExecutarComSucesso()
        {
            //Arrange
            var conduta = _condutaServiceTestsFixture.GerarCondutaValida();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            _condutaServiceTestsFixture.Mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterPorId(conduta.Id).Result)
                .Returns(conduta);

            //Act
            var result = condutaService.Atualizar(conduta);

            //Assert
            mocker.GetMock<ICondutaRepository>().Verify(r => r.Atualizar(conduta), Times.Once);
        }

        [Fact]
        public void CondutaService_Atualizar_DeveExecutarComErro()
        {
            //Arrange
            var conduta = _condutaServiceTestsFixture.GerarCondutaValida();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            _condutaServiceTestsFixture.Mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterCondutaCompletaPorId(Guid.NewGuid()).Result)
                .Returns(conduta);

            //Act
            var result = condutaService.Atualizar(conduta);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<ICondutaRepository>().Verify(r => r.Atualizar(conduta), Times.Never);
        }

        [Fact]
        public void CondutaService_Remover_DeveExecutarComSucesso()
        {
            //Arrange
            var conduta = _condutaServiceTestsFixture.GerarCondutaValida();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            _condutaServiceTestsFixture.Mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterPorId(conduta.Id).Result)
                .Returns(conduta);

            //Act
            var result = condutaService.Remover(conduta.Id);

            //Assert
            mocker.GetMock<ICondutaRepository>().Verify(r => r.Remover(conduta), Times.Once);
            mocker.GetMock<ICondutaTratamentoRepository>().Verify(r => r.RemoverRange(conduta.CondutaTratamentos), Times.Never);
        }

        [Fact]
        public void CondutaService_Remover_DeveExecutarComErro()
        {
            //Arrange
            var conduta = _condutaServiceTestsFixture.GerarCondutaValida();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            _condutaServiceTestsFixture.Mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(conduta);

            //Act
            var result = condutaService.Remover(conduta.Id);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<ICondutaRepository>().Verify(r => r.Remover(conduta), Times.Never);
        }


        [Fact]
        public async Task CondutaService_AdicionarCondutaTratamentos_ComListaTratamentos_DeveExecutarComSucesso()
        {
            //Arrange
            var conduta = _condutaServiceTestsFixture.GerarCondutaValida();
            conduta.CondutaTratamentos = _condutaServiceTestsFixture.ObterCondutaTratamentosValidos(conduta.Id);
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            _condutaServiceTestsFixture.Mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterCondutaCompletaPorId(conduta.Id).Result)
                .Returns(conduta);
            _condutaServiceTestsFixture.Mocker.GetMock<ICondutaTratamentoRepository>()
                .Setup(c => c.ObterTodosPorConduta(conduta.Id).Result)
                .Returns(conduta.CondutaTratamentos);

            //Act
            await condutaService.AdicionarCondutaTratamentos(conduta.Id, conduta.CondutaTratamentos);

            //Assert
            mocker.GetMock<ICondutaTratamentoRepository>().Verify(r => r.RemoverRange(conduta.CondutaTratamentos), Times.Once);
            mocker.GetMock<ICondutaTratamentoRepository>().Verify(r => r.AdicionarRange(conduta.CondutaTratamentos), Times.Once);
        }

        [Fact]
        public async Task CondutaService_AdicionarCondutaTratamentos_SemListaTratamentos_DeveExecutarComSucesso()
        {
            //Arrange
            var conduta = _condutaServiceTestsFixture.GerarCondutaValida();
            conduta.CondutaTratamentos = _condutaServiceTestsFixture.ObterCondutaTratamentosValidos(conduta.Id);
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            _condutaServiceTestsFixture.Mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterCondutaCompletaPorId(conduta.Id).Result)
                .Returns(conduta);

            //Act
            await condutaService.AdicionarCondutaTratamentos(conduta.Id, conduta.CondutaTratamentos);

            //Assert
            mocker.GetMock<ICondutaTratamentoRepository>().Verify(r => r.RemoverRange(conduta.CondutaTratamentos), Times.Never);
            mocker.GetMock<ICondutaTratamentoRepository>().Verify(r => r.AdicionarRange(conduta.CondutaTratamentos), Times.Once);
        }

        [Fact]
        public async Task CondutaService_AdicionarCondutaTratamentos_ErroListaComIdCondutaDiferente()
        {
            //Arrange
            var conduta = _condutaServiceTestsFixture.GerarCondutaValida();
            conduta.CondutaTratamentos = _condutaServiceTestsFixture.ObterCondutaTratamentosValidos(Guid.NewGuid());
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterCondutaCompletaPorId(conduta.Id).Result)
                .Returns(conduta);

            //Act
            await condutaService.AdicionarCondutaTratamentos(conduta.Id, conduta.CondutaTratamentos);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<ICondutaTratamentoRepository>().Verify(r => r.RemoverRange(conduta.CondutaTratamentos), Times.Never);
            mocker.GetMock<ICondutaTratamentoRepository>().Verify(r => r.AdicionarRange(conduta.CondutaTratamentos), Times.Never);
        }

        [Fact]
        public async Task CondutaService_AdicionarCondutaTratamentos_ErroListaSemIdsTratamento()
        {
            //Arrange
            var conduta = _condutaServiceTestsFixture.GerarCondutaValida();
            conduta.CondutaTratamentos = _condutaServiceTestsFixture.ObterCondutaTratamentosValidos(Guid.NewGuid());
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterCondutaCompletaPorId(conduta.Id).Result)
                .Returns(conduta);

            //Act
            await condutaService.AdicionarCondutaTratamentos(conduta.Id, conduta.CondutaTratamentos);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<ICondutaTratamentoRepository>().Verify(r => r.RemoverRange(conduta.CondutaTratamentos), Times.Never);
            mocker.GetMock<ICondutaTratamentoRepository>().Verify(r => r.AdicionarRange(conduta.CondutaTratamentos), Times.Never);
        }

        [Fact]
        public void CondutaService_AdicionarTratamento_DeveExecutarComSucesso()
        {
            //Arrange
            var tratamento = _condutaServiceTestsFixture.ObterTratamentoValido();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;

            //Act
            var result = condutaService.AdicionarTratamento(tratamento);

            //Assert
            mocker.GetMock<ITratamentoRepository>().Verify(r => r.Adicionar(tratamento), Times.Once);
        }

        [Fact]
        public void CondutaService_AdicionarTratamento_DeveExecutarComErro()
        {
            //Arrange
            var tratamento = _condutaServiceTestsFixture.ObterTratamentoInvalido();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;

            //Act
            var result = condutaService.AdicionarTratamento(tratamento);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<ITratamentoRepository>().Verify(r => r.Adicionar(tratamento), Times.Never);
        }

        [Fact]
        public void CondutaService_AtualizarTratamento_DeveExecutarComSucesso()
        {
            //Arrange
            var tratamento = _condutaServiceTestsFixture.ObterTratamentoValido();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            mocker.GetMock<ITratamentoRepository>()
                .Setup(c => c.ObterPorId(tratamento.Id).Result)
                .Returns(tratamento);

            //Act
            var result = condutaService.AtualizarTratamento(tratamento);

            //Assert
            mocker.GetMock<ITratamentoRepository>().Verify(r => r.Atualizar(tratamento), Times.Once);
        }

        [Fact]
        public void CondutaService_AtualizarTratamento_DeveExecutarComErro()
        {
            //Arrange
            var tratamento = _condutaServiceTestsFixture.ObterTratamentoInvalido();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            mocker.GetMock<ITratamentoRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(tratamento);

            //Act
            var result = condutaService.AtualizarTratamento(tratamento);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<ITratamentoRepository>().Verify(r => r.Atualizar(tratamento), Times.Never);
        }

        [Fact]
        public void CondutaService_RemoverTratamento_DeveExecutarComSucesso()
        {
            //Arrange
            var tratamento = _condutaServiceTestsFixture.ObterTratamentoValido();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            mocker.GetMock<ITratamentoRepository>()
                .Setup(c => c.ObterPorId(tratamento.Id).Result)
                .Returns(tratamento);
            mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterCondutasPorTratamentoId(tratamento.Id).Result)
                .Returns(new List<Conduta>());

            //Act
            var result = condutaService.RemoverTratamento(tratamento.Id);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Never);
            mocker.GetMock<ITratamentoRepository>().Verify(r => r.Remover(tratamento), Times.Once);
        }

        [Fact]
        public void CondutaService_RemoverTratamento_ErroTratamentoNaoEncontrado()
        {
            //Arrange
            var tratamento = _condutaServiceTestsFixture.ObterTratamentoValido();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            mocker.GetMock<ITratamentoRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(tratamento);
            mocker.GetMock<ICondutaRepository>()
                .Setup(c => c.ObterCondutasPorTratamentoId(tratamento.Id).Result)
                .Returns(new List<Conduta>());

            //Act
            var result = condutaService.RemoverTratamento(tratamento.Id);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<ITratamentoRepository>().Verify(r => r.Remover(tratamento), Times.Never);
        }

        [Fact]
        public void CondutaService_RemoverTratamento_ErroTratamentoVinculadoComCondutas()
        {
            //Arrange
            var tratamento = _condutaServiceTestsFixture.ObterTratamentoValido();
            var condutaService = _condutaServiceTestsFixture.ObterCondutaSevice();
            var mocker = _condutaServiceTestsFixture.Mocker;
            mocker.GetMock<ITratamentoRepository>()
                .Setup(c => c.ObterPorId(tratamento.Id).Result)
                .Returns(tratamento);

            //Act
            var result = condutaService.RemoverTratamento(tratamento.Id);

            //Assert
            mocker.GetMock<ITratamentoRepository>().Verify(r => r.Remover(tratamento), Times.Once);
        }
    }
}