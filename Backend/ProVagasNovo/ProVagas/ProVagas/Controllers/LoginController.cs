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
using ProVagas.Domains;
using ProVagas.Interfaces;
using ProVagas.Repositories;

namespace ProVagas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ICandidatoRepository _candidatoRepository { get; set; }
        private IEmpresaRepository _empresRepository { get; set; }
        private IAdministradorRepository _administradorRepository { get; set; }

        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _candidatoRepository = new CandidatoRepository();

            _empresRepository = new EmpresaRepository();

            _administradorRepository = new AdministradorRepository();

            _usuarioRepository = new UsuarioRepsoitory();

        }

        /// <summary>
        /// Realizar login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Retorna o token do login</returns>
        //[HttpPost]
        //public IActionResult Post(string logintipo, LoginViewModels login)
        //{

        //    switch (logintipo)
        //    {
        //        case "Candidato":

        //            Candidato candidatoBuscado = _candidatoRepository.Login(login.Email, login.Senha);

        //            if (candidatoBuscado == null)
        //            {
        //                return NotFound("E-mail ou senha inválido!");
        //            }

        //            var claims = new[]
        //            {
        //        new Claim(JwtRegisteredClaimNames.Email, candidatoBuscado.IdEnderecoNavigation.IdUsuarioNavigation.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti, candidatoBuscado.IdCandidato.ToString()),
        //        new Claim(ClaimTypes.Role, candidatoBuscado.IdEnderecoNavigation.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario.ToString())
        //            };

        //            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("token-provagas"));

        //            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //            var token = new JwtSecurityToken(
        //                issuer: "ProVagas",
        //                audience: "ProVagas",
        //                claims: claims,
        //                expires: DateTime.Now.AddMinutes(6400),
        //                signingCredentials: creds
        //            );

        //            return Ok(new
        //            {
        //                token = new JwtSecurityTokenHandler().WriteToken(token)
        //            });

        //        case "Empresa":

        //            Empresa empresaBuscado = _empresRepository.Login(login.Email, login.Senha);

        //            if (empresaBuscado == null)
        //            {
        //                return BadRequest("E-mail ou senha incorreta");
        //            }

        //             claims = new[]
        //            {
        //        new Claim(JwtRegisteredClaimNames.Email, empresaBuscado.IdEnderecoNavigation.IdUsuarioNavigation.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti, empresaBuscado.IdEmpresa.ToString()),
        //        new Claim(ClaimTypes.Role, empresaBuscado.IdEnderecoNavigation.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario.ToString())
        //            };

        //             key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("token-provagas"));

        //             creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //             token = new JwtSecurityToken(
        //                issuer: "ProVagas",
        //                audience: "ProVagas",
        //                claims: claims,
        //                expires: DateTime.Now.AddMinutes(6400),
        //                signingCredentials: creds
        //            );

        //            return Ok(new
        //            {
        //                token = new JwtSecurityTokenHandler().WriteToken(token)
        //            });

        //        case "Administrador":

        //            Administrador admBuscado = _administradorRepository.Login(login.Email, login.Senha);

        //            if (admBuscado == null)
        //            {
        //                return BadRequest("E-mail ou senha incorreta");
        //            }

        //            claims = new[]
        //           {
        //        new Claim(JwtRegisteredClaimNames.Email, admBuscado.IdUsuarioNavigation.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti, admBuscado.IdAdministrador.ToString()),
        //        new Claim(ClaimTypes.Role, admBuscado.IdUsuarioNavigation.IdTipoUsuarioNavigation.IdTipoUsuario.ToString())
        //            };

        //            key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("token-provagas"));

        //            creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //            token = new JwtSecurityToken(
        //               issuer: "ProVagas",
        //               audience: "ProVagas",
        //               claims: claims,
        //               expires: DateTime.Now.AddMinutes(6400),
        //               signingCredentials: creds
        //           );

        //            return Ok(new
        //            {
        //                token = new JwtSecurityTokenHandler().WriteToken(token)
        //            });

        //        default: return BadRequest("Erro no login");

        //    }
        //}


        [HttpPost]
        public IActionResult Post(LoginViewModels login)
        {
            try
            {
                // Busca o usuário pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                // Caso não encontre nenhum usuário com o e-mail e senha informados
                if (usuarioBuscado == null)
                {
                    // Retorna NotFound com uma mensagem de erro
                    return NotFound("E-mail ou senha inválidos!");
                }

                // Caso o usuário seja encontrado, prossegue para a criação do token

                /*
                    Instalar as dependências:

                    Criar e validar o JWT
                    System.IdentityModel.Tokens.Jwt(5.5.0 ou superior)

                    Integrar a autenticação
                    Microsoft.AspNetCore.Authentication.JwtBearer(2.1.1 ou compatível com o .Net Core do projeto)
                */

                // Define os dados que serão fornecidos no token - Payload
                var claims = new[]
                {
                    // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.NomeTipoUsuario.ToString())
                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("provagas-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var token = new JwtSecurityToken(
                    issuer: "ProVagas",                 // emissor do token
                    audience: "ProVagas",               // destinatário do token
                    claims: claims,                        // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                // Retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido com uma mensagem personalizada
                return BadRequest(new
                {
                    mensagem = "Não foi possível gerar o token",
                    error
                });
            }
        }
    }
}