using Fisioterapia.Core.DomainObjects.Old;

namespace Fisioterapia.Domain.Models.Old
{
    public class ConfiguracaoOld : EntityOld
    {
        public string Nome { get; set; }

        public string Nome_Abrev { get; set; }

        public bool Ativo { get; set; }
    }
}
