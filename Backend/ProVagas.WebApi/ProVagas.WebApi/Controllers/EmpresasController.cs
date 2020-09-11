using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProVagas.Domains;
using ProVagas.Interfaces;
using ProVagas.Repositories;


namespace ProVagas.Controllers
{
    // Resposta em Json da requisição
    [Produces("application/json")]
    // Definindo meu endpoint
    [Route("api/[controller]")]
    // Indicando que meu tipo da requisição vai ser em HTTP API
    [ApiController]

    public class EventosController : Controller
    {
        // Crio uma variável para minha interface
        private IEmpresaRepository _empresaRepository { get; set; }

        public EventosController()
        {
            // Instancio meu repositório na minha variável
            _empresaRepository = new EmpresaRepository();
        }

        /// <summary>
        /// Listar as empresas
        /// </summary>
        /// <returns>Retorna uma lista e um status code 200</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_empresaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Buscar um evento pelo ID
        /// </summary>
        /// <param name="id">Id da empresa que será buscado</param>
        /// <returns>Retorna uma empresa específica pelo Id</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_empresaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastrar uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto novaEmpresa que será cadastrado</param>
        /// <returns>Retorna um status code 201</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Empresa novaEmpresa)
        {
            try
            {
                _empresaRepository.Cadastrar(novaEmpresa);

                // Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Atualiza uma empresa
        /// </summary>
        /// <param name="id">Id da empresa que será buscado</param>
        /// <param name="empresaAtualizada">Objeto empresaAtualizada que será alterado</param>
        /// <returns>Retorna um status code 204</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Empresa empresaAtualizada)
        {
            try
            {
                _empresaRepository.Atualizar(id, empresaAtualizada);
                // Aceito
                return StatusCode(202);
            }
            catch (Exception erro)
            {
                // Má requisição
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deletar uma empresa
        /// </summary>
        /// <param name="id">Id da empresa que será buscado</param>
        /// <returns>Retorna um status code 204</returns>
        //[Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _empresaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}