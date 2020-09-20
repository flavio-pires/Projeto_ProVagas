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
    public class CursosSenaiController : ControllerBase
    {

        private ICursoSenaiRepository _cursoSenai{ get; set; }

        public CursosSenaiController()
        {

            _cursoSenai = new CursoSenaiRepository();
        }

        [HttpGet]
        public IEnumerable<CursoSenai> Get()
        {
            return _cursoSenai.GetAll();
        }

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