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
    public class GenerosController : ControllerBase
    {

        private IGenerorepository _generorepository { get; set; }

        public GenerosController ()
        {

            _generorepository = new GeneroRepository();
        }

        /// <summary>
        /// Listar todos os generos
        /// </summary>
        /// <returns>Retorna uma lista com os generos</returns>
        [HttpGet]
        public IEnumerable<Genero> Get()
        {
            return _generorepository.GetAll();
        }
        
        /// <summary>
        /// Retorna uma lista de generos por Id
        /// </summary>
        /// <param name="id">Id do genero que será buscado</param>
        /// <returns>Retorna uma lista de generos por Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(_generorepository.GetById(id) != null)
            {
                return Ok(_generorepository.GetById(id));
            }
            else
            {
                return BadRequest("Genero não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="genero"></param>
        /// <returns>Retorna o cadastro de um novo genero</returns>
        [HttpPost]
        public IActionResult Post(Genero genero)
        {
            try
            {
                _generorepository.Add(genero);

                return Ok("Genero cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Genero não cadastrado");
            }
        
        }

        /// <summary>
        /// Atualizar um genero pelo Id
        /// </summary>
        /// <param name="id">Id do genero que será buscado</param>
        /// <param name="generocadastrado"></param>
        /// <returns>Retorna o genero atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Genero generocadastrado)
        {

            try
            {
                Genero UPDATE = new Genero
                {
                    IdGenero = id,
                    NomeGenero = generocadastrado.NomeGenero
                };

                _generorepository.Update(UPDATE);

                return Ok("Genero atualizado com sucesso");
            
            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse genero");
            }
        }

        /// <summary>
        /// Deletar um genero pelo Id
        /// </summary>
        /// <param name="id">Id do genero que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Genero generobuscado = _generorepository.GetById(id);
                _generorepository.Delete(generobuscado);

                return Ok("Genero deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse genero");
            }

        }
    }
}
