using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class Administrador
    {
        public int IdAdministrador { get; set; }
        public string NomeCompletoAdmin { get; set; }
        public string Nif { get; set; }
        public string UnidadeSenai { get; set; }
        public string Departamento { get; set; }
        public int? IdEndereco { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
    }
}
