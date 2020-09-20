using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string NomeParaContato { get; set; }
        public string Linkedin { get; set; }
        public string Website { get; set; }
        public string Cnpj { get; set; }
        public string Cnae { get; set; }
        public int? IdPorte { get; set; }
        public int? IdEndereco { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual PorteEmpresa IdPorteNavigation { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
