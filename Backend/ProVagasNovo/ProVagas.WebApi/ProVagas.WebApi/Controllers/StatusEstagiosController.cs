using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProVagas.WebApi.Domains;
using ProVagas.WebApi.Interfaces;
using ProVagas.WebApi.Repositories;

namespace ProVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusEstagiosController : ControllerBase
    {

        private IStatusEstagioRepository _statusEstagioRepository { get; set; }

        public StatusEstagiosController()
        {
            _statusEstagioRepository = new StatusEstagioRepository();
        }

        /// <summary>
        /// Listar todos os status de estagio
        /// </summary>
        /// <returns>Retorna uma lista com os status de estagio</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_statusEstagioRepository.Listar());
        }


        /// <summary>
        /// Cadastrar um novo status de estagio 
        /// </summary>
        /// <param name="novostatusEstagios"></param>
        /// <returns>Retorna o cadastro de um novo status de estagio</returns>
        [HttpPost]
        public IActionResult Post(StatusEstagio novostatusEstagios)
        {
            _statusEstagioRepository.Cadastrar(novostatusEstagios);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar um status de estagio pelo Id
        /// </summary>
        /// <param name="id">Id do status de estágio que será buscado</param>
        /// <param name="statusEstagioAtualizado"></param>
        /// <returns>Retorna o status de estagio atualizado pelo Id</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, StatusEstagio statusEstagioAtualizado)
        {
            _statusEstagioRepository.Atualizar(id, statusEstagioAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar o status de estágio pelo Id
        /// </summary>
        /// <param name="id">Id do status do estágio que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _statusEstagioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
