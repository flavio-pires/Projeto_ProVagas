using System;
using System.Collections.Generic;

namespace ProVagas.WebApi.Domains
{
    public partial class CursoExtraCurricular
    {
        public int IdCursoExtraCurricular { get; set; }
        public string NomeCurso { get; set; }
        public string Instituicao { get; set; }
        public string Nivel { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int? IdCandidato { get; set; }

        public virtual Candidato IdCandidatoNavigation { get; set; }
    }
}
