using Fisioterapia.Core.Mediator;
using Fisioterapia.Core.Messages;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Notificacoes;
using Fisioterapia.Test.Fixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fisioterapia.Test.PacienteTest
{
    [Collection(nameof(PacienteServiceCollection))]
    public class PacienteServiceTest
    {
        private readonly PacienteServiceFixture _pacienteServiceTestsFixture;

        public PacienteServiceTest(PacienteServiceFixture pacienteServiceTestsFixture)
        {
            _pacienteServiceTestsFixture = pacienteServiceTestsFixture;
        }

        [Fact]
        public void PacienteService_AdicionarAnamnese_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarAnamneseValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;

            //Act
            var result = service.AdicionarAnamnese(model);

            //Assert
            mocker.GetMock<IAnamneseRepository>().Verify(r => r.Adicionar(model), Times.Once);
        }

        [Fact]
        public void PacienteService_AdicionarAnamnese_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarAnamneseInvalido();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;

            //Act
            var result = service.AdicionarAnamnese(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IAnamneseRepository>().Verify(r => r.Adicionar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_AtualizarAnamnese_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarAnamneseValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IAnamneseRepository>()
                .Setup(c => c.ObterPorId(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.AtualizarAnamnese(model);

            //Assert
            mocker.GetMock<IAnamneseRepository>().Verify(r => r.Atualizar(model), Times.Once);
        }

        [Fact]
        public void PacienteService_AtualizarAnamnese_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarAnamneseValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IAnamneseRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(model);

            //Act
            var result = service.AtualizarAnamnese(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IAnamneseRepository>().Verify(r => r.Atualizar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_RemoverAnamnese_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarAnamneseValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IAnamneseRepository>()
                .Setup(c => c.ObterPorId(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.RemoverAnamnese(model.Id);

            //Assert
            mocker.GetMock<IAnamneseRepository>().Verify(r => r.Remover(model), Times.Once);
        }

        [Fact]
        public void PacienteService_RemoverAnamnese_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarAnamneseValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IAnamneseRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(model);

            //Act
            var result = service.RemoverAnamnese(model.Id);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IAnamneseRepository>().Verify(r => r.Remover(model), Times.Never);
        }

        [Fact]
        public void PacienteService_AdicionarEndereco_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarEnderecoValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;

            //Act
            var result = service.AdicionarEndereco(model);

            //Assert
            mocker.GetMock<IEnderecoRepository>().Verify(r => r.Adicionar(model), Times.Once);
        }

        [Fact]
        public void PacienteService_AdicionarEndereco_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarEnderecoInvalido();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;

            //Act
            var result = service.AdicionarEndereco(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Exactly(14));
            mocker.GetMock<IEnderecoRepository>().Verify(r => r.Adicionar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_AtualizarEndereco_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarEnderecoValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IEnderecoRepository>()
                .Setup(c => c.ObterPorId(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.AtualizarEndereco(model);

            //Assert
            mocker.GetMock<IEnderecoRepository>().Verify(r => r.Atualizar(model), Times.Once);
        }

        [Fact]
        public void PacienteService_AtualizarEndereco_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarEnderecoValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IEnderecoRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(model);

            //Act
            var result = service.AtualizarEndereco(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IEnderecoRepository>().Verify(r => r.Atualizar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_RemoverEndereco_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarEnderecoValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IEnderecoRepository>()
                .Setup(c => c.ObterPorId(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.RemoverEndereco(model.Id);

            //Assert
            mocker.GetMock<IEnderecoRepository>().Verify(r => r.Remover(model), Times.Once);
        }

        [Fact]
        public void PacienteService_RemoverEndereco_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarEnderecoValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IEnderecoRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(model);

            //Act
            var result = service.RemoverEndereco(model.Id);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IEnderecoRepository>().Verify(r => r.Remover(model), Times.Never);
        }

        [Fact]
        public void PacienteService_AdicionarConvenio_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarConvenioValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;

            //Act
            var result = service.AdicionarConvenio(model);

            //Assert
            mocker.GetMock<IConvenioRepository>().Verify(r => r.Adicionar(model), Times.Once);
        }

        [Fact]
        public void PacienteService_AdicionarConvenio_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarConvenioInvalido();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;

            //Act
            var result = service.AdicionarConvenio(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Exactly(3));
            mocker.GetMock<IConvenioRepository>().Verify(r => r.Adicionar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_AtualizarConvenio_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarConvenioValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IConvenioRepository>()
                .Setup(c => c.ObterPorId(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.AtualizarConvenio(model);

            //Assert
            mocker.GetMock<IConvenioRepository>().Verify(r => r.Atualizar(model), Times.Once);
        }

        [Fact]
        public void PacienteService_AtualizarConvenio_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarConvenioValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IConvenioRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(model);

            //Act
            var result = service.AtualizarConvenio(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IConvenioRepository>().Verify(r => r.Atualizar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_RemoverConvenio_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarConvenioValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IConvenioRepository>()
                .Setup(c => c.ObterPorId(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.RemoverConvenio(model.Id);

            //Assert
            mocker.GetMock<IConvenioRepository>().Verify(r => r.Remover(model), Times.Once);
        }

        [Fact]
        public void PacienteService_RemoverConvenio_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarConvenioValido(Guid.NewGuid());
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IConvenioRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(model);

            //Act
            var result = service.RemoverConvenio(model.Id);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IConvenioRepository>().Verify(r => r.Remover(model), Times.Never);
        }

        [Fact]
        public void PacienteService_AdicionarPaciente_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarPacienteValido();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;

            //Act
            var result = service.Adicionar(model);

            //Assert
            mocker.GetMock<IPacienteRepository>().Verify(r => r.Adicionar(model), Times.Once);
        }

        [Fact]
        public void PacienteService_AdicionarPaciente_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarPacienteInvalido();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;

            //Act
            var result = service.Adicionar(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Exactly(4));
            mocker.GetMock<IPacienteRepository>().Verify(r => r.Adicionar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_AdicionarPaciente_ErroDocumentoJaExistente()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarPacientesValidos().First();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IPacienteRepository>()
                .Setup(c => c.Buscar(p => p.Documento.Equals(model.Documento)).Result)
                .Returns(PacienteServiceFixture.GerarPacientesValidos());

            //Act
            var result = service.Adicionar(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IPacienteRepository>().Verify(r => r.Adicionar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_AtualizarPaciente_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarPacienteValido();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IPacienteRepository>()
                .Setup(c => c.ObterPorId(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.Atualizar(model);

            //Assert
            mocker.GetMock<IPacienteRepository>().Verify(r => r.Atualizar(model), Times.Once);
        }

        [Fact]
        public void PacienteService_AtualizarPaciente_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarPacienteValido();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IPacienteRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(model);

            //Act
            var result = service.Atualizar(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IPacienteRepository>().Verify(r => r.Atualizar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_AtualizarPaciente_ErroDocumentoJaExistente()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarPacientesValidos().First();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IPacienteRepository>()
                .Setup(c => c.Buscar(f => f.Documento.Equals(model.Documento) && f.Id != model.Id).Result)
                .Returns(PacienteServiceFixture.GerarPacientesValidos());
            _pacienteServiceTestsFixture.Mocker.GetMock<IPacienteRepository>()
                .Setup(c => c.ObterPorId(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.Atualizar(model);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IPacienteRepository>().Verify(r => r.Adicionar(model), Times.Never);
        }

        [Fact]
        public void PacienteService_RemoverPaciente_DeveExecutarComSucesso()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarPacienteValido();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IPacienteRepository>()
                .Setup(c => c.ObterPacienteCompleto(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.Remover(model.Id);

            //Assert
            mocker.GetMock<IPacienteRepository>().Verify(r => r.Remover(model), Times.Once);
        }

        [Fact]
        public void PacienteService_RemoverPaciente_DeveExecutarComErro()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarPacienteValido();
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IPacienteRepository>()
                .Setup(c => c.ObterPorId(Guid.NewGuid()).Result)
                .Returns(model);

            //Act
            var result = service.Remover(model.Id);

            //Assert
            mocker.GetMock<INotificador>().Verify(a => a.Handle(It.IsAny<Notificacao>()), Times.Once);
            mocker.GetMock<IPacienteRepository>().Verify(r => r.Remover(model), Times.Never);
        }

        [Fact]
        public void PacienteService_RemoverPaciente_DeveRemoverTodasDependencias()
        {
            //Arrange
            var model = PacienteServiceFixture.GerarPacienteValido();
            model.Anamnese = PacienteServiceFixture.GerarAnamneseValido(model.Id);
            model.Enderecos = PacienteServiceFixture.GerarEnderecosValidos(model.Id);
            model.Convenios = PacienteServiceFixture.GerarConveniosValidos(model.Id);
            model.Condutas = PacienteServiceFixture.GerarCondutasValidas(model.Id);
            var service = _pacienteServiceTestsFixture.ObterPacienteSevice();
            var mocker = _pacienteServiceTestsFixture.Mocker;
            _pacienteServiceTestsFixture.Mocker.GetMock<IPacienteRepository>()
                .Setup(c => c.ObterPacienteCompleto(model.Id).Result)
                .Returns(model);

            //Act
            var result = service.Remover(model.Id);

            //Assert
            mocker.GetMock<IAnamneseRepository>().Verify(r => r.Remover(model.Anamnese), Times.Once);
            mocker.GetMock<IEnderecoRepository>().Verify(r => r.RemoverRange(model.Enderecos), Times.Once);
            mocker.GetMock<IConvenioRepository>().Verify(r => r.RemoverRange(model.Convenios), Times.Once);
            mocker.GetMock<IMediatorHandler>().Verify(a => a.PublicarEvento(It.IsAny<Event>()), Times.Once);
            mocker.GetMock<IPacienteRepository>().Verify(r => r.Remover(model), Times.Once);
        }
    }
}
