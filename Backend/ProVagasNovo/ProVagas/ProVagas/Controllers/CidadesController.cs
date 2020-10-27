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


        /// <summary>
        /// Listar todas as cidades
        /// </summary>
        /// <returns>Retorna uma lista de cidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cidadeRepository.Listar());
        }


        /// <summary>
        /// Cadastrar uma nova cidade
        /// </summary>
        /// <param name="novacidade"></param>
        /// <returns>Retorna o cadastro de uma nova cidade</returns>
        [HttpPost]
        public IActionResult Post(Cidade novacidade)
        {
            _cidadeRepository.Cadastrar(novacidade);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar uma cidade pelo Id
        /// </summary>
        /// <param name="id">Id da cidade que será buscado</param>
        /// <param name="cidadeAtualizada"></param>
        /// <returns>Retorna uma cidade atualizada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Cidade cidadeAtualizada)
        {
            _cidadeRepository.Atualizar(id, cidadeAtualizada);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar uma cidade pelo Id
        /// </summary>
        /// <param name="id">Id da cidade que será buscado</param>
        /// <returns>Retorna vazio</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cidadeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
