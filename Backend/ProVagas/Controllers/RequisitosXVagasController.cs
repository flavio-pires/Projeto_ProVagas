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
    public class RequisitosXVagasController : ControllerBase
    {
        private IRequisitoXVagarepository _requisitosxvagarepository { get; set; }

        public RequisitosXVagasController()
        {

            _requisitosxvagarepository = new RequisitoXVagaRepository();
        }


        /*Listar todos os RequisitoXVagaBuscado junto com a vaga*/
        [HttpGet]
        public IEnumerable<RequisitoXVaga> Get()
        {
            return _requisitosxvagarepository.GetAll();
        }

        /*Listar os RequisitoXVagaBuscado por id  através da url*/
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_requisitosxvagarepository.GetById(id) != null)
            {
                return Ok(_requisitosxvagarepository.GetById(id));
            }
            else
            {
                return BadRequest("RequisitoXvaga não encontrado.");
            }
        }

        /*Cadastrar um novo RequisitoXVagaBuscado*/
        [HttpPost]
        public IActionResult Post(RequisitoXVaga requisitoxvaga)
        {
            try
            {
                _requisitosxvagarepository.Add(requisitoxvaga);

                return Ok("Um novo requisitoXVaga foi cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("requisitoXVaga não cadastrado");
            }

        }

        /*Atualizar os RequisitoXVagaBuscado*/
        [HttpPut("{id}")]
        public IActionResult Put(int id, RequisitoXVaga requisitoxvagaCadastrado)
        {

            try
            {
                RequisitoXVaga UPDATE = new RequisitoXVaga
                {
                    IdRequisitoVaga = id,
                    IdRequisitoNavigation = requisitoxvagaCadastrado.IdRequisitoNavigation,
                    IdVagaNavigation = requisitoxvagaCadastrado.IdVagaNavigation
                };

                _requisitosxvagarepository.Update(UPDATE);

                return Ok("RequisitoXVaga foi atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse RequisitoXVaga");
            }
        }

        /*Deletar RequisitoXVagaBuscado*/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                RequisitoXVaga RequisitoXVagaBuscado = _requisitosxvagarepository.GetById(id);
                _requisitosxvagarepository.Delete(RequisitoXVagaBuscado);

                return Ok("requisitoXVaga deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse requisitoXVaga");
            }
        }
    }
}
