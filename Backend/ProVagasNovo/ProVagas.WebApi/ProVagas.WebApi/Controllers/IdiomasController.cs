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
    public class IdiomasController : ControllerBase
    {

        private IIdiomaRepository _idiomaRepository { get; set; }

        public IdiomasController()
        {

            _idiomaRepository = new IdiomaRepository();
        }

        [HttpGet]
        public IEnumerable<Idioma> Get()
        {
            return _idiomaRepository.GetAll();
        }

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