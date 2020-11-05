using ProVagas.Domains;
using ProVagas.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario BuscarSenhaEmail(string email, string senha);

        bool CadastrarAdm(CadastrarAdmViewModels cadastrarCandidatoViewModel);
    }
}
