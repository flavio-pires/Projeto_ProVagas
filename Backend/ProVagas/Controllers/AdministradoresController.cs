using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProVagas.Domains;
using ProVagas.Interfaces;
using ProVagas.Repositories;

namespace ProVagas.Controllers
{
    [Produces("aplication/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private IAdministradorRepository _administradorRepository { get; set; }

        public AdministradoresController()
        {
            _administradorRepository = new AdministadorRepository();
        }

        //Listar todos os usuarios
        [HttpGet]
        public IEnumerable<Administrador> Get()
        {
            return _administradorRepository.GetAll();
        }

        // Listar os usuarios por id na URL 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if(_administradorRepository.GetById(id) != null)
            {
                return Ok(_administradorRepository.GetById(id));
            }
            else
            {
                return BadRequest("Usuario não encontrado");
            }
        }

        // PUT: api/Administradores/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
