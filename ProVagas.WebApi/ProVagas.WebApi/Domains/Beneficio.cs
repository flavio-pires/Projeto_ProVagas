using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class Beneficio
    {
        public Beneficio()
        {
            BeneficioXvaga = new HashSet<BeneficioXvaga>();
        }

        public int IdBeneficio { get; set; }
        public string NomeBeneficio { get; set; }

        public virtual ICollection<BeneficioXvaga> BeneficioXvaga { get; set; }
    }
}
