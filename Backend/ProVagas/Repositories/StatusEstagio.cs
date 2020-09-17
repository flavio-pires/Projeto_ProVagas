using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class StatusEstagio : IStatusEstagioRepository
    {

        ProVagasContext ctx = new ProVagasContext();

        public void Atualizar(int id, Domains.StatusEstagio statusEstagioAtualizado)
        {
            StatusEstagio statusEstagioBuscado = ctx.StatusEstagio.Find(id);

            statusEstagioBuscado. = cidadeAtualizada.NomeCidade;
            cidadeBuscada.IdEstado = cidadeAtualizada.IdEstado;

            ctx.Cidade.Update(cidadeBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Domains.StatusEstagio novostatusEstagio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<StatusEstagio> Listar()
        {
            return ctx.StatusEstadio.ToList();
        }

    }
}
