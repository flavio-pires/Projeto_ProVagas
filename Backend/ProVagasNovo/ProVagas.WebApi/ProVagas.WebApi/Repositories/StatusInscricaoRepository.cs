﻿using ProVagas.WebApi.Contexts;
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
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        ProVagasContext ctx = new ProVagasContext();

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

        /// <summary>
        /// Busca um status de inscrição através do ID
        /// </summary>
        /// <param name="id">ID do status de inscrição quer será buscada</param>
        /// <returns>O status de inscrição buscado</returns>
        public StatusInscricao BuscarPorId(int id)
        {
            StatusInscricao statusInscricaoBuscada = ctx.StatusInscricao.FirstOrDefault(s => s.IdStatusInscricao == id);

            if (statusInscricaoBuscada != null)
            {
                return statusInscricaoBuscada;
            }

            return null;
        }
    }
}