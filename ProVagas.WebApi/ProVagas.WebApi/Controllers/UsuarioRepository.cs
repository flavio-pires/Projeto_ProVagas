using ProVagas.WebApi.Domains;
using ProVagas.WebApi.Interfaces;
using ProVagas.WebApi.ViewsModels;
using System.Collections.Generic;

namespace ProVagas.WebApi.Controllers
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario obj)
        {
            throw new System.NotImplementedException();
        }

        public Usuario BuscarSenhaEmail(string email, string senha)
        {
            throw new System.NotImplementedException();
        }

        public bool CadastrarAdm(CadastrarAdmViewModels cadastrarAdmViewModels)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Usuario obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new System.NotImplementedException();
        }
    }
}