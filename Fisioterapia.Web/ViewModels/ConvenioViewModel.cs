using System;

namespace Fisioterapia.Web.ViewModels
{
    public class ConvenioViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public bool Ativo { get; set; }

        //EF Relations
        public PacienteViewModel Paciente { get; set; }
    }
}
