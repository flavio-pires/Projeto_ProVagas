using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdEndereco { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Num { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int IdCidade { get; set; }

        public virtual Cidade IdCidadeNavigation { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
