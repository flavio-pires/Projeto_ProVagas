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

        // Listar Estados
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estadoRepository.Listar());
        }

 

        // Cadastrar novo estado
        [HttpPost]
        public IActionResult Post(Estado novoestado)
        {
            _estadoRepository.Cadastrar(novoestado);

            return StatusCode(201);
        }

        // Atualizar Estado
        [HttpPut("{id}")]
        public IActionResult Put(int id, Estado estadoAtualizado)
        {
            _estadoRepository.Atualizar(id, estadoAtualizado);

            return StatusCode(204);
        }

        //Deletar Estados
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estadoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
