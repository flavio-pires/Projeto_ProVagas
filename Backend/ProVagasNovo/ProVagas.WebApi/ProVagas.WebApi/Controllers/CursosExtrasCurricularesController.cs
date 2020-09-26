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
    public class CursosExtrasCurriculares : ControllerBase
    {

        private ICursoExtraCurricularRepository _cursoextra { get; set; }

        public CursosExtrasCurriculares()
        {

            _cursoextra = new CursoExtraCurricularRepository();
        }

        /// <summary>
        /// Listar todos os cursos extracurriculares
        /// </summary>
        /// <returns>Retorna uma lista dos cursos extracurriculares</returns>
        [HttpGet]
        public IEnumerable<CursoExtraCurricular> Get()
        {
            return _cursoextra.GetAll();
        }

        /// <summary>
        /// Listar os cursos extracurriculares pelo Id
        /// </summary>
        /// <param name="id">Id do curso extracurricular que será buscado</param>
        /// <returns>Retorna um curso extracurricular pelo Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_cursoextra.GetById(id) != null)
            {
                return Ok(_cursoextra.GetById(id));
            }
            else
            {
                return BadRequest("Curso extra curricular não encontrado.");
            }
        }

        /// <summary>
        /// Cadastrar um novo curso extracurricular
        /// </summary>
        /// <param name="curso"></param>
        /// <returns>Retorna um cadastro de um novo curso extracurricular</returns>
        [HttpPost]
        public IActionResult Post(CursoExtraCurricular curso)
        {
            try
            {
                _cursoextra.Add(curso);

                return Ok("Curso cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Curso não cadastrado");
            }

        }

        /// <summary>
        /// Alterar um curso extracurricular pelo Id
        /// </summary>
        /// <param name="id">Id do curso extracurricular que será buscado</param>
        /// <param name="cursoadd"></param>
        /// <returns>Retorna um curso extracurricular atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, CursoExtraCurricular cursoadd)
        {

            try
            {
                CursoExtraCurricular UPDATE = new CursoExtraCurricular
                {
                    IdCursoExtraCurricular = id,
                    NomeCurso = cursoadd.NomeCurso,
                    Instituicao = cursoadd.Instituicao,
                    DataInicio = cursoadd.DataInicio,
                    DataFim = cursoadd.DataFim,
                    IdCandidato = cursoadd.IdCandidato

                };

                _cursoextra.Update(UPDATE);

                return Ok("Curso atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse curso");
            }
        }

        /// <summary>
        /// Deletar um curso extracurricular pelo Id
        /// </summary>
        /// <param name="id">Id do curso extracurricular que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CursoExtraCurricular cursoBuscado = _cursoextra.GetById(id);
                _cursoextra.Delete(cursoBuscado);

                return Ok("Curso deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse curso");
            }

        }
    }
}