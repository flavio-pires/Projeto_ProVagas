﻿using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Interfaces
{
    interface IEstagioRepository
    {
        List<Estagio> Listar();

        void Cadastrar(Estagio novoEstagio);

        void Atualizar(int id, Estagio estagioAtualizado);

        void Deletar(int id);

        Estagio BuscarPorId(int id);
    }
}