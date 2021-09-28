using Fisioterapia.Core.DomainObjects;
using System;

namespace Fisioterapia.Domain.Models
{
    public class Anamnese : Entity
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
        public Paciente Paciente { get; set; }

        public Anamnese()
        {

        }

        //public Anamnese(Guid pacienteId, string qp, string investigacao, string hpm, bool? pressaoAlta, string medicamentoParaPressao, bool? praticaAtividadeFisica, string nomeAtividadeFisica, string exameFisioPostural, bool? consumeSubstancias, string algiaPalpacao, string tonusMuscular, string hipotrofiaMuscular, bool? contraturaMuscular, string contraturaMuscularObservacao, bool? retracaoMuscular, string retracaoMuscularObservacao)
        //{
        //    PacienteId = pacienteId;
        //    QP = qp;
        //    Investigacao = investigacao;
        //    HPM = hpm;
        //    PressaoAlta = pressaoAlta;
        //    MedicamentoParaPressao = medicamentoParaPressao;
        //    PraticaAtividadeFisica = praticaAtividadeFisica;
        //    NomeAtividadeFisica = nomeAtividadeFisica;
        //    ExameFisioPostural = exameFisioPostural;
        //    ConsumeSubstancias = consumeSubstancias;
        //    AlgiaPalpacao = algiaPalpacao;
        //    TonusMuscular = tonusMuscular;
        //    HipotrofiaMuscular = hipotrofiaMuscular;
        //    ContraturaMuscular = contraturaMuscular;
        //    ContraturaMuscularObservacao = contraturaMuscularObservacao;
        //    RetracaoMuscular = retracaoMuscular;
        //    RetracaoMuscularObservacao = retracaoMuscularObservacao;
        //}

    }
}
