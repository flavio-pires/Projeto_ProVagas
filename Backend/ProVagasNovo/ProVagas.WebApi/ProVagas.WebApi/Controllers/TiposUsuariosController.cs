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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipouserrepository { get; set; }

        public TiposUsuariosController()
        {

            _tipouserrepository = new TipoUsuarioRepository();
        }

        /*Listar todos os generos*/
        [HttpGet]
        public IEnumerable<TipoUsuario> Get()
        {
            return _tipouserrepository.GetAll();
        }

        /*Listar os generos por id*/
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_tipouserrepository.GetById(id) != null)
            {
                return Ok(_tipouserrepository.GetById(id));
            }
            else
            {
                return BadRequest("Tipo de Usuario não encontrado.");
            }
        }

        /*Cadastrar um novo genero*/
        [HttpPost]
        public IActionResult Post(TipoUsuario tipouser)
        {
            try
            {
                _tipouserrepository.Add(tipouser);

                return Ok("Um novo tipo de usuario foi cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Tipo usuario não cadastrado");
            }

        }

        /*Atualizar os generos*/
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsercadastrado)
        {

            try
            {
                TipoUsuario UPDATE = new TipoUsuario
                {
                    IdTipoUsuario = id,
                    Usuario = tipoUsercadastrado.Usuario
                };

                _tipouserrepository.Update(UPDATE);

                return Ok("Tipo de usuario foi atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse tipo de usuario");
            }
        }

        /*Deletar generos*/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                TipoUsuario tipobuscado = _tipouserrepository.GetById(id);
                _tipouserrepository.Delete(tipobuscado);

                return Ok("Tipo usuario deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse tipo de usuario");
            }
        }
    }
}
