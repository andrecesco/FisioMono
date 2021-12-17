using System;
using System.ComponentModel.DataAnnotations;

namespace Fisioterapia.Web.ViewModels
{
    public class ConvenioViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Matricula { get; set; }
        public bool Ativo { get { return true; } }

        //EF Relations
        public PacienteViewModel Paciente { get; set; }
    }
}
