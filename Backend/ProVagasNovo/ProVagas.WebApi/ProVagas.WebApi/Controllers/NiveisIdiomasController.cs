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
    public class    NiveisIdiomasController : ControllerBase
    {

        private INiveldiomaRepository _nivelIdioma { get; set; }

        public NiveisIdiomasController()
        {

            _nivelIdioma = new NivelIdiomaRepository();
        }

        /*Listar todos os generos*/
        [HttpGet]
        public IEnumerable<NivelIdioma> Get()
        {
            return _nivelIdioma.GetAll();
        }

        /*Listar os generos por id*/
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_nivelIdioma.GetById(id) != null)
            {
                return Ok(_nivelIdioma.GetById(id));
            }
            else
            {
                return BadRequest("Nivel de idioma não encontrado.");
            }
        }

        /*Cadastrar um novo genero*/
        [HttpPost]
        public IActionResult Post(NivelIdioma nivel)
        {
            try
            {
                _nivelIdioma.Add(nivel);

                return Ok("Nivel de idioma cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Nivel não cadastrado");
            }

        }

        /*Atualizar os generos*/
        [HttpPut("{id}")]
        public IActionResult Put(int id, NivelIdioma nivelcadastrado)
        {

            try
            {
                NivelIdioma UPDATE = new NivelIdioma
                {
                    IdNivelIdioma = id,
                    Idioma = nivelcadastrado.Idioma
                };

                _nivelIdioma.Update(UPDATE);

                return Ok("Nivel de idioma atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse nivel de idioma");
            }
        }

        /*Deletar generos*/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                NivelIdioma nivelbuscado = _nivelIdioma.GetById(id);
                _nivelIdioma.Delete(nivelbuscado);

                return Ok("Nivel de idioma deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse nivel de idioma");
            }

        }
    }
}