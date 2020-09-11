using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Administrador = new HashSet<Administrador>();
            Candidato = new HashSet<Candidato>();
            Empresa = new HashSet<Empresa>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdEndereco { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Administrador> Administrador { get; set; }
        public virtual ICollection<Candidato> Candidato { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
