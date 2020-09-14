using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class RequisitosXvaga
    {
        public int IdRequisitosXvaga { get; set; }
        public int? IdRequisitos { get; set; }
        public int? IdVaga { get; set; }

        public virtual Requisitos IdRequisitosNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
    }
}
