using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IEstagioRepository
    {
        List<Estagio> Listar();

        void Cadastrar(Estagio novoEvento);

        void Atualizar(int id, Estagio EmpresaAtualizada);

        void Deletar(int id);

        Estagio BuscarPorId(int id);
    }
}
