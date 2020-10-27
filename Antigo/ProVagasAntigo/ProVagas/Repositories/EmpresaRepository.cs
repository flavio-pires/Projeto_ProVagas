using Microsoft.EntityFrameworkCore;
using ProVagas.Interfaces;
using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProVagas.Contexts;

namespace ProVagas.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        ProVagasContext ctx = new ProVagasContext();
        public void Atualizar(int id, Empresa empresaAtualizada)
        {
            Empresa empresaBuscada = ctx.Empresa.Find(id);

            empresaBuscada.RazaoSocial = empresaAtualizada.RazaoSocial;
            empresaBuscada.NomeFantasia = empresaAtualizada.NomeFantasia;
            empresaBuscada.PorteEmpresa = empresaAtualizada.PorteEmpresa;
            empresaBuscada.NomeParaContato = empresaAtualizada.NomeParaContato;
            empresaBuscada.Linkedin = empresaAtualizada.Linkedin;
            empresaBuscada.Website = empresaAtualizada.Website;
            empresaBuscada.Cnpj = empresaAtualizada.Cnpj;
            empresaBuscada.Cnae = empresaAtualizada.Cnae;

            ctx.Empresa.Update(empresaBuscada);

            ctx.SaveChanges();
        }

        public Empresa BuscarPorId(int id)
        {
            return ctx.Empresa.FirstOrDefault(e => e.IdEmpresa == id);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            ctx.Empresa.Add(novaEmpresa);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Empresa.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Empresa> Listar()
        {
            return ctx.Empresa.Include(e => e.IdUsuarioNavigation).ToList(); 
        }
    }
}
