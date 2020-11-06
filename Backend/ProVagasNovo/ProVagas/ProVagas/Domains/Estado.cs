using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            Cidade = new HashSet<Cidade>();
        }

        public int IdEstado { get; set; }
        public string NomeEstado { get; set; }

        public virtual ICollection<Cidade> Cidade { get; set; }
    }
}
