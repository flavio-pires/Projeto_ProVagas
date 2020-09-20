using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IEmpresaRepository
    {
        List<Empresa> Listar();

        void Cadastrar(Empresa novaEmpresa);

        void Atualizar(int id, Empresa empresaAtualizada);

        void Deletar(int id);

        Empresa BuscarPorId(int id);
    }
}
