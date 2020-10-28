﻿using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class HabilidadeXCandidato
    {
        public int IdHabilidadeCandidato { get; set; }
        public int? IdHabilidade { get; set; }
        public int? IdCandidato { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
