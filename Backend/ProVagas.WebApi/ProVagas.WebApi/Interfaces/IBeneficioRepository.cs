using ProVagas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IBeneficioRepository
    {
        List<Beneficio> Listar();

        void Cadastrar(Beneficio novoEvento);

        void Atualizar(int id, Beneficio EmpresaAtualizada);

        void Deletar(int id);

        Beneficio BuscarPorId(int id);
    }
}
