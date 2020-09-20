using System;
using System.Collections.Generic;

namespace ProVagas2.Domains
{
    public partial class Candidato
    {
        public Candidato()
        {
            CursoExtraCurricular = new HashSet<CursoExtraCurricular>();
            CursoSenai = new HashSet<CursoSenai>();
            ExperienciaProfissional = new HashSet<ExperienciaProfissional>();
            HabilidadeXcandidato = new HashSet<HabilidadeXcandidato>();
            Idioma = new HashSet<Idioma>();
            Inscricao = new HashSet<Inscricao>();
            PcdXcandidato = new HashSet<PcdXcandidato>();
        }

        public int IdCandidato { get; set; }
        public string NomeCompletoCandidato { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Linkedin { get; set; }
        public byte[] FotoPerfil { get; set; }
        public int? IdEndereco { get; set; }
        public int? IdGenero { get; set; }
        public int? IdNivelEscolaridade { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual NivelEscolaridade IdNivelEscolaridadeNavigation { get; set; }
        public virtual ICollection<CursoExtraCurricular> CursoExtraCurricular { get; set; }
        public virtual ICollection<CursoSenai> CursoSenai { get; set; }
        public virtual ICollection<ExperienciaProfissional> ExperienciaProfissional { get; set; }
        public virtual ICollection<HabilidadeXcandidato> HabilidadeXcandidato { get; set; }
        public virtual ICollection<Idioma> Idioma { get; set; }
        public virtual ICollection<Inscricao> Inscricao { get; set; }
        public virtual ICollection<PcdXcandidato> PcdXcandidato { get; set; }
    }
}
