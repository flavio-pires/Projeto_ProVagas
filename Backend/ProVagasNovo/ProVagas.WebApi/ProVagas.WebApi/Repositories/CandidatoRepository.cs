using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<matchviewmodel> match (int id)
        {
            var habilidade = ctx.HabilidadeXcandidato.Include(c => c.IdHabilidadeNavigation.NomeHabilidade)
                .Include(c => c.IdCandidatoNavigation.IdEnderecoNavigation.Cep)
                .Include(c => c.IdCandidatoNavigation.IdNivelEscolaridadeNavigation.Escolaridade)
                .FirstOrDefault(u => u.IdCandidato == id);

            List<Vaga> vagas = ctx.Vaga
                .Include(v => v.NomeVaga)
                .Include(v => v.IdTipoVagaNavigation.NomeTipoVaga)
                .Include(v => v.IdNivelVagaNavigation.NomeNivelVaga)
                .ToList();


            List<matchviewmodel> mat = new List<matchviewmodel>();
            var count = 0;

            foreach (var item in vagas)
            {
                if (habilidade.IdHabilidadeNavigation.NomeHabilidade.ToLower() == item.RequisitoXvaga. ToString());
                count++;

                if (habilidade.IdCandidatoNavigation.IdEnderecoNavigation.Cep.ToLower() == item.IdEmpresaNavigation.IdEnderecoNavigation.Cep.ToLower());
                count++;

            }
            return mat;
        }
    }
}
