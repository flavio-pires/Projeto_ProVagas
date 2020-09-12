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
    /// <summary>
    /// Repositório responsável pelo StatusInscricaoRepository
    /// </summary>
    public class StatusInscricaoRepository : IStatusInscricaoRepository
    {
        ProVagasBDContext ctx = new ProVagasBDContext();

        /// <summary>
        /// Cadastra um novo status de inscrição
        /// </summary>
        /// <param name="novoStatusInscricao">Objeto contendo as informações do novo status de inscrição</param>
        public void Cadastrar(StatusInscricao novoStatusInscricao)
        {
            ctx.StatusInscricao.Add(novoStatusInscricao);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um status de inscrição existente
        /// </summary>
        /// <param name="id">Id do status de inscrição que será deletado</param>
        public void Deletar(int id)
        {
            StatusInscricao statusInscricaoBuscado = ctx.StatusInscricao.Find(id);

            ctx.StatusInscricao.Remove(statusInscricaoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os status de inscrição
        /// </summary>
        /// <returns>Uma lista com os status de inscrição</returns>
        public List<StatusInscricao> Listar()
        {
            return ctx.StatusInscricao.ToList();
        }
    }
}
