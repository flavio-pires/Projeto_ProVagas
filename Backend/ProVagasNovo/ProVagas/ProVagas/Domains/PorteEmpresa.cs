using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class PorteEmpresa
    {
        public PorteEmpresa()
        {
            Empresa = new HashSet<Empresa>();
        }

        public int IdPorteEmpresa { get; set; }
        public string NomePorte { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
