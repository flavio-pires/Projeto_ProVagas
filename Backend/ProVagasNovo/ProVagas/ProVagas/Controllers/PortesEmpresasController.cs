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

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PortesEmpresasController : ControllerBase
    {

        private IPorteEmpresaRepository _porteEmpresa { get; set; }

        public PortesEmpresasController()
        {

            _porteEmpresa = new PorteEmpresaRepository();
        }

        /// <summary>
        /// Listar todos os portes das empresas
        /// </summary>
        /// <returns>Retorna uma lista dos portes das empresas</returns>
        [HttpGet]
        public IEnumerable<PorteEmpresa> Get()
        {
            return _porteEmpresa.GetAll();
        }
       
        /// <summary>
        /// Listar os portes das empresas por Id
        /// </summary>
        /// <param name="id">Id do porte que será buscado</param>
        /// <returns>Retorna os portes das empresas por Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_porteEmpresa.GetById(id) != null)
            {
                return Ok(_porteEmpresa.GetById(id));
            }
            else
            {
                return BadRequest("Porte não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo porte
        /// </summary>
        /// <param name="porte"></param>
        /// <returns>Retorna o cadastro finalizado de um novo porte</returns>
        [HttpPost]
        public IActionResult Post(PorteEmpresa porte)
        {
            try
            {
                _porteEmpresa.Add(porte);

                return Ok("Porte cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Porte não cadastrado");
            }

        }

        /// <summary>
        /// Alterar um porte
        /// </summary>
        /// <param name="id">Id do porte que será buscado</param>
        /// <param name="porte"></param>
        /// <returns>Retorna o porte atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, PorteEmpresa porte)
        {

            try
            {
                PorteEmpresa UPDATE = new PorteEmpresa
                {
                    IdPorteEmpresa = id,
                    NomePorte = porte.NomePorte
                };

                _porteEmpresa.Update(UPDATE);

                return Ok("Porte atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse porte");
            }
        }

        /// <summary>
        /// Deletar um porte
        /// </summary>
        /// <param name="id">Id do porte que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                PorteEmpresa generobuscado = _porteEmpresa.GetById(id);
                _porteEmpresa.Delete(generobuscado);

                return Ok("Porte deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse porte");
            }

        }
    }
}