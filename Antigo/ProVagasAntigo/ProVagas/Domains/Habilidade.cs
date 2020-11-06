using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            HabilidadeXCandidato = new HashSet<HabilidadeXCandidato>();
        }

        public int IdHabilidade { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual ICollection<HabilidadeXCandidato> HabilidadeXCandidato { get; set; }
    }
}
