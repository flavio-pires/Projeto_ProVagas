﻿using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Requisitos
    {
        public Requisitos()
        {
            RequisitosXvaga = new HashSet<RequisitosXvaga>();
        }

        public int IdRequisitos { get; set; }
        public string NomeRequisitos { get; set; }

        public virtual ICollection<RequisitosXvaga> RequisitosXvaga { get; set; }
    }
}
