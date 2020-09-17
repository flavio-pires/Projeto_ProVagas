using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IAdministradorRepository : IRepositoryBase<Administrador>
    {
        List<Candidato> ListarCandidato();
        List<Empresa> ListarEmpresa();
        List<Administrador> ListarAdministrador();
        



    }
}
