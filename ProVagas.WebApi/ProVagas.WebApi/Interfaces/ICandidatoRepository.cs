using ProVagas.WebApi.Domains;
using ProVagas.WebApi.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Interfaces
{
    interface ICandidatoRepository : IRepositoryBase<Candidato>
    {

        Candidato Login(string email, string senha);
        IEnumerable<matchviewmodel> match(int id);

    }
}
