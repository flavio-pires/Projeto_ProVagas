using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public int CadastrarEndereco(Endereco endereco)
        {
            using (ProVagasContext ctx = new ProVagasContext())
            {
                ctx.Endereco.Add(endereco);
                ctx.SaveChanges();

                return endereco.IdEndereco;
            }
        }
    }
}
