using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class AdministadorRepository : RepositoryBase<Administrador>, IAdministradorRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        ProVagasContext ctx = new ProVagasContext();

        public List<Candidato> ListarCandidato()
        {
            return (List<Candidato>)ctx.Usuario.Where(u => u.IdTipoUsuario == 3);
        }

        public List<Empresa> ListarEmpresa()
        {
            return (List<Empresa>)ctx.Usuario.Where(e => e.IdTipoUsuario == 2);
        }

        public List<Administrador> ListarAdministrador()
        {
            return (List<Administrador>)ctx.Usuario.Where(e => e.IdTipoUsuario == 1);
        }
    }
}
