﻿using System;
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
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuariorepository { get; set; }

        public UsuarioController()
        {

            _usuariorepository = new UsuarioRepository();
        }

        /*Listar todos usuarios*/
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _usuariorepository.GetAll();
        }
        /*Listar os usuario por id*/
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_usuariorepository.GetById(id) != null)
            {
                return Ok(_usuariorepository.GetById(id));
            }
            else
            {
                return BadRequest("Usuario não encontrado.");
            }
        }

        ///*Cadastrar um novo usuario*/
        //[HttpPost]
        //public IActionResult Post(Usuario usuario)
        //{
        //    try
        //    {
        //        if (_usuariorepository.aluno(usuario.Email))
        //        {
        //            usuario.IdTipoUsuario = 3;
        //            _usuariorepository.Add(usuario);

        //            return Ok("Usuario cadastrado com sucesso"); 
        //        }

        //        else
        //        {
        //            return BadRequest("Não consta nenhum registro desse email no banco de dados");
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return BadRequest("Usuario não cadastrado");
        //    }

        //}

        [HttpPost]
        public IActionResult Post(Usuario user)
        {
            try
            {
                _usuariorepository.Add(user);

                return Ok("Um novo usuario foi cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Usuario não cadastrado");
            }

        }

        /*Atualizar os usuario*/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {

            try
            {
                Usuario UPDATE = new Usuario
                {
                    IdUsuario = id,
                    Email = usuarioAtualizado.Email,
                    Telefone = usuarioAtualizado.Telefone,
                    Senha = usuarioAtualizado.Senha,
                    IdEndereco = usuarioAtualizado.IdEndereco,
                    IdTipoUsuario = id
                };

                _usuariorepository.Update(UPDATE);

                return Ok("Usuario atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse usuario");
            }
        }

        /*Deletar Usuario*/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Usuario usuariobuscado = _usuariorepository.GetById(id);
                _usuariorepository.Delete(usuariobuscado);

                return Ok("Usuario deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse atualizado");
            }

        }
    }
}
