using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Habilidades
    {
        public Habilidades()
        {
            HabilidadeXcandidato = new HashSet<HabilidadeXcandidato>();
        }

        public int IdHabilidades { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual ICollection<HabilidadeXcandidato> HabilidadeXcandidato { get; set; }
    }
}
