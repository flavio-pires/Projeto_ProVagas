using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class StatusInscricao
    {
        public StatusInscricao()
        {
            Inscricao = new HashSet<Inscricao>();
        }

        public int IdStatusInscricao { get; set; }
        public string NomeStatus { get; set; }

        public virtual ICollection<Inscricao> Inscricao { get; set; }
    }
}
