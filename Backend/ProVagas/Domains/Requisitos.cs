using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Requisitos
    {
        public Requisitos()
        {
            RequisitosXvaga = new HashSet<RequisitosXvaga>();
            Vaga = new HashSet<Vaga>();
        }

        public int IdRequisitos { get; set; }
        public string NomeRequisitos { get; set; }

        public virtual ICollection<RequisitosXvaga> RequisitosXvaga { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
