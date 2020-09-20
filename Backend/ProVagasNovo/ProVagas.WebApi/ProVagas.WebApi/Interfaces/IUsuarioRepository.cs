using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Interfaces
{
    interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario BuscarSenhaEmail(string email, string senha);
    }
}
