using System;
using System.Collections.Generic;

namespace Fisioterapia.Web.ViewModels
{
    public class CondutaViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<TratamentoViewModel> Tratamentos { get; set; }

        //EF Relations
        public PacienteViewModel Paciente { get; set; }
        public IEnumerable<CondutaTratamentoViewModel> CondutaTratamentos { get; set; }
    }
}
