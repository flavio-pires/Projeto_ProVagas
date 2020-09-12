using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo StatusInscricaoRespository
    /// </summary>
    interface IStatusInscricaoRepository
    {
        /// <summary>
        /// Lista todos os status de inscrição
        /// </summary>
        /// <returns>Uma lista de status de inscrição</returns>
        List<StatusInscricao> Listar();

        /// <summary>
        /// Cadastra um novo Status de inscrição
        /// </summary>
        /// <param name="novoStatusInscricao">Objeto contendo as informações do novo status de inscrição</param>
        void Cadastrar(StatusInscricao novoStatusInscricao);

        /// <summary>
        /// Deleta um status de inscrição existente
        /// </summary>
        /// <param name="id">Id do status de inscrição que será deletado</param>
        void Deletar(int id);
    }
}
