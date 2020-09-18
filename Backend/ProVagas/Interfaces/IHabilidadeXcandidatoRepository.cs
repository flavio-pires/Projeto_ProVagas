using ProVagas.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
    interface IHabilidadeXcandidatoRepository
    {
        List<HabilidadeXCandidato> Listar();

        HabilidadeXCandidato BuscarPorId(int id);

        void Cadastrar(HabilidadeXCandidato novaHabilidadeXCandidato);

        void Atualizar(int id, HabilidadeXCandidato habilidadeXCandidatoAtualizada);

        void Deletar(int id);
    }
}
