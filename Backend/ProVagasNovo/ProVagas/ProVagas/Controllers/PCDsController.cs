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
    public class PCDsController : ControllerBase
    {

        private IPcdRepository _pcd { get; set; }

        public PCDsController()
        {

            _pcd = new PcdRepository();
        }

        /// <summary>
        /// Listar as pcds 
        /// </summary>
        /// <returns>Retorna uma lista com as pcds</returns>
        [HttpGet]
        public IEnumerable<Pcd> Get()
        {
            return _pcd.GetAll();
        }

        /// <summary>
        /// Listar pcds por Id
        /// </summary>
        /// <param name="id">Id da pcd que será buscado</param>
        /// <returns>Retorna uma lista de pcds por Ids</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_pcd.GetById(id) != null)
            {
                return Ok(_pcd.GetById(id));
            }
            else
            {
                return BadRequest("Pcd não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar uma novo pcd
        /// </summary>
        /// <param name="pcd"></param>
        /// <returns>Retorna uma nova pcd cadastrada</returns>
        [HttpPost]
        public IActionResult Post(Pcd pcd)
        {
            try
            {
                _pcd.Add(pcd);

                return Ok("Pcd cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Pcd não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar uma pcd pelo id
        /// </summary>
        /// <param name="id">Id da pcd que será buscado</param>
        /// <param name="pcdatt"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pcd pcdatt)
        {

            try
            {
                Pcd UPDATE = new Pcd
                {
                    IdPcd = id,
                    NomeDeficiencia = pcdatt.NomeDeficiencia
                };

                _pcd.Update(UPDATE);

                return Ok("Pcd atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse pcd");
            }
        }

        /// <summary>
        /// Deletar uma pcd pelo id
        /// </summary>
        /// <param name="id">Id da pcd que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Pcd pcdBuscado = _pcd.GetById(id);
                _pcd.Delete(pcdBuscado);

                return Ok("Pcd deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse pcd");
            }

        }
    }
}