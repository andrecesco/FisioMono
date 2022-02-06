using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fisioterapia.Web.ViewModels
{
    public class CondutaViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime? DataConduta { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        //EF Relations
        public PacienteViewModel Paciente { get; set; }

        [DisplayName("Tratamentos")]
        public IEnumerable<CondutaTratamentoViewModel> CondutaTratamentos { get; set; }
    }
}
