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
    public class IdiomasController : ControllerBase
    {

        private IIdiomaRepository _idiomaRepository { get; set; }

        public IdiomasController()
        {

            _idiomaRepository = new IdiomaRepository();
        }

        /// <summary>
        /// Listar todos os idiomas
        /// </summary>
        /// <returns>Retorna uma lista de idiomas</returns>
        [HttpGet]
        public IEnumerable<Idioma> Get()
        {
            return _idiomaRepository.GetAll();
        }

        /// <summary>
        /// Listar idiomas por Id
        /// </summary>
        /// <param name="id">Id do idioma que será buscado</param>
        /// <returns>Retorna uma lista de idiomas por Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_idiomaRepository.GetById(id) != null)
            {
                return Ok(_idiomaRepository.GetById(id));
            }
            else
            {
                return BadRequest("Iidoma não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo idioma
        /// </summary>
        /// <param name="idioma"></param>
        /// <returns>Retorna o cadastro de um novo idioma</returns>
        [HttpPost]
        public IActionResult Post(Idioma idioma)
        {
            try
            {
                _idiomaRepository.Add(idioma);

                return Ok("Idioma cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Curso não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar um idioma pelo Id
        /// </summary>
        /// <param name="id">Id do idioma que será buscado</param>
        /// <param name="idiomaatt"></param>
        /// <returns>Retorna o idioma atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Idioma idiomaatt)
        {

            try
            {
                Idioma UPDATE = new Idioma
                {
                    IdIdioma = id,
                    NomeIdioma = idiomaatt.NomeIdioma,
                    IdNivelIdioma = idiomaatt.IdNivelIdioma,
                    IdCandidato = idiomaatt.IdCandidato,
                };

                _idiomaRepository.Update(UPDATE);

                return Ok("Idioma atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse idioma");
            }
        }

        /// <summary>
        /// Deletar um idioma pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Idioma idiomaBuscado = _idiomaRepository.GetById(id);
                _idiomaRepository.Delete(idiomaBuscado);

                return Ok("Idioma deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse idioma");
            }

        }
    }
}