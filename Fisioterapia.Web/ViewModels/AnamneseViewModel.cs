using System;

namespace Fisioterapia.Web.ViewModels
{
    public class AnamneseViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }
        public string QP { get; set; }
        public string Investigacao { get; set; }
        public string HPM { get; set; }
        public bool? PressaoAlta { get; set; }
        public string MedicamentoParaPressao { get; set; }
        public bool? PraticaAtividadeFisica { get; set; }
        public string NomeAtividadeFisica { get; set; }
        public string ExameFisioPostural { get; set; }
        public bool? ConsumeSubstancias { get; set; }
        public string AlgiaPalpacao { get; set; }
        public string TonusMuscular { get; set; }
        public string HipotrofiaMuscular { get; set; }
        public bool? ContraturaMuscular { get; set; }
        public string ContraturaMuscularObservacao { get; set; }
        public bool? RetracaoMuscular { get; set; }
        public string RetracaoMuscularObservacao { get; set; }

        //EF: Relations
        public PacienteViewModel Paciente { get; set; }
    }
}
