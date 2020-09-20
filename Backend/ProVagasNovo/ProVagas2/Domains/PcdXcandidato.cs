using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class PcdXcandidato
    {
        public int IdPcdCandidato { get; set; }
        public bool PossuiDeficiencia { get; set; }
        public int? IdCandidato { get; set; }
        public int? IdPcd { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
        public virtual Pcd IdPcdNavigation { get; set; }
    }
}
