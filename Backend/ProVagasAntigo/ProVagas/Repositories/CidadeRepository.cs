using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {

        ProVagasContext ctx = new ProVagasContext();

        public void Atualizar(int id, Cidade cidadeAtualizada)
        {
            Cidade cidadeBuscada = ctx.Cidade.Find(id);

            cidadeBuscada.NomeCidade = cidadeAtualizada.NomeCidade;
            cidadeBuscada.IdEstado = cidadeAtualizada.IdEstado;

            ctx.Cidade.Update(cidadeBuscada);

            ctx.SaveChanges();
        }

        public void Cadastrar(Cidade novacidade)
        {
            ctx.Cidade.Add(novacidade);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cidade cidadeBuscada = ctx.Cidade.Find(id);

            ctx.Cidade.Remove(cidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Cidade> Listar()
        {
            return ctx.Cidade.ToList();
        }
    }
}
