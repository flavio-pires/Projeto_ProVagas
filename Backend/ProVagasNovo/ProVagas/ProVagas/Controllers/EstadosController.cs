using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProVagas.Domains;
using ProVagas.Interfaces;
using ProVagas.Repositories;

namespace ProVagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {

        private IEstadoRepository _estadoRepository { get; set; }

        public EstadosController()
        {
            _estadoRepository = new EstadoRepository();
        }

        /// <summary>
        /// Listar todos os estados
        /// </summary>
        /// <returns>Retorna uma lista com os estados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estadoRepository.Listar());
        }

        /// <summary>
        /// Cadastrar um novo estado
        /// </summary>
        /// <param name="novoestado"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Estado novoestado)
        {
            _estadoRepository.Cadastrar(novoestado);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar um estado pelo Id
        /// </summary>
        /// <param name="id">Id do estado que será buscado</param>
        /// <param name="estadoAtualizado"></param>
        /// <returns>Retorna o estado atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Estado estadoAtualizado)
        {
            _estadoRepository.Atualizar(id, estadoAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar um estado pelo Id
        /// </summary>
        /// <param name="id">Id do estado que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estadoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
