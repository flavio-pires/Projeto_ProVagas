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
    public class NiveisEscolaridadesController : ControllerBase
    {

        private INivelEscolaridadeRepository _nivelescolaridaderepository { get; set; }

        public NiveisEscolaridadesController()
        {

            _nivelescolaridaderepository = new NivelEscolaridadeRepository();
        }

        /*Listar todos os generos*/
        [HttpGet]
        public IEnumerable<NivelEscolaridade> Get()
        {
            return _nivelescolaridaderepository.GetAll();
        }

        /*Listar os generos por id*/
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_nivelescolaridaderepository.GetById(id) != null)
            {
                return Ok(_nivelescolaridaderepository.GetById(id));
            }
            else
            {
                return BadRequest("Nivel de escolaridade não encontrado.");
            }
        }

        /*Cadastrar um novo genero*/
        [HttpPost]
        public IActionResult Post(NivelEscolaridade nivel)
        {
            try
            {
                _nivelescolaridaderepository.Add(nivel);

                return Ok("Nivel de escolaridade cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Nivel não cadastrado");
            }

        }

        /*Atualizar os generos*/
        [HttpPut("{id}")]
        public IActionResult Put(int id, NivelEscolaridade nivelcadastrado)
        {

            try
            {
                NivelEscolaridade UPDATE = new NivelEscolaridade
                {
                    IdNivelEscolaridade = id,
                    Escolaridade = nivelcadastrado.Escolaridade
                };

                _nivelescolaridaderepository.Update(UPDATE);

                return Ok("Nivel de escolaridade atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse nivel de escolaridade");
            }
        }

        /*Deletar generos*/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                NivelEscolaridade nivelbuscado = _nivelescolaridaderepository.GetById(id);
                _nivelescolaridaderepository.Delete(nivelbuscado);

                return Ok("Nivel de escolaridade deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse nivel de escolaridade");
            }

        }
    }
}
