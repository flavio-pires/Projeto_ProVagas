using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Beneficio
    {
        public Beneficio()
        {
            BeneficioXVaga = new HashSet<BeneficioXVaga>();
        }

        public int IdBeneficio { get; set; }
        public string NomeBeneficio { get; set; }

        public virtual ICollection<BeneficioXVaga> BeneficioXVaga { get; set; }
    }
}
