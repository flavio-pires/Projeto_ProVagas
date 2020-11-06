using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Administrador = new HashSet<Administrador>();
            Endereco = new HashSet<Endereco>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Administrador> Administrador { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
