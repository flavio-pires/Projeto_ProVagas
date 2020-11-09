﻿using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario Login(string email, string senha);
    }
}
