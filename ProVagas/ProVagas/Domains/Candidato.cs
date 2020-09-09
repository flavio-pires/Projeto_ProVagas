using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Candidato
    {
        public Candidato()
        {
            Estagio = new HashSet<Estagio>();
            Inscricao = new HashSet<Inscricao>();
        }

        public int IdCandidato { get; set; }
        public string NomeCompletoCandidato { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string NivelEscolaridade { get; set; }
        public string NivelInglês { get; set; }
        public string Linkedin { get; set; }
        public byte[] FotoPerfil { get; set; }
        public bool PossuiDeficiencia { get; set; }
        public string Deficiencia { get; set; }
        public bool CursandoSenai { get; set; }
        public string Curso { get; set; }
        public string Habilidades { get; set; }
        public string NomeEmpresaExperienciaProfissional { get; set; }
        public string Cargo { get; set; }
        public bool? EmpregoAtual { get; set; }
        public string Atividades { get; set; }
        public int IdUsuario { get; set; }
        public int IdGenero { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Estagio> Estagio { get; set; }
        public virtual ICollection<Inscricao> Inscricao { get; set; }
    }
}
