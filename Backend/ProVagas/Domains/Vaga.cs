using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Vaga
    {
        public Vaga()
        {
            BeneficioXVaga = new HashSet<BeneficioXVaga>();
            Inscricao = new HashSet<Inscricao>();
            RequisitoXvaga = new HashSet<RequisitoXVaga>();
        }

        public int IdVaga { get; set; }
        public string NomeVaga { get; set; }
        public string DescricaoAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoVaga { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual TipoVaga IdTipoVagaNavigation { get; set; }
        public virtual ICollection<BeneficioXVaga> BeneficioXVaga { get; set; }
        public virtual ICollection<Inscricao> Inscricao { get; set; }
        public virtual ICollection<RequisitoXVaga> RequisitoXvaga { get; set; }
    }
}
