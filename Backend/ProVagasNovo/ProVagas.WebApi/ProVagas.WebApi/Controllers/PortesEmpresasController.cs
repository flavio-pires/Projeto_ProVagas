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
    public class PortesEmpresasController : ControllerBase
    {

        private IPorteEmpresaRepository _porteEmpresa { get; set; }

        public PortesEmpresasController()
        {

            _porteEmpresa = new PorteEmpresaRepository();
        }

      
        [HttpGet]
        public IEnumerable<PorteEmpresa> Get()
        {
            return _porteEmpresa.GetAll();
        }
       

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_porteEmpresa.GetById(id) != null)
            {
                return Ok(_porteEmpresa.GetById(id));
            }
            else
            {
                return BadRequest("Porte não encontrado.");
            }
        }

        
        [HttpPost]
        public IActionResult Post(PorteEmpresa porte)
        {
            try
            {
                _porteEmpresa.Add(porte);

                return Ok("Porte cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Porte não cadastrado");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PorteEmpresa porte)
        {

            try
            {
                PorteEmpresa UPDATE = new PorteEmpresa
                {
                    IdPorteEmpresa = id,
                    NomePorte = porte.NomePorte
                };

                _porteEmpresa.Update(UPDATE);

                return Ok("Porte atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse porte");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                PorteEmpresa generobuscado = _porteEmpresa.GetById(id);
                _porteEmpresa.Delete(generobuscado);

                return Ok("Porte deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse porte");
            }

        }
    }
}