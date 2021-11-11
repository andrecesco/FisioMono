using System;
using System.ComponentModel;

namespace Fisioterapia.Web.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Data de criação")]
        public DateTime DataCriacao { get; set; }

        [DisplayName("Data de alteração")]
        public DateTime? DataAlteracao { get; set; }
    }
}
