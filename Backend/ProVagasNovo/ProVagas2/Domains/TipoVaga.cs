using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class TipoVaga
    {
        public TipoVaga()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int IdTipoVaga { get; set; }
        public string NomeTipoVaga { get; set; }

        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
