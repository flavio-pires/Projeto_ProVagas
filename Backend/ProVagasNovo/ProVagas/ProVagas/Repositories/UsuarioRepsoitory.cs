using Microsoft.EntityFrameworkCore;
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
   

        public Usuario Login(string email, string senha)
        {
            // Busca o primeiro usuário encontrado para o e-mail e a senha informados e armazena no objeto usuarioBuscado
            Usuario usuarioBuscado = ctx.Usuario
                // Busca as informações referentes ao tipo de usuário
                .Include(u => u.IdTipoUsuarioNavigation)
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        public int CadastrarUsuario(Usuario usuario)
        {
            ctx.Usuario.Add(usuario);
            ctx.SaveChanges();

            return usuario.IdUsuario;
        }
    }
}
