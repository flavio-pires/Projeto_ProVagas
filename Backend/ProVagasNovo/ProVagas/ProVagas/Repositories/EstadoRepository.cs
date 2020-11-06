using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class EstadoRepository : RepositoryBase<Estado>, IEstadoRepository
    {
        ProVagasContext ctx = new ProVagasContext();

        public void Atualizar(int id, Estado estadoAtualizado)
        {
            Estado estadoBuscado = ctx.Estado.Find(id);

            estadoBuscado.NomeEstado = estadoAtualizado.NomeEstado;
            estadoBuscado.Cidade = estadoAtualizado.Cidade;

            ctx.Estado.Update(estadoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Estado novoEstado)
        {
            ctx.Estado.Add(novoEstado);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estado estadoBuscado = ctx.Estado.Find(id);

            ctx.Estado.Remove(estadoBuscado);

            ctx.SaveChanges();
        }

        public List<Estado> Listar()
        {
            return ctx.Estado.ToList();
        }
    }
}
