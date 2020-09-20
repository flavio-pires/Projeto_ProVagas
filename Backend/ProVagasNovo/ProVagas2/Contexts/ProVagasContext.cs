using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProVagas2.Domains;

namespace ProVagas2.Contexts
{
    public partial class ProVagasContext : DbContext
    {
        public ProVagasContext()
        {
        }

        public ProVagasContext(DbContextOptions<ProVagasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Beneficio> Beneficio { get; set; }
        public virtual DbSet<BeneficioXvaga> BeneficioXvaga { get; set; }
        public virtual DbSet<Candidato> Candidato { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<CursoExtraCurricular> CursoExtraCurricular { get; set; }
        public virtual DbSet<CursoSenai> CursoSenai { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Estagio> Estagio { get; set; }
        public virtual DbSet<ExperienciaProfissional> ExperienciaProfissional { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Habilidade> Habilidade { get; set; }
        public virtual DbSet<HabilidadeXcandidato> HabilidadeXcandidato { get; set; }
        public virtual DbSet<Idioma> Idioma { get; set; }
        public virtual DbSet<Inscricao> Inscricao { get; set; }
        public virtual DbSet<NivelEscolaridade> NivelEscolaridade { get; set; }
        public virtual DbSet<NivelIdioma> NivelIdioma { get; set; }
        public virtual DbSet<Pcd> Pcd { get; set; }
        public virtual DbSet<PcdXcandidato> PcdXcandidato { get; set; }
        public virtual DbSet<PorteEmpresa> PorteEmpresa { get; set; }
        public virtual DbSet<Requisito> Requisito { get; set; }
        public virtual DbSet<RequisitoXvaga> RequisitoXvaga { get; set; }
        public virtual DbSet<StatusEstagio> StatusEstagio { get; set; }
        public virtual DbSet<StatusInscricao> StatusInscricao { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<TipoVaga> TipoVaga { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vaga> Vaga { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=BRUNO-PC; Initial Catalog=ProVagas; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__2B3E34A8F3806294");

                entity.HasIndex(e => e.Nif)
                    .HasName("UQ__Administ__C7DEC33035E64574")
                    .IsUnique();

                entity.Property(e => e.Departamento)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nif)
                    .IsRequired()
                    .HasColumnName("NIF")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NomeCompletoAdmin)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadeSenai)
                    .HasColumnName("UnidadeSENAI")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Administr__IdEnd__4316F928");
            });

            modelBuilder.Entity<Beneficio>(entity =>
            {
                entity.HasKey(e => e.IdBeneficio)
                    .HasName("PK__Benefici__14B7CA0CE8B3FC92");

                entity.Property(e => e.NomeBeneficio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BeneficioXvaga>(entity =>
            {
                entity.HasKey(e => e.IdBeneficioVaga)
                    .HasName("PK__Benefici__44F955EB2B1D8D20");

                entity.ToTable("BeneficioXVaga");

                entity.HasOne(d => d.IdBeneficioNavigation)
                    .WithMany(p => p.BeneficioXvaga)
                    .HasForeignKey(d => d.IdBeneficio)
                    .HasConstraintName("FK__Beneficio__IdBen__6754599E");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.BeneficioXvaga)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Beneficio__IdVag__68487DD7");
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasKey(e => e.IdCandidato)
                    .HasName("PK__Candidat__D5598905F34655AF");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Candidat__C1F897315ACD75A0")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.FotoPerfil).HasColumnType("image");

                entity.Property(e => e.Linkedin)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCompletoCandidato)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Candidato__IdEnd__239E4DCF");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__Candidato__IdGen__24927208");

                entity.HasOne(d => d.IdNivelEscolaridadeNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdNivelEscolaridade)
                    .HasConstraintName("FK__Candidato__IdNiv__25869641");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.IdCidade)
                    .HasName("PK__Cidade__160879A3FBF83637");

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Cidade__IdEstado__164452B1");
            });

            modelBuilder.Entity<CursoExtraCurricular>(entity =>
            {
                entity.HasKey(e => e.IdCursoExtraCurricular)
                    .HasName("PK__CursoExt__B9EEEFD2F683CD12");

                entity.Property(e => e.DataFim).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.Instituicao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nivel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCurso)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.CursoExtraCurricular)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__CursoExtr__IdCan__398D8EEE");
            });

