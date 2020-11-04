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
    public class AdministradorRepository : RepositoryBase<Administrador>, IAdministradorRepository
    {
        ProVagasContext ctx = new ProVagasContext();

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
