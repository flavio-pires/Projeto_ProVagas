using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class NivelEscolaridade
    {
        public NivelEscolaridade()
        {
            Candidato = new HashSet<Candidato>();
        }

        public int IdNivelEscolaridade { get; set; }
        public string Escolaridade { get; set; }

        public virtual ICollection<Candidato> Candidato { get; set; }
    }
}
