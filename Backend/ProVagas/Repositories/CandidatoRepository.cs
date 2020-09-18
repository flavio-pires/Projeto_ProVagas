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
                    candidatoBuscado.NomeCompletoCandidato = candidatoAtualizado.NomeCompletoCandidato;  
                    candidatoBuscado.Cpf = candidatoAtualizado.Cpf;
                    candidatoBuscado.DataNascimento = candidatoAtualizado.DataNascimento;
               

               
                    candidatoBuscado.Linkedin = candidatoAtualizado.Linkedin;
                

                
                    candidatoBuscado.FotoPerfil = candidatoAtualizado.FotoPerfil;
                

               
                    candidatoBuscado.PossuiDeficiencia = candidatoAtualizado.PossuiDeficiencia;
                

              
                    candidatoBuscado.Deficiencia = candidatoAtualizado.Deficiencia;
                

               
                   candidatoBuscado.CursandoSenai = candidatoAtualizado.CursandoSenai;
                

                
                    candidatoBuscado.Curso = candidatoAtualizado.Curso;
                

               
                    candidatoBuscado.NomeEmpresaExperienciaProfissional = candidatoAtualizado.NomeEmpresaExperienciaProfissional;
                

                
                    candidatoBuscado.Cargo = candidatoAtualizado.Cargo;
                

               
                    candidatoBuscado.DataInicio = candidatoAtualizado.DataInicio;
                

              
                    candidatoBuscado.DataFim = candidatoAtualizado.DataFim;
                

               
                    candidatoBuscado.EmpregoAtual = candidatoAtualizado.EmpregoAtual;
                

               
                    candidatoBuscado.DescriçãoAtividades = candidatoAtualizado.DescriçãoAtividades;
                

              
                    candidatoBuscado.IdGenero = candidatoAtualizado.IdGenero;

                candidatoBuscado.IdUsuario = candidatoAtualizado.IdUsuario;
              
                    candidatoBuscado.IdNivelIngles = candidatoAtualizado.IdNivelIngles;
               
               
               
                    candidatoBuscado.IdNivelEscolaridade = candidatoAtualizado.IdNivelEscolaridade;
                
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
