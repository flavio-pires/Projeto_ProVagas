using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface ICandidatoRepository : IRepositoryBase<Candidato>
    {

        Candidato Login(string email, string senha);
    }
}
