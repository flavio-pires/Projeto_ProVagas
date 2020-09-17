using ProVagas.Contexts;
using ProVagas.Domains;
using ProVagas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Repositories
{
    public class AdministadorRepository : RepositoryBase<Administrador>,  IAdministradorRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
       /* ProVagasContext ctx = new ProVagasContext();

        public List<Usuario> ListarCandidato()
        {
            return (List<Usuario>)ctx.Usuario.Where(u => u.IdTipoUsuario == 3);
        }

        public List<Usuario> ListarEmpresa()
        {
            return (List<Usuario>)ctx.Usuario.Where(e => e.IdTipoUsuario == 2);
        }

        public List<Usuario> ListarAdministrador()
        {
            return (List<Usuario>)ctx.Usuario.Where(e => e.IdTipoUsuario == 1);
        }

        public void Add(Administrador obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Administrador obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Administrador obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Administrador> GetAll()
        {
            throw new NotImplementedException();
        }

        public Administrador GetById(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}
