using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class NivelIngles
    {
        public NivelIngles()
        {
            Candidato = new HashSet<Candidato>();
        }

        public int IdNivelIngles { get; set; }
        public string Ingles { get; set; }

        public virtual ICollection<Candidato> Candidato { get; set; }
    }
}
