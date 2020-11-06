using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class NivelIdioma
    {
        public NivelIdioma()
        {
            Idioma = new HashSet<Idioma>();
        }

        public int IdNivelIdioma { get; set; }
        public string NomeNivel { get; set; }

        public virtual ICollection<Idioma> Idioma { get; set; }
    }
}
