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
    public class ExperienciasProfissionaisController : ControllerBase
    {

        private IExperienciaProfissional _experienciaProfissional { get; set; }

        public ExperienciasProfissionaisController()
        {

            _experienciaProfissional = new ExperienciaProfissionalRepository();
        }

        [HttpGet]
        public IEnumerable<ExperienciaProfissional> Get()
        {
            return _experienciaProfissional.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_experienciaProfissional.GetById(id) != null)
            {
                return Ok(_experienciaProfissional.GetById(id));
            }
            else
            {
                return BadRequest("Experiencia profissional não encontrada.");
            }
        }

        [HttpPost]
        public IActionResult Post(ExperienciaProfissional exp)
        {
            try
            {
                _experienciaProfissional.Add(exp);

                return Ok("Experiencia cadastrada com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Experiencia não cadastrada");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ExperienciaProfissional experiAtt)
        {

            try
            {
                ExperienciaProfissional UPDATE = new ExperienciaProfissional
                {
                    IdExperienciaProfissional = id,
                    NomeExperiencia = experiAtt.NomeExperiencia,
                    NomeEmpresa = experiAtt.NomeEmpresa,
                    Cargo = experiAtt.Cargo,
                    DataInicio = experiAtt.DataInicio,
                    DataFim = experiAtt.DataFim,
                    EmpregoAtual = experiAtt.EmpregoAtual,
                    DescriçãoAtividade = experiAtt.DescriçãoAtividade,
                    IdCandidato = experiAtt.IdCandidato
                };

                _experienciaProfissional.Update(UPDATE);

                return Ok("Experiencia atualizada com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar essa experiencia");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ExperienciaProfissional experienciaBuscado = _experienciaProfissional.GetById(id);
                _experienciaProfissional.Delete(experienciaBuscado);

                return Ok("Experiencia deletada com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar essa experiencia");
            }

        }
    }
}