            modelBuilder.Entity<CursoSenai>(entity =>
            {
                entity.HasKey(e => e.IdCursoSenai)
                    .HasName("PK__CursoSEN__50BD1AC3C6CAA033");

                entity.ToTable("CursoSENAI");

                entity.Property(e => e.IdCursoSenai).HasColumnName("IdCursoSENAI");

                entity.Property(e => e.CursandoSenai).HasColumnName("CursandoSENAI");

                entity.Property(e => e.Curso)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.CursoSenai)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__CursoSENA__IdCan__36B12243");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__5EF4033ECFA6BBE3");

                entity.HasIndex(e => e.Cnae)
                    .HasName("UQ__Empresa__AA5E6DE4CA10FD64")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Empresa__AA57D6B44724A147")
                    .IsUnique();

                entity.Property(e => e.Cnae)
                    .IsRequired()
                    .HasColumnName("CNAE")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Linkedin)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeParaContato)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Empresa__IdEnder__4AB81AF0");

                entity.HasOne(d => d.IdPorteNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdPorte)
                    .HasConstraintName("FK__Empresa__IdPorte__49C3F6B7");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__0B7C7F1702916E79");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Complemento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Num)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdCidade)
                    .HasConstraintName("FK__Endereco__IdCida__1CF15040");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Endereco__IdUsua__1DE57479");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__FBB0EDC18ECD1651");

                entity.Property(e => e.NomeEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estagio>(entity =>
            {
                entity.HasKey(e => e.IdEstagio)
                    .HasName("PK__Estagio__C70AD76C671732E2");

                entity.Property(e => e.DataFinal).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.HasOne(d => d.IdInscricaoNavigation)
                    .WithMany(p => p.Estagio)
                    .HasForeignKey(d => d.IdInscricao)
                    .HasConstraintName("FK__Estagio__IdInscr__619B8048");

                entity.HasOne(d => d.IdStatusEstagioNavigation)
                    .WithMany(p => p.Estagio)
                    .HasForeignKey(d => d.IdStatusEstagio)
                    .HasConstraintName("FK__Estagio__IdStatu__628FA481");
            });

            modelBuilder.Entity<ExperienciaProfissional>(entity =>
            {
                entity.HasKey(e => e.IdExperienciaProfissional)
                    .HasName("PK__Experien__7772B9DEEF225845");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DataFim).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.DescriçãoAtividade).HasColumnType("text");

                entity.Property(e => e.NomeEmpresa)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeExperiencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.ExperienciaProfissional)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__Experienc__IdCan__33D4B598");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F834988A4BA63B2");

                entity.Property(e => e.NomeGenero)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__0DD4B30DDF547610");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HabilidadeXcandidato>(entity =>
            {
                entity.HasKey(e => e.IdHabilidadeCandidato)
                    .HasName("PK__Habilida__F8880B5E3F70F642");

                entity.ToTable("HabilidadeXCandidato");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.HabilidadeXcandidato)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__Habilidad__IdCan__3F466844");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.HabilidadeXcandidato)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Habilidad__IdHab__3E52440B");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdIdioma)
                    .HasName("PK__Idioma__C867BD36B1E28103");

                entity.Property(e => e.NomeIdioma)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.Idioma)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__Idioma__IdCandid__30F848ED");

                entity.HasOne(d => d.IdNivelIdiomaNavigation)
                    .WithMany(p => p.Idioma)
                    .HasForeignKey(d => d.IdNivelIdioma)
                    .HasConstraintName("FK__Idioma__IdNivelI__300424B4");
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasKey(e => e.IdInscricao)
                    .HasName("PK__Inscrica__6209444B520E1E5C");

                entity.Property(e => e.DataInscricao).HasColumnType("date");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__Inscricao__IdCan__5CD6CB2B");

                entity.HasOne(d => d.IdStatusInscricaoNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdStatusInscricao)
                    .HasConstraintName("FK__Inscricao__IdSta__5BE2A6F2");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Inscricao__IdVag__5AEE82B9");
            });

            modelBuilder.Entity<NivelEscolaridade>(entity =>
            {
                entity.HasKey(e => e.IdNivelEscolaridade)
                    .HasName("PK__NivelEsc__8D47452749F4E2FF");

                entity.Property(e => e.Escolaridade)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelIdioma>(entity =>
            {
                entity.HasKey(e => e.IdNivelIdioma)
                    .HasName("PK__NivelIdi__CC7EE0809CC20B4E");

                entity.Property(e => e.NomeNivel)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pcd>(entity =>
            {
                entity.HasKey(e => e.IdPcd)
                    .HasName("PK__PCD__2ACD55CDA9EB6C39");

                entity.ToTable("PCD");

                entity.Property(e => e.IdPcd).HasColumnName("IdPCD");

                entity.Property(e => e.NomeDeficiencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PcdXcandidato>(entity =>
            {
                entity.HasKey(e => e.IdPcdCandidato)
                    .HasName("PK__PcdXCand__388A24AA700A99B1");

                entity.ToTable("PcdXCandidato");

                entity.Property(e => e.IdPcd).HasColumnName("IdPCD");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.PcdXcandidato)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__PcdXCandi__IdCan__2A4B4B5E");

                entity.HasOne(d => d.IdPcdNavigation)
                    .WithMany(p => p.PcdXcandidato)
                    .HasForeignKey(d => d.IdPcd)
                    .HasConstraintName("FK__PcdXCandi__IdPCD__2B3F6F97");
            });

            modelBuilder.Entity<PorteEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdPorteEmpresa)
                    .HasName("PK__PorteEmp__3E457913E2FFF1AA");

                entity.Property(e => e.NomePorte)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Requisito>(entity =>
            {
                entity.HasKey(e => e.IdRequisito)
                    .HasName("PK__Requisit__661FC7C29BEE51C8");

                entity.Property(e => e.NomeRequisito)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequisitoXvaga>(entity =>
            {
                entity.HasKey(e => e.IdRequisitoVaga)
                    .HasName("PK__Requisit__A350B023BF454822");

                entity.ToTable("RequisitoXVaga");

                entity.HasOne(d => d.IdRequisitoNavigation)
                    .WithMany(p => p.RequisitoXvaga)
                    .HasForeignKey(d => d.IdRequisito)
                    .HasConstraintName("FK__Requisito__IdReq__5535A963");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.RequisitoXvaga)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Requisito__IdVag__5629CD9C");
            });

            modelBuilder.Entity<StatusEstagio>(entity =>
            {
                entity.HasKey(e => e.IdStatusEstagio)
                    .HasName("PK__StatusEs__A18FA5E789BA24F0");

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusInscricao>(entity =>
            {
                entity.HasKey(e => e.IdStatusInscricao)
                    .HasName("PK__StatusIn__4F419FD74925A270");

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B5207E970");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoVaga>(entity =>
            {
                entity.HasKey(e => e.IdTipoVaga)
                    .HasName("PK__TipoVaga__763461BC6429B247");

                entity.Property(e => e.NomeTipoVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97F2230FFD");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D105340C0AE3CA")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__1A14E395");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga)
                    .HasName("PK__Vaga__A848DC3E09FA141E");

                entity.Property(e => e.DataFinal).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.DescricaoAtividade)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.NomeVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Vaga__IdEmpresa__4F7CD00D");

                entity.HasOne(d => d.IdTipoVagaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdTipoVaga)
                    .HasConstraintName("FK__Vaga__IdTipoVaga__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
