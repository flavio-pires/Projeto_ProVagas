using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class NivelVaga
    {
        public NivelVaga()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int IdNivelVaga { get; set; }
        public string NomeNivelVaga { get; set; }

        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
