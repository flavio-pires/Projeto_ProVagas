using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IStatusEstagioRepository 
        List<StatusEstagio> Listar();

        void Cadastrar(StatusEstagio novostatusEstagio);

        void Atualizar(int id, StatusEstagio statusEstagioAtualizado);
        void Deletar(int id);
    }
}
