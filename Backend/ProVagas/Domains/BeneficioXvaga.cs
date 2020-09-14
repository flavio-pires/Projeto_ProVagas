using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class BeneficioXVaga
    {
        public int IdBeneficioVaga { get; set; }
        public int? IdBeneficio { get; set; }
        public int? IdVaga { get; set; }

        public virtual Beneficio IdBeneficioNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
    }
}
