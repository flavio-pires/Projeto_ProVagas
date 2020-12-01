using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Interfaces
{
    interface IAdministradorRepository : IRepositoryBase<Administrador>
    {
        Administrador Login(string email, string senha);
        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="novoAdmin">Objeto com as informações de cadastro</param>
        void Cadastrar(Administrador novoAdmin);
    }
}
