using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string NomeTipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
