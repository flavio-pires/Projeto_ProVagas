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
    public class PcsdsXCandidatosController : ControllerBase
    {

        private IPcdXcandidatoRepository _PcdRepository { get; set; }

        public PcsdsXCandidatosController()
        {

            _PcdRepository = new PcdXcandidatoRepository();
        }

        /// <summary>
        /// Listar todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista com todos os gêneros</returns>
        [HttpGet]
        public IEnumerable<PcdXcandidato> Get()
        {
            return _PcdRepository.GetAll();
        }
        
        /// <summary>
        /// Retorna uma lista de gêneros por Id
        /// </summary>
        /// <param name="id">Id do gênero que será buscado</param>
        /// <returns>Retorna uma lista de gêneros por Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_PcdRepository.GetById(id) != null)
            {
                return Ok(_PcdRepository.GetById(id));
            }
            else
            {
                return BadRequest("PcdXCandidato não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="pcdXcand"></param>
        /// <returns>Retorna o cadastro finalizado de um novo gênero</returns>
        [HttpPost]
        public IActionResult Post(PcdXcandidato pcdXcand)
        {
            try
            {
                _PcdRepository.Add(pcdXcand);

                return Ok("PcdXacandidato cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("PcdXcandidato não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar um gênero por id
        /// </summary>
        /// <param name="id">Id do gênero que será buscado</param>
        /// <param name="pcd"></param>
        /// <returns>Retorna um gênero atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, PcdXcandidato pcd)
        {

            try
            {
                PcdXcandidato UPDATE = new PcdXcandidato
                {
                    IdPcdCandidato = id,
                    IdCandidato = pcd.IdCandidato,
                    IdPcd = pcd.IdPcd
                };

                _PcdRepository.Update(UPDATE);

                return Ok("Pcd atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse pcd");
            }
        }

        /// <summary>
        /// Deletar um gênero pelo id
        /// </summary>
        /// <param name="id">Id do gênero que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                PcdXcandidato pcdBuscado = _PcdRepository.GetById(id);
                _PcdRepository.Delete(pcdBuscado);

                return Ok("Pcd deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse pcd");
            }

        }
    }
}