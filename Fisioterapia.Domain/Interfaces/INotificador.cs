using Fisioterapia.Domain.Notificacoes;
using System.Collections.Generic;

namespace Fisioterapia.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
