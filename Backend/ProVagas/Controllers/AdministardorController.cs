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
    [Route("api/[controller]")]
    [ApiController]
    public class AdministardorController : ControllerBase
    {
        private IAdministradorRepository _administradorRepository { get; set; }

        private IEmpresaRepository _empresaRepository { get; set; }

        public AdministardorController()
        {
            _administradorRepository = new AdministadorRepository();

            _empresaRepository = new EmpresaRepository();
        }

        [HttpGet]
        public IEnumerable<Administrador> Get()
        {
            return _administradorRepository.GetAll();
        }

        [HttpGet("Empresa")]
        public IActionResult GetEmpresa()
        {
            return Ok(_empresaRepository.Listar());
        }

        /*Listar os generos por id*/
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_administradorRepository.GetById(id) != null)
            {
                return Ok(_administradorRepository.GetById(id));
            }
            else
            {
                return BadRequest("Genero não encontrado.");
            }
        }

        /*Cadastrar um novo genero*/
        [HttpPost]
        public IActionResult Post(Administrador adm)
        {
            try
            {
                _administradorRepository.Add(adm);

                return Ok("Administrador cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Administrador não cadastrado");
            }

        }

        /*Atualizar os generos*/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Administrador administrador)
        {

            try
            {
                Administrador UPDATE = new Administrador
                {
                    IdAdministrador = id,
                    NomeCompletoAdmin = administrador.NomeCompletoAdmin,
                    Nif = administrador.Nif,
                    Departamento = administrador.Departamento,
                    UnidadeSenai = administrador.UnidadeSenai,
                    IdUsuario = administrador.IdUsuario
                };

                _administradorRepository.Update(UPDATE);

                return Ok("Administrador atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse administrador");
            }
        }

        /*Deletar generos*/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Administrador administradorBuscado = _administradorRepository.GetById(id);
                _administradorRepository.Delete(administradorBuscado);

                return Ok("Administrador deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse administrador");
            }

        }

    }
}
