using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using ProVagas.ViewsModels;
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

        public bool CadastrarAdm(CadastrarAdmViewModels NovoAdm)
        {
            try
            {
                Usuario user = new Usuario()
                {
                    Email = NovoAdm.Email,
                    Senha = NovoAdm.Senha,
                    Telefone = NovoAdm.Telefone,
                    IdTipoUsuario = 3
                };

                Administrador administrador = new Administrador()
                {
                    IdUsuarioNavigation = user,
                    NomeCompletoAdmin = NovoAdm.NomeCompleto,
                    Departamento = NovoAdm.Departamento,
                    UnidadeSenai = NovoAdm.UnidadeSenai,
                    Nif = NovoAdm.NIF,
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
