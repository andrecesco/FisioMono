using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;

namespace Fisioterapia.Web.ViewModels
{
    public class AnamneseViewModel : BaseViewModel
    {
        public Guid PacienteId { get; set; }
        [DisplayName("QP")]
        public string QP { get; set; }

        [DisplayName("Investigação")]
        public string Investigacao { get; set; }

        [DisplayName("HPM")]
        public string HPM { get; set; }

        [DisplayName("Tem Pressão Alta?")]
        public bool? PressaoAlta { get; set; }

        [DisplayName("Medicamentos para pressão alta")]
        public string MedicamentoParaPressao { get; set; }

        [DisplayName("Prática atividade física?")]
        public bool? PraticaAtividadeFisica { get; set; }

        [DisplayName("Nome da atividade física")]
        public string NomeAtividadeFisica { get; set; }

        [DisplayName("Exame fisio postural")]
        public string ExameFisioPostural { get; set; }

        [DisplayName("Consome substâncias?")]
        public bool? ConsumeSubstancias { get; set; }

        [DisplayName("Algia palpação")]
        public string AlgiaPalpacao { get; set; }

        [DisplayName("Tônus muscular")]
        public string TonusMuscular { get; set; }

        [DisplayName("Hipotrofia muscular")]
        public string HipotrofiaMuscular { get; set; }

        [DisplayName("Contratura muscular?")]
        public bool? ContraturaMuscular { get; set; }

        [DisplayName("Contratura muscular observação")]
        public string ContraturaMuscularObservacao { get; set; }

        [DisplayName("Retração muscular?")]
        public bool? RetracaoMuscular { get; set; }

        [DisplayName("Retração muscular observação")]
        public string RetracaoMuscularObservacao { get; set; }

        //EF: Relations
        public PacienteViewModel Paciente { get; set; }
    }
}
