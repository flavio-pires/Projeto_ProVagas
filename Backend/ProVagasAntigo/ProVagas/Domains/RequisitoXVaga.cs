using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class RequisitoXVaga
    {
        public int IdRequisitoVaga { get; set; }
        public int? IdRequisito { get; set; }
        public int? IdVaga { get; set; }

        public virtual Requisito IdRequisitoNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
    }
}
