using ProVagas.WebApi.Contexts;
using ProVagas.WebApi.Domains;
using ProVagas.WebApi.Interfaces;
using ProVagas.WebApi.ViewsModels;
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

        public bool CadastrarAdm(CadastrarAdmViewModels novoAdm)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Email = novoAdm.Email,
                    Senha = novoAdm.Senha,
                    Telefone = novoAdm.Telefone,
                    IdTipoUsuario = 3
                };

                Administrador administrador = new Administrador()
                {
                    IdUsuarioNavigation = usuario,
                    NomeCompletoAdmin = novoAdm.NomeCompleto,
                    Departamento = novoAdm.Departamento,
                    UnidadeSenai = novoAdm.Departamento,
                    Nif = novoAdm.NIF,

                };
                ctx.Add(administrador);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
