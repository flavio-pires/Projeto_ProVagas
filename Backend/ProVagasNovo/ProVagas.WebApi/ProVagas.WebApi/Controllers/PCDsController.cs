    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProVagas.WebApi.Domains;
using ProVagas.WebApi.Interfaces;
using ProVagas.WebApi.Repositories;

namespace ProVagas.WebApi.Controllers
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

        /*Listar todos os generos*/
        [HttpGet]
        public IEnumerable<Pcd> Get()
        {
            return _pcd.GetAll();
        }
        /*Listar os generos por id*/
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

        /*Cadastrar um novo genero*/
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

        /*Atualizar os generos*/
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

        /*Deletar generos*/
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