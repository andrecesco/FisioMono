using Fisioterapia.Web.Extensions;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fisioterapia.Web.ViewModels
{
    public class PacienteViewModel : BaseViewModel
    {
        [DisplayName("Documento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Documento { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeCompleto { get; set; }

        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "O campo {0} está no formato inválido")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        [Phone(ErrorMessage = "O campo {0} está no formato inválido")]
        public string Telefone { get; set; }

        [DisplayName("Celular")]
        [Phone(ErrorMessage = "O campo {0} está no formato inválido")]
        public string Celular { get; set; }

        [DisplayName("Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [DisplayName("Profissão")]
        public string Profissao { get; set; }
        
    }
}
