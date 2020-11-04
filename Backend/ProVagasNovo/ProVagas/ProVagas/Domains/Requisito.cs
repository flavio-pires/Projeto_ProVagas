using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Requisito
    {
        public Requisito()
        {
            RequisitoXvaga = new HashSet<RequisitoXvaga>();
        }

        public int IdRequisito { get; set; }
        public string NomeRequisito { get; set; }

        public virtual ICollection<RequisitoXvaga> RequisitoXvaga { get; set; }
    }
}
