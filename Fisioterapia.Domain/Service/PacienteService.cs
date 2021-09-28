using Fisioterapia.Core.Mediator;
using Fisioterapia.Core.Messages.IntegrationEvents;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Domain.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Service
{
    public class PacienteService : BaseService, IPacienteService, IDisposable
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IAnamneseRepository _anamneseRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IConvenioRepository _convenioRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public PacienteService(IPacienteRepository pacienteRepository, IAnamneseRepository anamneseRepository, IEnderecoRepository enderecoRepository, IConvenioRepository convenioRepository, IMediatorHandler mediatorHandler, INotificador notificador) : base(notificador)
        {
            _pacienteRepository = pacienteRepository;
            _anamneseRepository = anamneseRepository;
            _enderecoRepository = enderecoRepository;
            _convenioRepository = convenioRepository;
            _mediatorHandler = mediatorHandler;
        }

        #region Anmnese
        public async Task AdicionarAnamnese(Anamnese anamnese)
        {
            if (!ExecutarValidacao(new AnamneseValidation(), anamnese))
            {
                return;
            }

            await _anamneseRepository.Adicionar(anamnese);
        }

        public async Task AtualizarAnamnese(Anamnese anamnese)
        {
            if (_anamneseRepository.ObterPorId(anamnese.Id).Result is null)
            {
                Notificar("Não foi encontrado nenhum anamnese!");
                return;
            }

            if (!ExecutarValidacao(new AnamneseValidation(), anamnese))
            {
                return;
            }

            await _anamneseRepository.Atualizar(anamnese);
        }

        public async Task RemoverAnamnese(Guid id)
        {
            var anamnese = await _anamneseRepository.ObterPorId(id);
            if (anamnese is null)
            {
                Notificar("Não foi encontrado nenhum anamnese!");
                return;
            }

            await _anamneseRepository.Remover(anamnese);
        }
        #endregion

        #region Endereço
        public async Task AdicionarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco))
            {
                return;
            }

            await _enderecoRepository.Adicionar(endereco);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (_enderecoRepository.ObterPorId(endereco.Id).Result is null)
            {
                Notificar("Não foi encontrado nenhum endereço!");
                return;
            }

            if (!ExecutarValidacao(new EnderecoValidation(), endereco))
            {
                return;
            }

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task RemoverEndereco(Guid id)
        {
            var endereco = await _enderecoRepository.ObterPorId(id);
            if (endereco is null)
            {
                Notificar("Não foi encontrado nenhum endereço!");
                return;
            }

            await _enderecoRepository.Remover(endereco);
        }
        #endregion

        #region Convenio
        public async Task AdicionarConvenio(Convenio convenio)
        {
            if (!ExecutarValidacao(new ConvenioValidation(), convenio))
            {
                return;
            }

            await _convenioRepository.Adicionar(convenio);
        }

        public async Task AtualizarConvenio(Convenio convenio)
        {
            if (_convenioRepository.ObterPorId(convenio.Id).Result is null)
            {
                Notificar("Não foi encontrado nenhum convênio!");
                return;
            }

            if (!ExecutarValidacao(new ConvenioValidation(), convenio))
            {
                return;
            }

            await _convenioRepository.Atualizar(convenio);
        }

        public async Task RemoverConvenio(Guid id)
        {
            var convenio = await _convenioRepository.ObterPorId(id);
            if (convenio is null)
            {
                Notificar("Não foi encontrado nenhum convênio!");
                return;
            }

            await _convenioRepository.Remover(convenio);
        }
        #endregion

        #region Paciente
        public async Task Adicionar(Paciente paciente)
        {
            if (!ExecutarValidacao(new PacienteValidation(), paciente))
            {
                return;
            }

            if (_pacienteRepository.Buscar(p => p.Documento.Equals(paciente.Documento)).Result.Any())
            {
                Notificar("Já existe um paciente com este documento, por infomado.");
                return;
            }

            await _pacienteRepository.Adicionar(paciente);
        }

        public async Task Atualizar(Paciente paciente)
        {
            if (_pacienteRepository.ObterPorId(paciente.Id).Result is null)
            {
                Notificar("Não foi encontrado nenhum paciente!");
                return;
            }

            if (!ExecutarValidacao(new PacienteValidation(), paciente))
            {
                return;
            }

            if (_pacienteRepository.Buscar(f => f.Documento.Equals(paciente.Documento) && f.Id != paciente.Id).Result.Any())
            {
                Notificar("Já existe um paciente com este documento infomado.");
                return;
            }

            await _pacienteRepository.Atualizar(paciente);
        }

        public async Task Remover(Guid id)
        {
            var paciente = await _pacienteRepository.ObterPacienteCompleto(id);
            if (paciente is null)
            {
                Notificar("Não foi encontrado nenhum paciente!");
                return;
            }

            if (paciente.Enderecos is not null && paciente.Enderecos.Any())
            {
                await _enderecoRepository.RemoverRange(paciente.Enderecos);
            }

            if (paciente.Convenios is not null && paciente.Convenios.Any())
            {
                await _convenioRepository.RemoverRange(paciente.Convenios);
            }

            if (paciente.Anamnese is not null)
            {
                await _anamneseRepository.Remover(paciente.Anamnese);
            }

            if (paciente.Condutas is not null && paciente.Condutas.Any())
            {
                await _mediatorHandler.PublicarEvento(new PacienteRemovidoEvent(paciente.Condutas.Select(c => c.Id)));
            }

            await _pacienteRepository.Remover(paciente);
        }

        public Task ImprimirGuia(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void Dispose()
        {
            _anamneseRepository.Dispose();
            _convenioRepository.Dispose();
            _enderecoRepository.Dispose();
            _pacienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
