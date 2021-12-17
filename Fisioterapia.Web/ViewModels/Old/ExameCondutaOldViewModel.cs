using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fisioterapia.Web.ViewModels.Old
{
    public class ExameCondutaOldViewModel
    {
        public int Id { get; set; }

        public int Paciente_Id { get; set; }

        public string Exame { get; set; }

        public string Conduta { get; set; }

        public DateTime? Data { get; set; }

        public DateTime Dthora { get; set; }
    }
}
