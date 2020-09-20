using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class Estagio
    {
        public int IdEstagio { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFinal { get; set; }
        public int? IdInscricao { get; set; }
        public int? IdStatusEstagio { get; set; }

        public virtual Inscricao IdInscricaoNavigation { get; set; }
        public virtual StatusEstagio IdStatusEstagioNavigation { get; set; }
    }
}
