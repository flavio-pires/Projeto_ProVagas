using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Administrador = new HashSet<Administrador>();
            Candidato = new HashSet<Candidato>();
            Empresa = new HashSet<Empresa>();
        }

        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Num { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public int? IdCidade { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Cidade IdCidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Administrador> Administrador { get; set; }
        public virtual ICollection<Candidato> Candidato { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
