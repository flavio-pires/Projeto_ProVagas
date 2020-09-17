using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IAdministradorRepository : IRepositoryBase<Administrador>
    {
        /*List<Usuario> ListarCandidato();
        List<Usuario> ListarEmpresa();
        List<Usuario> ListarAdministrador();
        */
        List<Administrador> Listar();



    }
}
