using Microsoft.EntityFrameworkCore;
using ProVagas.WebApi.Contexts;
using ProVagas.WebApi.Domains;
using ProVagas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Repositories
{
    public class AdministradorRepository : RepositoryBase<Administrador>, IAdministradorRepository
    {
        ProVagasContext ctx = new ProVagasContext();
        public void Cadastrar(Administrador novoAdmin)
        {

            ctx.Administrador.Add(novoAdmin);

            ctx.SaveChanges();

        }


        public Administrador Login(string email, string senha)
        {
            Administrador administradorBuscado = ctx.Administrador.Include(x => x.IdUsuarioNavigation).
              FirstOrDefault(x => x.IdUsuarioNavigation.Email == email && x.IdUsuarioNavigation.Senha == senha);

            if (administradorBuscado != null)
            {
                return administradorBuscado;
            }

            return null;
        }
    }
}
