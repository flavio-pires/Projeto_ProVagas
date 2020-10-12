using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Interfaces
{
    interface IEmpresaRepository : IRepositoryBase<Empresa>
    {

        Empresa Login(string email, string senha);
    }
}
