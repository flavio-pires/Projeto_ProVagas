using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Vaga
    {
        public Vaga()
        {
            BeneficioXvaga = new HashSet<BeneficioXvaga>();
            Inscricao = new HashSet<Inscricao>();
            RequisitosXvaga = new HashSet<RequisitosXvaga>();
        }

        public int IdVaga { get; set; }
        public string NomeVaga { get; set; }
        public string DescricaoAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoVaga { get; set; }
        public int? IdRequisitos { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Requisitos IdRequisitosNavigation { get; set; }
        public virtual TipoVaga IdTipoVagaNavigation { get; set; }
        public virtual ICollection<BeneficioXvaga> BeneficioXvaga { get; set; }
        public virtual ICollection<Inscricao> Inscricao { get; set; }
        public virtual ICollection<RequisitosXvaga> RequisitosXvaga { get; set; }
    }
}
