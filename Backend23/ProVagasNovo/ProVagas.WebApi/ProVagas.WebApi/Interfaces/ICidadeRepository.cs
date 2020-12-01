using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.WebApi.Interfaces
{
    interface ICidadeRepository
    {
        List<Cidade> Listar();

        void Cadastrar(Cidade novacidade);

        void Atualizar(int id, Cidade cidadeAtualizada);
        void Deletar(int id);
    }
}
