using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class StatusEstagioRepository : IStatusEstagioRepository
    {

        ProVagasContext ctx = new ProVagasContext();

        public void Atualizar(int id, StatusEstagio statusEstagioAtualizado)
        {
            StatusEstagio statusEstagioBuscado = ctx.StatusEstagio.Find(id);

            statusEstagioBuscado.NomeStatus = statusEstagioAtualizado.NomeStatus;
            statusEstagioBuscado.Estagio = statusEstagioAtualizado.Estagio;

            ctx.StatusEstagio.Update(statusEstagioBuscado);

            ctx.SaveChanges();
            
        }

        public void Cadastrar(Domains.StatusEstagio novostatusEstagio)
        {
            ctx.StatusEstagio.Add(novostatusEstagio);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            StatusEstagio statusEstagioBuscado = ctx.StatusEstagio.Find(id);

            ctx.StatusEstagio.Remove(statusEstagioBuscado);

            ctx.SaveChanges();
        }

        public List<StatusEstagio> Listar()
        {
            return ctx.StatusEstagio.ToList();
        }

     
    }
}
