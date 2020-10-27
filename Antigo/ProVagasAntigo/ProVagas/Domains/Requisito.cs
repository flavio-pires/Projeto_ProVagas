using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Requisito
    {
        public Requisito()
        {
            RequisitoXVaga = new HashSet<RequisitoXVaga>();
        }

        public int IdRequisito { get; set; }
        public string NomeRequisito { get; set; }

        public virtual ICollection<RequisitoXVaga> RequisitoXVaga { get; set; }
    }
}
