using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProVagas.WebApi.Domains;
using ProVagas.WebApi.Interfaces;
using ProVagas.WebApi.Repositories;

namespace ProVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController : ControllerBase
    {
        private ICandidatoRepository _candidatoRepository;

        public CandidatosController()
        {
            _candidatoRepository = new CandidatoRepository();
        }

        /// <summary>
        /// Lista todos os candidatos
        /// </summary>
        /// <returns>Uma lista de candidatos e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_candidatoRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um candidato através do Id
        /// </summary>
        /// <param name="id">Id do candidato que será buscado</param>
        /// <returns>O candidato buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Candidato candidatoBuscado = _candidatoRepository.BuscarPorId(id);

                if (candidatoBuscado != null)
                {
                    return Ok(candidatoBuscado);
                }

                return NotFound("Nenhum candidato encontrado para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo candidato
        /// </summary>
        /// <param name="novoCandidato">Objeto contendo as informações do novo candidato</param>
        /// <returns>Um status code Ok e uma mensagem personalizada</returns>
        [HttpPost]
        public IActionResult Post(Candidato novoCandidato)
        {
            try
            {
                _candidatoRepository.Cadastrar(novoCandidato);

                return Ok("Cadastro realizado com sucesso!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Atualiza as informações de um candidato existente 
        /// </summary>
        /// <param name="id">Id do candidato que será atualizado</param>
        /// <param name="candidatoAtualizado">Objeto contendo as novas informações do candidato</param>
        /// <returns>Um status code Ok e uma mensagem personalizada</returns>
        [HttpPatch("{id}")]
        public IActionResult Put(int id, Candidato candidatoAtualizado)
        {
            try
            {
                Candidato candidatoBuscado = _candidatoRepository.BuscarPorId(id);

                if (candidatoBuscado != null)
                {
                    _candidatoRepository.Atualizar(id, candidatoAtualizado);

                    return Ok("Informações atualizadas!");
                }

                return NotFound("Nenhum candidato encontrado para o ID informado!");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Deleta um candidato existente
        /// </summary>
        /// <param name="id">Id do candidato que será deletado</param>
        /// <returns>Um status code 202 - Accepted</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Candidato candidatoBuscado = _candidatoRepository.BuscarPorId(id);

                if(candidatoBuscado != null)
                {
                    _candidatoRepository.Deletar(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum candidato encontrado para o ID informado!");
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

    }
}
