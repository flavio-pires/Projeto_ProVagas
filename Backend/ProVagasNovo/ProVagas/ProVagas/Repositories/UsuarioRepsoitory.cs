using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class UsuarioRepsoitory : RepositoryBase<Usuario>, IUsuarioRepository
    {
        ProVagasContext ctx = new ProVagasContext();
        public Usuario BuscarSenhaEmail(string email, string senha)
        {
            return ctx.Usuario.FirstOrDefault(user => user.Email == email && user.Senha == senha);
        }

        public int CadastrarUsuario(Usuario usuario)
        {
            ctx.Usuario.Add(usuario);
            ctx.SaveChanges();

            return usuario.IdUsuario;
        }
    }
}
