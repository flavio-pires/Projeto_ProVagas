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
    public class GenerosController : ControllerBase
    {

        private IGenerorepository _generorepository { get; set; }

        public GenerosController ()
        {

            _generorepository = new GeneroRepository();
        }

        /*Listar todos os generos*/
        [HttpGet]
        public IEnumerable<Genero> Get()
        {
            return _generorepository.GetAll();
        }
        /*Listar os generos por id*/
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

        /*Cadastrar um novo genero*/
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

        /*Atualizar os generos*/
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

       /*Deletar generos*/
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
