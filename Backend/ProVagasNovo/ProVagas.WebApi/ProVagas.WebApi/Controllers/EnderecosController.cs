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
    public class EnderecoController : ControllerBase
    {

        private IEnderecoRepository _enderecorepository { get; set; }

        public EnderecoController()
        {

            _enderecorepository = new EnderecoRepository();
        }

        [HttpGet]
        public IEnumerable<Endereco> Get()
        {
            return _enderecorepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_enderecorepository.GetById(id) != null)
            {
                return Ok(_enderecorepository.GetById(id));
            }
            else
            {
                return BadRequest("Endereço não encontrado.");
            }
        }

        [HttpPost]
        public IActionResult Post(Endereco ende)
        {
            try
            {
                _enderecorepository.Add(ende);

                return Ok("Endereco cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Endereco não cadastrado");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Endereco enderecoatt)
        {

            try
            {
                Endereco UPDATE = new Endereco
                {
                    IdEndereco = id,
                    Rua = enderecoatt.Rua,
                    Num = enderecoatt.Num,
                    Bairro = enderecoatt.Bairro,
                    Complemento = enderecoatt.Complemento,
                    Cep = enderecoatt.Cep,
                    IdCidade = enderecoatt.IdCidade,
                    IdUsuario = enderecoatt.IdUsuario
                };

                _enderecorepository.Update(UPDATE);

                return Ok("Endereco atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse endereco");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Endereco enderecoBuscado = _enderecorepository.GetById(id);
                _enderecorepository.Delete(enderecoBuscado);

                return Ok("Endereco deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse endereco");
            }

        }
    }
}