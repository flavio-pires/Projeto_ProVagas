using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IEstadoRepository 
    {
        List<Estado> Listar();
        void Cadastrar(Estado novoEstado);
        void Atualizar(int id, Estado estadoAtualizado);
        void Deletar(int id);
    }
}
