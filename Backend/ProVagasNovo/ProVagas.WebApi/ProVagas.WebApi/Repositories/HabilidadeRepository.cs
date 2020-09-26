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
    public class HabilidadeRepository : IHabilidadeRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public void Atualizar(int id, Habilidade habilidadeAtualizada)
        {
            Habilidade habilidadeBuscada = ctx.Habilidade.Find(id);

            if(habilidadeBuscada != null)
            {
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;
            }

            ctx.Habilidade.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            Habilidade habilidadeBuscada = ctx.Habilidade
                .Include(h => h.NomeHabilidade)
                .Include(h => h.HabilidadeXcandidato)
                .FirstOrDefault(h => h.IdHabilidade == id);

            if(habilidadeBuscada != null)
            {
                return habilidadeBuscada;
            }

            return null;
        }

        public void Cadastrar(Habilidade novaHabilidade)
        {
            ctx.Habilidade.Add(novaHabilidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Habilidade.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidade.ToList();
        }
    }
}
