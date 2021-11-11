using System;
using System.ComponentModel;

namespace Fisioterapia.Web.ViewModels
{
    public class TratamentoViewModel : BaseViewModel
    {
        [DisplayName("Nome do tratamento")]
        public string Nome { get; set; }
    }
}
