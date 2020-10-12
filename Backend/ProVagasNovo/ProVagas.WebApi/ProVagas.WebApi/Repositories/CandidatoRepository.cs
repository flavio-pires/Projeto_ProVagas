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
    public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public Candidato Login (string email, string senha)
        {
            Candidato candidatoBuscado = ctx.Candidato.Include(x => x.IdEnderecoNavigation.IdUsuarioNavigation).
                FirstOrDefault(x => x.IdEnderecoNavigation.IdUsuarioNavigation.Email == email && x.IdEnderecoNavigation.IdUsuarioNavigation.Senha == senha);

            if (candidatoBuscado != null)
            {
                return candidatoBuscado;
            }

            return null;
        }
    }
}
