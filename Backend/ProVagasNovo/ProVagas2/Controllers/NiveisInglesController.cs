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

    public class NiveisInglesController : ControllerBase
    {
        private INivelInglesRepository _nivelInglesRepository { get; set; }

        public NiveisInglesController()
        {

            _nivelInglesRepository = new NivelInglesRepository();
        }

        /*Listar todos os Níveis de inglês*/

        /// <summary>
        /// Listar níveis de inglês
        /// </summary>
        /// <returns>Lista com todos os níveis de inglês</returns>
        [HttpGet]
        public IEnumerable<NivelIngles> Get()
        {
            return _nivelInglesRepository.GetAll();
        }


        /*Listar os níveis de inglês por id*/
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_nivelInglesRepository.GetById(id) != null)
            {
                return Ok(_nivelInglesRepository.GetById(id));
            }
            else
            {
                return BadRequest("Genero não encontrado.");
            }
        }

        /*Cadastrar um novo nível de inglês*/
        [HttpPost]
        public IActionResult Post(NivelIngles nivelIngles)
        {
            try
            {
                _nivelInglesRepository.Add(nivelIngles);

                return Ok("Nível cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Nível não cadastrado");
            }

        }

        /*Atualizar os níveis de inglês*/
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, NivelIngles novoNivel)
        {

            try
            {
                NivelIngles UPDATE = new NivelIngles
                {
                    IdNivelIngles = id,
                    Ingles = novoNivel.Ingles
                };

                _nivelInglesRepository.Update(UPDATE);

                return Ok("Nível atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse nível");
            }
        }

        /*Deletar nível*/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                NivelIngles nivelBuscado = _nivelInglesRepository.GetById(id);
                _nivelInglesRepository.Delete(nivelBuscado);

                return Ok("Nível deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse nível");
            }

        }
    
}
}
