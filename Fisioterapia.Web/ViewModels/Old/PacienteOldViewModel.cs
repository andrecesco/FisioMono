using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Web.ViewModels.Old
{
    public class PacienteOldViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int? Idade { get; set; }

        public string Profissao { get; set; }

        public string Empresa { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Cidade { get; set; }

        public string Cep { get; set; }

        public string Convenio { get; set; }

        public string Matricula { get; set; }

        public string Medico { get; set; }

        public string CRM { get; set; }

        public string QP { get; set; }

        public string Investigacao { get; set; }

        public string HPM { get; set; }

        public bool? Pressao { get; set; }

        public string Pressao_Medicamento { get; set; }

        public bool? Atividade_Fisica { get; set; }

        public string Nome_Ativ_Fisica { get; set; }

        public string Exame_Fisio_Postural { get; set; }

        public string Consumo_Subst { get; set; }

        public string Algia_Palpacao { get; set; }

        public string Algia_Palpacao_Obs { get; set; }

        public string Tonus_Muscular { get; set; }

        public string Hipotrofia_Muscular { get; set; }

        public bool? Contratura_Muscular { get; set; }

        public string Contratura_Obs { get; set; }

        public bool? Retracao_Muscular { get; set; }

        public string Retracao_Obs { get; set; }

        public DateTime? Data_Cadastro { get; set; }

        public bool Ativo { get; set; }

        public DateTime? Dt_nasc { get; set; }

        public string Email { get; set; }

        public DateTime Dthora { get; set; }
    }
}
