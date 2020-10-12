using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProVagas.ViewModels;
using ProVagas.WebApi.Domains;
using ProVagas.WebApi.Interfaces;
using ProVagas.WebApi.Repositories;

namespace ProVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ICandidatoRepository _candidatoRepository { get; set; }
        private IEmpresaRepository _empresRepository { get; set; }
        private IAdministradorRepository _administradorRepository { get; set; }

        public LoginController()
        {
            _candidatoRepository = new CandidatoRepository();

            _empresRepository = new EmpresaRepository();

            _administradorRepository = new AdministradorRepository();
        }

        /// <summary>
        /// Realizar login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Retorna o token do login</returns>
        [HttpPost]
        public IActionResult Post(string logintipo, LoginViewModels login)
        {

            switch (logintipo)
            {
                case "Candidato":
                  
            Candidato candidatoBuscado = _candidatoRepository.Login(login.Email, login.Senha);

            if (candidatoBuscado == null)
            {
                return NotFound("E-mail ou senha inválido!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, candidatoBuscado.IdEnderecoNavigation.IdUsuarioNavigation.Email),
                new Claim(JwtRegisteredClaimNames.Jti, candidatoBuscado.IdCandidato.ToString()),
                new Claim(ClaimTypes.Role, candidatoBuscado.IdEnderecoNavigation.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ProVagas-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "ProVagas",
                audience: "ProVagas",
                claims: claims,
                expires: DateTime.Now.AddMinutes(6400),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

                case "Empresa":

                    Empresa empresaBuscado = _empresRepository.Login(login.Email, login.Senha);

                    if (empresaBuscado == null)
                    {
                        return BadRequest("E-mail ou senha incorreta");
                    }

                     claims = new[]
                    {
                new Claim(JwtRegisteredClaimNames.Email, empresaBuscado.IdEnderecoNavigation.IdUsuarioNavigation.Email),
                new Claim(JwtRegisteredClaimNames.Jti, empresaBuscado.IdEmpresa.ToString()),
                new Claim(ClaimTypes.Role, empresaBuscado.IdEnderecoNavigation.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario.ToString())
                    };

                     key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ProVagas-chave-autenticacao"));

                     creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                     token = new JwtSecurityToken(
                        issuer: "ProVagas",
                        audience: "ProVagas",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(6400),
                        signingCredentials: creds
                    );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });

                case "Administrador":

                    Administrador admBuscado = _administradorRepository.Login(login.Email, login.Senha);

                    if (admBuscado == null)
                    {
                        return BadRequest("E-mail ou senha incorreta");
                    }

                    claims = new[]
                   {
                new Claim(JwtRegisteredClaimNames.Email, admBuscado.IdUsuarioNavigation.Email),
                new Claim(JwtRegisteredClaimNames.Jti, admBuscado.IdAdministrador.ToString()),
                new Claim(ClaimTypes.Role, admBuscado.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario.ToString())
                    };

                    key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ProVagas-chave-autenticacao"));

                    creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    token = new JwtSecurityToken(
                       issuer: "ProVagas",
                       audience: "ProVagas",
                       claims: claims,
                       expires: DateTime.Now.AddMinutes(6400),
                       signingCredentials: creds
                   );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });

                default: return BadRequest("Erro no login");

            }
        }
    }
}