using Microsoft.EntityFrameworkCore;
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
    public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public Candidato Login(string email, string senha)
        {
            Candidato candidatoBuscado = ctx.Candidato.Include(x => x.IdEnderecoNavigation.IdUsuarioNavigation).
                FirstOrDefault(x => x.IdEnderecoNavigation.IdUsuarioNavigation.Email == email && x.IdEnderecoNavigation.IdUsuarioNavigation.Senha == senha);

            if (candidatoBuscado != null)
            {
                return candidatoBuscado;
            }

            return null;
        }

        public IEnumerable<match> match(int id)
        {
            var habilidade = ctx.HabilidadeXcandidato.Include(c => c.IdHabilidadeNavigation.NomeHabilidade)
                .Include(c => c.IdCandidatoNavigation.IdEnderecoNavigation.Cep)
                .Include(c => c.IdCandidatoNavigation.IdNivelEscolaridadeNavigation.Escolaridade)
                .FirstOrDefault(u => u.IdCandidato == id);

            List<Vaga> vagas = ctx.Vaga
                .Include(v => v.NomeVaga)
                .Include(v => v.IdTipoVagaNavigation.NomeTipoVaga)
                .Include(v => v.IdNivelVagaNavigation.NomeNivelVaga)
                .Include(v => v.Localização)
                .Include(v => v.Salario)
                .ToList();

            List<RequisitoXvaga> req = ctx.RequisitoXvaga
                .Include(v => v.IdRequisitoNavigation.NomeRequisito).ToList();

            List<match> mat = new List<match>();
            var count = 0;

            foreach (var item in vagas)
            {

                if (habilidade.IdCandidatoNavigation.IdEnderecoNavigation.Cep.ToLower() == item.Localização.ToLower()) 
                count++;

                foreach (var a in req)
                {
                    if (habilidade.IdHabilidadeNavigation.NomeHabilidade.ToLower() == a.IdRequisitoNavigation.NomeRequisito.ToLower()) 
                    count++;
                }

            }
            return mat;
        }
    }
}
