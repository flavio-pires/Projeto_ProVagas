using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class StatusEstagio
    {
        public StatusEstagio()
        {
            Estagio = new HashSet<Estagio>();
        }

        public int IdStatusEstagio { get; set; }
        public string NomeStatus { get; set; }

        public virtual ICollection<Estagio> Estagio { get; set; }
    }
}
