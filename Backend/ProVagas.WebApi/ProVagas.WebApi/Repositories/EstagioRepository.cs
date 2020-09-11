using Microsoft.EntityFrameworkCore;
using ProVagas.Interfaces;
using ProVagas.WebApi.Contexts;
using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class EstagioRepository : IEstagioRepository
    {
        ProVagasBDContext ctx = new ProVagasBDContext();
        public void Atualizar(int id, Estagio estagioAtualizado)
        {
            Estagio estagioBuscado = ctx.Estagio.Find(id);

            estagioBuscado.DataInicio = estagioAtualizado.DataInicio;
            estagioBuscado.DataFinal = estagioAtualizado.DataFinal;

            ctx.Estagio.Update(estagioBuscado);

            ctx.SaveChanges();
        }

        public Estagio BuscarPorId(int id)
        {
            return ctx.Estagio.FirstOrDefault(i => i.IdEstagio == id);
        }

        public void Cadastrar(Estagio novoBeneficio)
        {
            ctx.Estagio.Add(novoBeneficio);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Estagio.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Estagio> Listar()
        {
            return ctx.Estagio.ToList();
        }
    }
}
