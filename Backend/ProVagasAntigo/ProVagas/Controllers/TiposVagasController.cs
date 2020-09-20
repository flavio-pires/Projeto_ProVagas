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
    public class TiposVagasController : ControllerBase
    {
        private ITipoVagaRepository _tipoVagaRepository { get; set; }

        public TiposVagasController()
        {

            _tipoVagaRepository = new TipoVagaRepository();
        }

        /*Listar todos os tipos de de vaga*/

        /// <summary>
        /// Listar níveis de inglês
        /// </summary>
        /// <returns>Lista com todos os níveis de inglês</returns>
        [HttpGet]
        public IEnumerable<TipoVaga> Get()
        {
            return _tipoVagaRepository.GetAll();
        }


        /*Listar um tipo de vaga buscando por id*/

        /// <summary>
        /// Buscar um tipo de vaga por Id
        /// </summary>
        /// <param name="id">Id do tipo a ser buscado</param>
        /// <returns>Um tipo de Vaga</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_tipoVagaRepository.GetById(id) != null)
            {
                return Ok(_tipoVagaRepository.GetById(id));
            }
            else
            {
                return BadRequest("Tipo de vaga não encontrado.");
            }
        }

        /*Cadastrar um novo tipo de vaga*/
        /// <summary>
        /// Cadastrar um novo tipo de vaga
        /// </summary>
        /// <param name="tipoVaga">Novo tipo de vaga</param>
        [HttpPost]
        public IActionResult Post(TipoVaga tipoVaga)
        {
            try
            {
                _tipoVagaRepository.Add(tipoVaga);

                return Ok("Novo tipo de vaga cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Novo tipo de vaga não cadastrado");
            }

        }

        /// <summary>
        /// Atualizar um tipo de vaga
        /// </summary>
        /// <param name="id">Id do tipo de vaga a ser atualizado</param>
        /// <param name="novoTipo">Tipo de vaga atualizado</param>

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoVaga novoTipo)
        {

            try
            {
                TipoVaga UPDATE = new TipoVaga
                {
                    IdTipoVaga = id,
                    NomeTipoVaga = novoTipo.NomeTipoVaga
                };

                _tipoVagaRepository.Update(UPDATE);

                return Ok("Tipo de vaga atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse tipo");
            }
        }

        /*Deletar Tipo de vaga*/

        /// <summary>
        /// Deletar um tipo de vaga
        /// </summary>
        /// <param name="id">Id do tipo que será deletado</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoVaga tipoBuscado = _tipoVagaRepository.GetById(id);
                _tipoVagaRepository.Delete(tipoBuscado);

                return Ok("Tipo de vaga deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse tipo de vaga");
            }

        }
    }
}
