using Microsoft.EntityFrameworkCore;
using ProVagas.WebApi.Interfaces;
using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProVagas.WebApi.Contexts;

namespace ProVagas.WebApi.Repositories
{
    public class BeneficioRepository : IBeneficioRepository
    {
        ProVagasContext ctx = new ProVagasContext();
        public void Atualizar(int id, Beneficio beneficioAtualizado)
        {
            Beneficio beneficioBuscado = ctx.Beneficio.Find(id);

            beneficioBuscado.NomeBeneficio = beneficioAtualizado.NomeBeneficio;

            ctx.Beneficio.Update(beneficioBuscado);

            ctx.SaveChanges();
        }

        public Beneficio BuscarPorId(int id)
        {
            return ctx.Beneficio.FirstOrDefault(b => b.IdBeneficio == id);
        }

        public void Cadastrar(Beneficio novoBeneficio)
        {
            ctx.Beneficio.Add(novoBeneficio);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Beneficio.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Beneficio> Listar()
        {
            return ctx.Beneficio.ToList();
        }
    }
}
