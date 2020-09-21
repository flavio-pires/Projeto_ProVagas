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

        /// <summary>
        /// Listar todos os niveis de idioma
        /// </summary>
        /// <returns>Retorna uma lista com todos os niveis de idioma</returns>
        [HttpGet]
        public IEnumerable<NivelIdioma> Get()
        {
            return _nivelIdioma.GetAll();
        }

        /// <summary>
        /// Listar todos os niveis de idioma por Id
        /// </summary>
        /// <param name="id">Id do nivel de idioma que será buscado</param>
        /// <returns>Retorna uma lista dos niveis de idioma por Id</returns>
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

        /// <summary>
        /// Cadastrar um novo nivel de idioma
        /// </summary>
        /// <param name="nivel"></param>
        /// <returns>Retorna o cadastro de um novo nivel de idioma</returns>
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

        /// <summary>
        /// Atualizar um nivel de idioma pelo Id
        /// </summary>
        /// <param name="id">Id do nivel de idioma que será buscado</param>
        /// <param name="nivelcadastrado"></param>
        /// <returns>Retorna um nivel de idioma atualizado</returns>
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

        /// <summary>
        /// Deletar um nivel de idioma pelo Id
        /// </summary>
        /// <param name="id">Id do nivel de idioma que será buscado</param>
        /// <returns>Retorna vazio</returns>
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