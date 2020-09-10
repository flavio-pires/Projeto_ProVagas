using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Estagio
    {
        public int IdEstagio { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public int IdCandidato { get; set; }
        public int IdEmpresa { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
    }
}
