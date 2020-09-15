using Microsoft.EntityFrameworkCore;
using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    /// <summary>
    /// Repositório responsável pelas inscrições
    /// </summary>
    public class InscricaoRepository : IInscricaoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        ProVagasContext ctx = new ProVagasContext();

        /// <summary>
        /// Atualiza uma inscrição existente
        /// </summary>
        /// <param name="id">Id da inscrição que será atualizada</param>
        /// <param name="inscricaoAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, Inscricao inscricaoAtualizada)
        {
            Inscricao inscricaoBuscada = ctx.Inscricao.Find(id);

            if (inscricaoBuscada != null)
            {
                if (inscricaoAtualizada.DataInscricao != null)
                {
                    inscricaoBuscada.DataInscricao = inscricaoAtualizada.DataInscricao;
                }

                if (inscricaoAtualizada.IdVaga > 0)
                {
                    inscricaoBuscada.IdVaga = inscricaoAtualizada.IdVaga;
                }

                if (inscricaoAtualizada.IdStatusInscricao > 0)
                {
                    inscricaoBuscada.IdStatusInscricao = inscricaoAtualizada.IdStatusInscricao;
                }

                if (inscricaoAtualizada.IdCandidato > 0)
                {
                    inscricaoBuscada.IdCandidato = inscricaoAtualizada.IdCandidato;
                }
            }

            ctx.Inscricao.Update(inscricaoBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma inscrição através do Id
        /// </summary>
        /// <param name="id">Id da inscrição que será buscada</param>
        /// <returns>A inscrição buscada</returns>
        public Inscricao BuscarPorId(int id)
        {
            Inscricao inscricaoBuscada = ctx.Inscricao
                .Include(i => i.IdCandidatoNavigation)
                .Include(i => i.IdStatusInscricaoNavigation)
                .Include(i => i.IdVagaNavigation)
                .FirstOrDefault(i => i.IdInscricao == id);

            if (inscricaoBuscada != null)
            {
                return inscricaoBuscada;
            }

            return null;
        }

        /// <summary>
        /// Cadastra uma nova inscrição
        /// </summary>
        /// <param name="novaInscricao">Objeto contendo as informações da nova inscrição</param>
        public void Cadastrar(Inscricao novaInscricao)
        {
            ctx.Inscricao.Add(novaInscricao);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma inscrição existente
        /// </summary>
        /// <param name="id">Id da inscrição que será deletada</param>
        public void Deletar(int id)
        {
            ctx.Inscricao.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as inscrições
        /// </summary>
        /// <returns>Uma lista de inscrições</returns>
        public List<Inscricao> Listar()
        {
            return ctx.Inscricao
                .Include(i => i.IdCandidatoNavigation)
                .Include(i => i.IdStatusInscricaoNavigation)
                .Include(i => i.IdVagaNavigation)

                .ToList();
        }
    }
}
