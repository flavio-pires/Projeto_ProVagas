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

        [HttpGet]
        public IEnumerable<CursoExtraCurricular> Get()
        {
            return _cursoextra.GetAll();
        }

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