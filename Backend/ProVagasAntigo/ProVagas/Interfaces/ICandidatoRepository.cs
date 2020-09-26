using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    /// <summary>
    /// Interface responsável pelo CandidatoRepository
    /// </summary>
    interface ICandidatoRepository
    {
        /// <summary>
        /// Lista todos os candidatos
        /// </summary>
        /// <returns>Retorna uma lista de candidatos</returns>
        List<Candidato> Listar();

        /// <summary>
        /// Busca um candidato através do ID
        /// </summary>
        /// <param name="id">ID do candidato que será buscado</param>
        /// <returns>Retorna o candidato buscado</returns>
        Candidato BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo candidato
        /// </summary>
        /// <param name="novoCandidato">Objeto contendo as informações do novo candidato</param>
        void Cadastrar(Candidato novoCandidato);

        /// <summary>
        /// Atualiza um candidato existente
        /// </summary>
        /// <param name="id">ID do candidato que será atualizado</param>
        /// <param name="candidatoAtualizado">Objeto com as informações atualizadas</param>
        void Atualizar(int id, Candidato candidatoAtualizado);

        /// <summary>
        /// Deleta um candidato existente
        /// </summary>
        /// <param name="id">ID do candidato que será deletado</param>
        void Deletar(int id);
    }
}
