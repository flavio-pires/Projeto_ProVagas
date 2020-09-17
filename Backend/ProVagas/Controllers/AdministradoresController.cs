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
        //Listar todos os candidatos
        [HttpGet("Candidato")]
        public IActionResult GetCandidato()
        {
            return Ok(_administradorRepository.ListarCandidato());
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

        // Atualizar administrador
        [HttpPut("{id}")]
        public IActionResult Put(int id, Administrador administradorAtualizado)
        {

            try
            {
                Administrador UPDATE = new Administrador
                {
                    IdAdministrador = id,
                    NomeCompletoAdmin = administradorAtualizado.NomeCompletoAdmin,
                    Nif = administradorAtualizado.Nif,
                    UnidadeSenai = administradorAtualizado.UnidadeSenai,
                    Departamento = administradorAtualizado.Departamento,
                    IdUsuario = 1
                };

                _administradorRepository.Update(UPDATE);
                return Ok("Dados atualizados com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível atualizar os dados");
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Administrador usuariobuscado = _administradorRepository.GetById(id);
                _administradorRepository.Delete(usuariobuscado);

                return Ok("Usuario deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse usuário");
            }
        }
    }
}
