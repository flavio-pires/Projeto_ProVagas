using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class CursoSenai
    {
        public int IdCursoSenai { get; set; }
        public bool CursandoSenai { get; set; }
        public string Curso { get; set; }
        public int? IdCandidato { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
    }
}
