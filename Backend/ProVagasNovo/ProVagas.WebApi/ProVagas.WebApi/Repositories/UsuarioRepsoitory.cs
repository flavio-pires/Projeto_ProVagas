using ProVagas.WebApi.Contexts;
using ProVagas.WebApi.Domains;
using ProVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Repositories
{
    public class UsuarioRepsoitory : RepositoryBase<Usuario>, IUsuarioRepository
    {
        ProVagasContext ctx = new ProVagasContext();
        public Usuario BuscarSenhaEmail(string email, string senha)
        {
            return ctx.Usuario.FirstOrDefault(user => user.Email == email && user.Senha == senha);
        }
    }
}
