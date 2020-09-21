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
        private ICandidatoRepository _candidatoRepository { get; set; }

        public CandidatosController()
        {

            _candidatoRepository = new CandidatoRepository();
        }

        /// <summary>
        /// Listar os candidatos
        /// </summary>
        /// <returns>Lista com todos os candidatos</returns>
        [HttpGet]
        public IEnumerable<Candidato> Get()
        {
            return _candidatoRepository.GetAll();
        }

        /// <summary>
        /// Buscar candidatos por id
        /// </summary>
        /// <param name="id">Id do benefício a ser buscado</param>
        /// <returns>Candidato buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_candidatoRepository.GetById(id) != null)
            {
                return Ok(_candidatoRepository.GetById(id));
            }
            else
            {
                return BadRequest("Candidato não encontrados.");
            }
        }

        /// <summary>
        /// Cadastrar um novo candidato
        /// </summary>
        /// <param name="candidato"></param>
        /// <returns>Retorna o cadastro de um novo candidato</returns>
        [HttpPost]
        public IActionResult Post(Candidato candidato)
        {
            try
            {
                _candidatoRepository.Add(candidato);

                return Ok("Candidato cadastrados com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível cadastrar o Candidato!");
            }

        }

        /// <summary>
        /// Atualizar um candidato pelo Id
        /// </summary>
        /// <param name="id">Id do candidato que será buscado</param>
        /// <param name="Candidatoatt"></param>
        /// <returns>Retorna o candidato atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Candidato Candidatoatt)
        {

            try
            {
                Candidato UPDATE = new Candidato
                {
                    IdCandidato = id,
                    NomeCompletoCandidato = Candidatoatt.NomeCompletoCandidato,
                    Cpf = Candidatoatt.Cpf,
                    DataNascimento = Candidatoatt.DataNascimento,
                    Linkedin = Candidatoatt.Linkedin

                };

                _candidatoRepository.Update(UPDATE);

                return Ok("Candidato atualizados com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar o candidato");
            }
        }

        /// <summary>
        /// Deletar um candidato pelo Id
        /// </summary>
        /// <param name="id">Id do candidato que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Candidato candidatoBuscado = _candidatoRepository.GetById(id);
                _candidatoRepository.Delete(candidatoBuscado);

                return Ok("Candidato deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar o Candidatp");
            }

        }
    }
}