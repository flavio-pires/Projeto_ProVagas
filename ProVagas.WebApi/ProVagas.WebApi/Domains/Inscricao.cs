﻿using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class Inscricao
    {
        public Inscricao()
        {
            Estagio = new HashSet<Estagio>();
        }

        public int IdInscricao { get; set; }
        public DateTime DataInscricao { get; set; }
        public int? IdVaga { get; set; }
        public int? IdStatusInscricao { get; set; }
        public int? IdCandidato { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
        public virtual StatusInscricao IdStatusInscricaoNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
        public virtual ICollection<Estagio> Estagio { get; set; }
    }
}
