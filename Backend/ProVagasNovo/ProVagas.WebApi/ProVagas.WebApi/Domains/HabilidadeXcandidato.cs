﻿using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class HabilidadeXcandidato
    {
        public int IdHabilidadeCandidato { get; set; }
        public int? IdHabilidade { get; set; }
        public int? IdCandidato { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}