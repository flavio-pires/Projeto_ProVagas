using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class Pcd
    {
        public Pcd()
        {
            PcdXcandidato = new HashSet<PcdXcandidato>();
        }

        public int IdPcd { get; set; }
        public string NomeDeficiencia { get; set; }

        public virtual ICollection<PcdXcandidato> PcdXcandidato { get; set; }
    }
}
