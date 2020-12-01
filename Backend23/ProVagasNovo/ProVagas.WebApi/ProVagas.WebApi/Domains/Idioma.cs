using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class Idioma
    {
        public int IdIdioma { get; set; }
        public string NomeIdioma { get; set; }
        public int? IdNivelIdioma { get; set; }
        public int? IdCandidato { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
        public virtual NivelIdioma IdNivelIdiomaNavigation { get; set; }
    }
}
