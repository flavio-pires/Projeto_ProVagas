using ProVagas.WebApi.Domains;
using ProVagas.WebApi.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Interfaces
{
    interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario BuscarSenhaEmail(string email, string senha);

        bool CadastrarAdm(CadastrarAdmViewModels cadastrarAdmViewModels);
    }
}
