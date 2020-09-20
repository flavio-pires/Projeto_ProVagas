using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            HabilidadeXcandidato = new HashSet<HabilidadeXcandidato>();
        }

        public int IdHabilidade { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual ICollection<HabilidadeXcandidato> HabilidadeXcandidato { get; set; }
    }
}
