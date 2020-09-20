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
    public class AdministradoresController : ControllerBase
    {
        private IAdministradorRepository _administradorRepository { get; set; }

        private IEmpresaRepository _empresaRepository { get; set; }

        private ICandidatoRepository _candidatoRepository { get; set; }

        public AdministradoresController()
        {
            _administradorRepository = new AdministradorRepository();

            _empresaRepository = new EmpresaRepository();

            _candidatoRepository = new CandidatoRepository();
        }

        /// <summary>
        /// Listar todos administradores
        /// </summary>
        /// <returns> Listar todos administradores</returns>
        [HttpGet]
        public IEnumerable<Administrador> Get()
        {
            return _administradorRepository.GetAll();
        }

        /// <summary>
        /// Listar todas empresas através dos administradores
        /// </summary>
        /// <returns>Listar todas empresas através dos administradores</returns>
        [HttpGet("Empresa")]
        public IActionResult GetEmpresa()
        {
            return Ok(_empresaRepository.GetAll());
        }

        /// <summary>
        /// Listar todos candidatos através dos administradores
        /// </summary>
        /// <returns>Listar todos candidatos através dos administradores</returns>
        [HttpGet("Candidato")]
        public IActionResult GetCandidato()
        {
            return Ok(_candidatoRepository.GetAll());
        }

        /*Listar os administrador por id*/
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_administradorRepository.GetById(id) != null)
            {
                return Ok(_administradorRepository.GetById(id));
            }
            else
            {
                return BadRequest("Administrador não encontrado.");
            }
        }

        [HttpGet("Candidato/{id}")]
        public IActionResult GetCandidato(int id)
        {
            if (_candidatoRepository.GetById(id) != null)
            {
                return Ok(_candidatoRepository.GetById(id));
            }
            else
            {
                return BadRequest("Candidato não encontrado.");
            }
        }


        [HttpGet("Empresa/{id}")]
        public IActionResult GetEmpresa(int id)
        {
            if (_empresaRepository.GetById(id) != null)
            {
                return Ok(_empresaRepository.GetById(id));
            }
            else
            {
                return BadRequest("Empresa não encontrado.");
            }
        }


        /*Cadastrar um novo candidato*/
        [HttpPost("Candidato/{id}")]
        public IActionResult Post(Candidato cand)
        {
            try
            {
                _candidatoRepository.Add(cand);

                return Ok("Candidato cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Candidato não cadastrado");
            }

        }

        /*Cadastrar um novo administadro*/
        [HttpPost]
        public IActionResult PostAdministrador(Administrador adm)
        {
            try
            {
                _administradorRepository.Add(adm);

                return Ok("Administrador cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Administrador não cadastrado");
            }

        }


        /*Cadastrar uma nova empresa*/
        [HttpPost("Empresa")]
        public IActionResult PostEmpresa(Empresa emp)
        {
            try
            {
                _empresaRepository.Add(emp);

                return Ok("Empresa cadastrado com sucesso");
            }
            catch (Exception)
            {

                return BadRequest("Empresa não cadastrado");
            }

        }
        /*Atualizar os generos*/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Administrador administrador)
        {

            try
            {
                Administrador UPDATE = new Administrador
                {
                    IdAdministrador = id,
                    NomeCompletoAdmin = administrador.NomeCompletoAdmin,
                    Nif = administrador.Nif,
                    Departamento = administrador.Departamento,
                    UnidadeSenai = administrador.UnidadeSenai,
                    IdUsuario = administrador.IdUsuario
                };

                _administradorRepository.Update(UPDATE);

                return Ok("Administrador atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse administrador");
            }
        }


        /*Atualizar os Candidato*/
        [HttpPut("Candidato/{id}")]
        public IActionResult PutCandidato(int id, Candidato can)
        {

            try
            {
                Candidato UPDATE = new Candidato
                {
                    IdCandidato = id,
                    NomeCompletoCandidato = can.NomeCompletoCandidato,
                    Cpf = can.Cpf,
                    DataNascimento = can.DataNascimento,
                    Linkedin = can.Linkedin
                };

                _candidatoRepository.Update(UPDATE);

                return Ok("Candidato atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse candidato");
            }
        }
        /*Atualizar os Candidato*/
        [HttpPut("Empresa/{id}")]
        public IActionResult PutEmpresa(int id, Empresa emp)
        {

            try
            {
                Empresa UPDATE = new Empresa
                {
                    IdEmpresa = id,
                    RazaoSocial = emp.RazaoSocial,
                    NomeFantasia = emp.NomeFantasia,
                    NomeParaContato = emp.NomeParaContato,
                    Linkedin = emp.Linkedin,
                    Website = emp.Website,
                    Cnpj = emp.Cnpj,
                    Cnae = emp.Cnae
                };

                _empresaRepository.Update(UPDATE);

                return Ok("Empresa atualizado com sucesso");

            }

            catch (Exception)
            {
                return BadRequest("Não foi possivel atualizar esse empresa");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Administrador administradorBuscado = _administradorRepository.GetById(id);
                _administradorRepository.Delete(administradorBuscado);

                return Ok("Administrador deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse administrador");
            }

        }

        /*Deletar Candidato*/
        [HttpDelete("Candidato/{id}")]
        public IActionResult DeleteCandidato(int id)
        {
            try
            {
                Candidato candidatoBuscado = _candidatoRepository.GetById(id);
                _candidatoRepository.Delete(candidatoBuscado);

                return Ok("Candidato deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar esse candidato");
            }

        }

        [HttpDelete("Empresa/{id}")]
        public IActionResult DeleteEmpresa(int id)
        {
            try
            {
                Empresa empresaBuscada = _empresaRepository.GetById(id);
                _empresaRepository.Delete(empresaBuscada);

                return Ok("Empresa deletado com sucesso");

            }
            catch (Exception)
            {
                return BadRequest("Não foi possivel deletar essa empresa");
            }

        }


    }
}