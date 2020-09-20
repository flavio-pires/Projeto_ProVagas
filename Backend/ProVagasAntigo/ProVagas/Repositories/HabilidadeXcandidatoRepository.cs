using Microsoft.EntityFrameworkCore;
using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class HabilidadeXcandidatoRepository : IHabilidadeXcandidatoRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public void Atualizar(int id, HabilidadeXCandidato habilidadeXCandidatoAtualizada)
        {
            HabilidadeXCandidato habilidadeXCandidatoBuscado = ctx.HabilidadeXcandidato.Find(id);

            if(habilidadeXCandidatoBuscado != null)
            {
                habilidadeXCandidatoBuscado.IdHabilidade = habilidadeXCandidatoAtualizada.IdHabilidade;
            }

            if(habilidadeXCandidatoBuscado != null)
            {
                habilidadeXCandidatoBuscado.IdCandidato = habilidadeXCandidatoAtualizada.IdCandidato;
            }

            ctx.HabilidadeXcandidato.Update(habilidadeXCandidatoBuscado);

            ctx.SaveChanges();
        }

        public HabilidadeXCandidato BuscarPorId(int id)
        {
            HabilidadeXCandidato habilidadeXCandidatoBuscado = ctx.HabilidadeXcandidato
                .Include(x => x.IdHabilidadeNavigation)
                .Include(x => x.IdCandidatoNavigation)
                .FirstOrDefault(x => x.IdHabilidadeCandidato == id);

            if(habilidadeXCandidatoBuscado != null)
            {
                return habilidadeXCandidatoBuscado;
            }

            return null;
        }

        public void Cadastrar(HabilidadeXCandidato novaHabilidadeXCandidato)
        {
            ctx.HabilidadeXcandidato.Add(novaHabilidadeXCandidato);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.HabilidadeXcandidato.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<HabilidadeXCandidato> Listar()
        {
            return ctx.HabilidadeXcandidato
                .Include(x => x.IdHabilidadeNavigation)
                .Include(x => x.IdCandidatoNavigation)
                .ToList();
        }
    }
}
