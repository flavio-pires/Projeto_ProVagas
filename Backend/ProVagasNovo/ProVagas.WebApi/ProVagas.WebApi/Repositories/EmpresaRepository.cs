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
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public Empresa Login (string email, string senha)
        {
            Empresa empresaBuscado = ctx.Empresa.Include (x => x.IdEnderecoNavigation.IdUsuarioNavigation).
              FirstOrDefault(x => x.IdEnderecoNavigation.IdUsuarioNavigation.Email == email && x.IdEnderecoNavigation.IdUsuarioNavigation.Senha == senha);

            if (empresaBuscado != null)
            {
                return empresaBuscado;
            }

            return null;
        }
    }
}
