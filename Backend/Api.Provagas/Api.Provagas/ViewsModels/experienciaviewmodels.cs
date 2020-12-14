using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.ViewsModels
{
    public class experienciaviewmodels
    {

        public string NomeExperiencia { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool EmpregoAtual { get; set; }
        public string DescricaoAtividade { get; set; }
        public int IdCandidato { get; set; }
    }
}
