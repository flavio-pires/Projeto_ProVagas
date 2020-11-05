using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProVagas.Domains;

namespace ProVagas.ViewsModels
{
    public class CadastrarAdmViewModels
    {
        public string NomeCompleto { get; set;}
        public string Email { get; set;}
        public string Senha { get; set;}
        public string UnidadeSenai { get; set; }
        public string Departamento { get; set; }
        public string Telefone { get; set; }
        public string NIF { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }

    }
}
