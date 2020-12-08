using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Provagas.ViewsModels
{
    public class InscricaoViewModels
    {
        public string NomeVaga { get; set; }
        public string DescricaoAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public int? LimiteDeInscricao { get; set; }
        public string Localizacao { get; set; }
        public string Salario { get; set; }
        public bool? AceitaTrabalhoRemoto { get; set; }
        public ICollection<string> Beneficios { get; set; }
    }
}
