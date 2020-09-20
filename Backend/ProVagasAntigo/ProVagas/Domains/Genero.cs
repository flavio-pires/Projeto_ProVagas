using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Genero
    {
        public Genero()
        {
            Candidato = new HashSet<Candidato>();
        }

        public int IdGenero { get; set; }
        public string NomeGenero { get; set; }

        public virtual ICollection<Candidato> Candidato { get; set; }
    }
}
