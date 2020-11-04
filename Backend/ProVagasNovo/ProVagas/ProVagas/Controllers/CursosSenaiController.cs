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
    public class CursosSenaiController : ControllerBase
    {

        private ICursoSenaiRepository _cursoSenai{ get; set; }

        public CursosSenaiController()
        {

            _cursoSenai = new CursoSenaiRepository();
        }

        /// <summary>
        /// Listar todos os cursos do SENAI
        /// </summary>
        /// <returns>Retorna uma lista com todos os cursos do SENAI</returns>
        [HttpGet]
        public IEnumerable<CursoSenai> Get()
        {
            return _cursoSenai.GetAll();
        }

        /// <summary>
        /// Listar os cursos do SENAI pelo Id
        /// </summary>
        /// <param name="id">Id do curso do SENAI que será buscado</param>
        /// <returns>Retorna uma lista dos cursos do SENAI pelo Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_cursoSenai.GetById(id) != null)
            {
                return Ok(_cursoSenai.GetById(id));
            }
            else
            {
                return BadRequest("Curso do SENAI não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo curso do SENAI
        /// </summary>
        /// <param name="curso"></param>
        /// <returns>Retorna um cadastro de um novo curso do SENAI</returns>
        [HttpPost]
        public IActionResult Post(CursoSenai curso)
        {
            try
            {
                _cursoSenai.Add(curso);

                return Ok("Curso cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Curso não cadastrado");
            }

        }

        /// <summary>
        /// Alterar um curso do SENAI pelo Id
        /// </summary>
        /// <param name="id">Id do curso do SENAI que será buscado</param>
        /// <param name="cursoadd"></param>
        /// <returns>Retorna um curso do SENAI atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, CursoSenai cursoadd)
        {

            try
            {
                CursoSenai UPDATE = new CursoSenai
                {
                    IdCursoSenai = id,
                    CursandoSenai = cursoadd.CursandoSenai,
                    Curso = cursoadd.Curso,
                    IdCandidato = cursoadd.IdCandidato,
                };

                _cursoSenai.Update(UPDATE);

                return Ok("Curso atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse curso");
            }
        }

        /// <summary>
        /// Deletar um curso do SENAI pelo Id
        /// </summary>
        /// <param name="id">Id do curso do SENAI que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CursoSenai cursoBuscado = _cursoSenai.GetById(id);
                _cursoSenai.Delete(cursoBuscado);

                return Ok("Curso deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse curso");
            }

        }
    }
}