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

        public bool CadastrarAdm(CadastrarAdmViewModels novoAdmin)
        {
            Console.WriteLine(novoAdmin);
            try
            {
                Usuario usuario = new Usuario()
                {
                    Email = novoAdmin.Email,
                    Senha = novoAdmin.Senha,
                    Telefone = novoAdmin.Telefone,
                    IdTipoUsuario = 3
                };

                Administrador administrador = new Administrador()
                {
                    IdUsuarioNavigation = usuario,
                    NomeCompletoAdmin = novoAdmin.NomeCompleto,
                    Departamento = novoAdmin.Departamento,
                    UnidadeSenai = novoAdmin.UnidadeSenai,
                    Nif = novoAdmin.NIF,
                };
                ctx.Add(administrador);
                ctx.SaveChanges();
                return true;
            }
            
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
