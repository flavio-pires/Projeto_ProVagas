using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class Cidade
    {
        public Cidade()
        {
            Endereco = new HashSet<Endereco>();
        }

        public int IdCidade { get; set; }
        public string NomeCidade { get; set; }
        public int? IdEstado { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
