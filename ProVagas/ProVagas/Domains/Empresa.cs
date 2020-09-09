using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Estagio = new HashSet<Estagio>();
            Vaga = new HashSet<Vaga>();
        }

        public int IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string PorteEmpresa { get; set; }
        public string NomeParaContato { get; set; }
        public string Linkedin { get; set; }
        public string Website { get; set; }
        public string Porte { get; set; }
        public string Cnpj { get; set; }
        public string Cnae { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Estagio> Estagio { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
