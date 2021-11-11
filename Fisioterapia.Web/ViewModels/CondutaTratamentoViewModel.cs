using System;

namespace Fisioterapia.Web.ViewModels
{
    public class CondutaTratamentoViewModel : BaseViewModel
    {
        public Guid CondutaId { get; set; }
        public Guid TratamentoId { get; set; }

        //EF Relations
        public CondutaViewModel Conduta { get; set; }
        public TratamentoViewModel Tratamento { get; set; }
    }
}
