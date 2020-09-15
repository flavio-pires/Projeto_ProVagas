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
    /// Repositório dos candidatos
    /// </summary>
    public class CandidatoRepository : ICandidatoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        ProVagasContext ctx = new ProVagasContext();

        /// <summary>
        /// Atualiza um candidato existente
        /// </summary>
        /// <param name="id">ID do candidato que será atualizado</param>
        /// <param name="candidatoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Candidato candidatoAtualizado)
        {
            Candidato candidatoBuscado = ctx.Candidato.Find(id);

            if (candidatoBuscado != null)
            {

                if (candidatoAtualizado.NomeCompletoCandidato != null)
                {
                    candidatoBuscado.NomeCompletoCandidato = candidatoAtualizado.NomeCompletoCandidato;
                }

                if (candidatoAtualizado.Cpf != null)
                {
                    candidatoBuscado.Cpf = candidatoAtualizado.Cpf;
                }

                if (candidatoAtualizado.DataNascimento != null)
                {
                    candidatoBuscado.DataNascimento = candidatoAtualizado.DataNascimento;
                }

                if (candidatoAtualizado.Linkedin != null)
                {
                    candidatoBuscado.Linkedin = candidatoAtualizado.Linkedin;
                }

                if (candidatoAtualizado.FotoPerfil != null)
                {
                    candidatoBuscado.FotoPerfil = candidatoAtualizado.FotoPerfil;
                }

                if (candidatoAtualizado.PossuiDeficiencia != false)
                {
                    candidatoBuscado.PossuiDeficiencia = candidatoAtualizado.PossuiDeficiencia;
                }

                if (candidatoAtualizado.Deficiencia != null)
                {
                    candidatoBuscado.Deficiencia = candidatoAtualizado.Deficiencia;
                }

                if (candidatoAtualizado.CursandoSenai != false)
                {
                    candidatoBuscado.CursandoSenai = candidatoAtualizado.CursandoSenai;
                }

                if (candidatoAtualizado.Curso != null)
                {
                    candidatoBuscado.Curso = candidatoAtualizado.Curso;
                }

                if (candidatoAtualizado.NomeEmpresaExperienciaProfissional != null)
                {
                    candidatoBuscado.NomeEmpresaExperienciaProfissional = candidatoAtualizado.NomeEmpresaExperienciaProfissional;
                }

                if (candidatoAtualizado.Cargo != null)
                {
                    candidatoBuscado.Cargo = candidatoAtualizado.Cargo;
                }

                if (candidatoAtualizado.DataInicio != null)
                {
                    candidatoBuscado.DataInicio = candidatoAtualizado.DataInicio;
                }

                if (candidatoAtualizado.DataFim != null)
                {
                    candidatoBuscado.DataFim = candidatoAtualizado.DataFim;
                }

                if (candidatoAtualizado.EmpregoAtual != null)
                {
                    candidatoBuscado.EmpregoAtual = candidatoAtualizado.EmpregoAtual;
                }

                if (candidatoAtualizado.DescriçãoAtividades != null)
                {
                    candidatoBuscado.DescriçãoAtividades = candidatoAtualizado.DescriçãoAtividades;
                }

                if (candidatoAtualizado.IdGenero > 0)
                {
                    candidatoBuscado.IdGenero = candidatoAtualizado.IdGenero;
                }

                if (candidatoAtualizado.IdNivelIngles > 0)
                {
                    candidatoBuscado.IdNivelIngles = candidatoAtualizado.IdNivelIngles;
                }

                if (candidatoAtualizado.IdNivelEscolaridade > 0)
                {
                    candidatoBuscado.IdNivelEscolaridade = candidatoAtualizado.IdNivelEscolaridade;
                }
            }

            ctx.Candidato.Update(candidatoBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um candidato através do Id
        /// </summary>
        /// <param name="id">Id do candidato que será buscado</param>
        /// <returns>O candidato buscado</returns>
        public Candidato BuscarPorId(int id)
        {
            Candidato candidatoBuscado = ctx.Candidato
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdGeneroNavigation)
                .Include(c => c.IdNivelEscolaridadeNavigation)
                .Include(c => c.IdNivelInglesNavigation)
                .FirstOrDefault(c => c.IdCandidato == id);

            if (candidatoBuscado != null)
            {
                return candidatoBuscado;
            }

            return null;
        }

        /// <summary>
        /// Cadastra um novo candidato
        /// </summary>
        /// <param name="novoCandidato">Objeto contendo as informações do novo candidato</param>
        public void Cadastrar(Candidato novoCandidato)
        {
            ctx.Candidato.Add(novoCandidato);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um candidato existente
        /// </summary>
        /// <param name="id">Id do candidato que será deletado</param>
        public void Deletar(int id)
        {
            ctx.Candidato.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os candidatos
        /// </summary>
        /// <returns>Uma lista de candidatos</returns>
        public List<Candidato> Listar()
        {
            return ctx.Candidato
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdGeneroNavigation)
                .Include(c => c.IdNivelEscolaridadeNavigation)
                .Include(c => c.IdNivelInglesNavigation)

                .ToList();
        }
    }
}
