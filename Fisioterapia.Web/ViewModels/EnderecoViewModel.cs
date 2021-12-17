using System;
using System.ComponentModel.DataAnnotations;

namespace Fisioterapia.Web.ViewModels
{
    public class EnderecoViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CEP { get; set; }

        //EF: Relations
        public PacienteViewModel Paciente { get; set; }
    }
}
