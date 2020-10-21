﻿using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        bool aluno(string email);
        
    }
}