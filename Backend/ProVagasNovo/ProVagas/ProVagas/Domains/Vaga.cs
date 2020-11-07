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
<<<<<<< HEAD:Backend/ProVagas/Domains/Vaga.cs
            RequisitoXvaga = new HashSet<RequisitoXVaga>();
=======
            RequisitoXvaga = new HashSet<RequisitoXvaga>();
>>>>>>> fbb80b285682ca3eda397ff93749bf150e1ecdec:Backend/ProVagasNovo/ProVagas.WebApi/ProVagas.WebApi/Domains/Vaga.cs
        }

        public int IdVaga { get; set; }
        public string NomeVaga { get; set; }
        public string DescricaoAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
<<<<<<< HEAD:Backend/ProVagas/Domains/Vaga.cs
        public int? IdEmpresa { get; set; }
        public int? IdTipoVaga { get; set; }
=======
        public int? LimiteDeInscricao { get; set; }
        public string Localização { get; set; }
        public string Salario { get; set; }
        public bool? AceitaTrabalhoRemoto { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdTipoVaga { get; set; }
        public int? IdNivelVaga { get; set; }
>>>>>>> fbb80b285682ca3eda397ff93749bf150e1ecdec:Backend/ProVagasNovo/ProVagas.WebApi/ProVagas.WebApi/Domains/Vaga.cs

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual NivelVaga IdNivelVagaNavigation { get; set; }
        public virtual TipoVaga IdTipoVagaNavigation { get; set; }
        public virtual ICollection<BeneficioXVaga> BeneficioXVaga { get; set; }
        public virtual ICollection<Inscricao> Inscricao { get; set; }
<<<<<<< HEAD:Backend/ProVagas/Domains/Vaga.cs
        public virtual ICollection<RequisitoXVaga> RequisitoXvaga { get; set; }
=======
        public virtual ICollection<RequisitoXvaga> RequisitoXvaga { get; set; }
>>>>>>> fbb80b285682ca3eda397ff93749bf150e1ecdec:Backend/ProVagasNovo/ProVagas.WebApi/ProVagas.WebApi/Domains/Vaga.cs
    }
}
