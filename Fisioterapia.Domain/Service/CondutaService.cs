using Fisioterapia.Core.Data;
using Fisioterapia.Domain.Interfaces;
using Fisioterapia.Domain.Models;
using Fisioterapia.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Domain.Service
{
    public class CondutaService : BaseService, ICondutaService, IDisposable
    {
        private readonly ICondutaRepository _condutaRepository;
        private readonly ICondutaTratamentoRepository _condutaTratamentoRepository;
        private readonly ITratamentoRepository _tratamentoRepository;

        public CondutaService(ICondutaRepository condutaRepository, ICondutaTratamentoRepository condutaTratamentoRepository, ITratamentoRepository tratamentoRepository, INotificador notificador) : base(notificador)
        {
            _condutaRepository = condutaRepository;
            _condutaTratamentoRepository = condutaTratamentoRepository;
            _tratamentoRepository = tratamentoRepository;
        }

        #region Conduta
        public async Task Adicionar(Conduta conduta)
        {
            if (!ExecutarValidacao(new CondutaValidation(), conduta))
            {
                return;
            }

            await _condutaRepository.Adicionar(conduta);
        }

        public async Task Atualizar(Conduta conduta)
        {
            if (!ExecutarValidacao(new CondutaValidation(), conduta))
            {
                return;
            }

            if (_condutaRepository.ObterPorId(conduta.Id).Result is null)
            {
                Notificar("Não foi encontrado nenhuma conduta!");
                return;
            }

            await _condutaRepository.Atualizar(conduta);
        }

        public async Task Remover(Guid id)
        {
            var conduta = await _condutaRepository.ObterPorId(id);
            if (conduta == null)
            {
                Notificar("Não foi encontrado nenhuma conduta!");
                return;
            }

            await _condutaRepository.Remover(conduta);
        }

        #endregion

        #region Conduta Tratamento
        public async Task AdicionarCondutaTratamentos(Guid condutaId, IEnumerable<CondutaTratamento> condutaTratamentos)
        {
            var condutasTratamentosModel = await _condutaTratamentoRepository.ObterTodosPorConduta(condutaId);

            if (condutasTratamentosModel.Any())
            {
                await _condutaTratamentoRepository.RemoverRange(condutasTratamentosModel);
            }

            if (condutaTratamentos.Any(ct => !ct.CondutaId.Equals(condutaId)))
            {
                Notificar("Todos os tratamentos devem pertencer a mesma conduta.");
                return;
            }

            foreach (var condutaTratamento in condutaTratamentos)
            {
                if (!ExecutarValidacao(new CondutaTratamentoValidation(), condutaTratamento))
                {
                    return;
                }
            }

            await _condutaTratamentoRepository.AdicionarRange(condutaTratamentos);
        }
        #endregion

        #region Tratamento
        public async Task AdicionarTratamento(Tratamento tratamento)
        {
            if (!ExecutarValidacao(new TratamentoValidation(), tratamento))
            {
                return;
            }

            await _tratamentoRepository.Adicionar(tratamento);
        }

        public async Task AtualizarTratamento(Tratamento tratamento)
        {
            if (!ExecutarValidacao(new TratamentoValidation(), tratamento))
            {
                return;
            }

            await _tratamentoRepository.Atualizar(tratamento);
        }

        public async Task RemoverTratamento(Guid id)
        {
            var tratamento = await _tratamentoRepository.ObterPorId(id);
            if (tratamento == null)
            {
                Notificar("Não foi encontrado nenhum tratamento!");
                return;
            }

            await _tratamentoRepository.Remover(tratamento);
        }

        #endregion

        public void Dispose()
        {
            _condutaRepository.Dispose();
            _condutaTratamentoRepository.Dispose();
            _tratamentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
