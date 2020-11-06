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
    public class StatusEstagiosController : ControllerBase
    {

        private IStatusEstagioRepository _statusEstagioRepository { get; set; }

        public StatusEstagiosController()
        {
            _statusEstagioRepository = new StatusEstagioRepository();
        }

        // GET: api/<StatusEstagiosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_statusEstagioRepository.Listar());
        }


        // POST api/<StatusEstagiosController>
        [HttpPost]
        public IActionResult Post(StatusEstagio novostatusEstagios)
        {
            _statusEstagioRepository.Cadastrar(novostatusEstagios);

            return StatusCode(201);
        }

        // PUT api/<StatusEstagiosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, StatusEstagio statusEstagioAtualizado)
        {
            _statusEstagioRepository.Atualizar(id, statusEstagioAtualizado);

            return StatusCode(204);
        }

        // DELETE api/<StatusEstagiosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _statusEstagioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
