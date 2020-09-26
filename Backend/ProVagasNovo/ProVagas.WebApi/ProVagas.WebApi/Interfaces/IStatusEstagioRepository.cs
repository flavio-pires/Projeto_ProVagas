using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Interfaces
{
    interface IStatusEstagioRepository { 
        List<StatusEstagio> Listar();

        void Cadastrar(StatusEstagio novostatusEstagio);

        void Atualizar(int id, StatusEstagio statusEstagioAtualizado);
        void Deletar(int id);
    }
}
