using System;
using System.Collections.Generic;

namespace ProVagas.Domains
{
    public partial class Candidato
    {
        public Candidato()
        {
            Inscricao = new HashSet<Inscricao>();
        }

        public int IdCandidato { get; set; }
        public string NomeCompletoCandidato { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
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
        public int IdNivelIngles { get; set; }
        public int IdNivelEscolaridade { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual NivelEscolaridade IdNivelEscolaridadeNavigation { get; set; }
        public virtual NivelIngles IdNivelInglesNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Inscricao> Inscricao { get; set; }
    }
}
