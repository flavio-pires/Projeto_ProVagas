using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class HabilidadeXcandidato
    {
        public int IdHabilidadeXcandidato { get; set; }
        public int? IdHabilidades { get; set; }
        public int? IdCandidato { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
        public virtual Habilidades IdHabilidadesNavigation { get; set; }
    }
}
