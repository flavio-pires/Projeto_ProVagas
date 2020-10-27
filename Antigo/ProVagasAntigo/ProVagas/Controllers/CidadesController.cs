using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProVagas.Domains;
using ProVagas.Interfaces;
using ProVagas.Repositories;


namespace ProVagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private ICidadeRepository _cidadeRepository { get; set; }

        public CidadesController()
        {
            _cidadeRepository = new CidadeRepository();
        }


        // Listar Cidades
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cidadeRepository.Listar());
        }


        // Cadastrar Nova Cidade
        [HttpPost]
        public IActionResult Post(Cidade novacidade)
        {
            _cidadeRepository.Cadastrar(novacidade);

            return StatusCode(201);
        }

        // Atualizar Cidade
        [HttpPut("{id}")]
        public IActionResult Put(int id, Cidade cidadeAtualizada)
        {
            _cidadeRepository.Atualizar(id, cidadeAtualizada);

            return StatusCode(204);
        }

        // Deletar Cidades
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cidadeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
