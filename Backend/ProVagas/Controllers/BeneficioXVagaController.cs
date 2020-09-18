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
    public class BeneficioXVagaController : ControllerBase
    {
        private IBeneficioXVagaRepository _beneficioXVagaRepository { get; set; }

        public BeneficioXVagaController()
        {

            _beneficioXVagaRepository = new BeneficioXVagaRepository();
        }

        /*Listar todos os benefício de uma vaga*/

        /// <summary>
        /// Listar os benefícios de uma vaga
        /// </summary>
        /// <returns>Lista com todos os benefícios da vaga</returns>
        [HttpGet]
        public IEnumerable<BeneficioXVaga> Get()
        {
            return _beneficioXVagaRepository.GetAll();
        }


        /*Listar um tipo de vaga buscando por id*/

        /// <summary>
        /// Buscar benefícios por id
        /// </summary>
        /// <param name="id">Id do benefício a ser buscado</param>
        /// <returns>Benefício buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_beneficioXVagaRepository.GetById(id) != null)
            {
                return Ok(_beneficioXVagaRepository.GetById(id));
            }
            else
            {
                return BadRequest("Benefícios da vaga não encontrados.");
            }
        }

        /*Cadastrar um novo tipo de vaga*/
        /// <summary>
        /// Cadastrar benefícios de uma vaga
        /// </summary>
        /// <param name="beneficioVaga">Novos benefícios</param>
        [HttpPost]
        public IActionResult Post(BeneficioXVaga beneficioVaga)
        {
            try
            {
                _beneficioXVagaRepository.Add(beneficioVaga);

                return Ok("Benefícios da vaga cadastrados com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Não foi possível cadastrar os benefícios da vaga!");
            }

        }

        /// <summary>
        /// Atualizar benefícios de uma vaga
        /// </summary>
        /// <param name="id">Id do benefício que será atualizado</param>
        /// <param name="novoTipo">Benefícos atualizados</param>

        [HttpPut("{id}")]
        public IActionResult Put(int id, BeneficioXVaga novoTipo)
        {

            try
            {
                BeneficioXVaga UPDATE = new BeneficioXVaga
                {
                    IdBeneficioVaga = id,
                    IdBeneficioNavigation = novoTipo.IdBeneficioNavigation,
                    IdBeneficio = novoTipo.IdBeneficio

                };

                _beneficioXVagaRepository.Update(UPDATE);

                return Ok("Beneficios da vaga atualizados com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar os benefícios da vaga");
            }
        }

        /*Deletar Tipo de vaga*/

        /// <summary>
        /// Deletar benefícios de uma vaga
        /// </summary>
        /// <param name="id">Id dos benefícios que serão deletados</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                BeneficioXVaga beneficiosBuscado = _beneficioXVagaRepository.GetById(id);
                _beneficioXVagaRepository.Delete(beneficiosBuscado);

                return Ok("Tipo de vaga deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar os benefícios da vaga");
            }

        }
    }
}
