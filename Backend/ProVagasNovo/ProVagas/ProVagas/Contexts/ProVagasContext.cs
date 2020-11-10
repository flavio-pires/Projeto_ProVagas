using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProVagas.Domains;

namespace ProVagas.Contexts
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
        public virtual DbSet<NivelVaga> NivelVaga { get; set; }
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
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PGC5401\\SQLEXPRESS; Initial Catalog=ProVagas; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador)
                    .HasName("PK__Administ__2B3E34A841E068B7");

                entity.HasIndex(e => e.Nif)
                    .HasName("UQ__Administ__C7DEC33088DD9F80")
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

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Administr__IdUsu__6A30C649");
            });

            modelBuilder.Entity<Beneficio>(entity =>
            {
                entity.HasKey(e => e.IdBeneficio)
                    .HasName("PK__Benefici__14B7CA0CDB897B12");

                entity.Property(e => e.NomeBeneficio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BeneficioXvaga>(entity =>
            {
                entity.HasKey(e => e.IdBeneficioVaga)
                    .HasName("PK__Benefici__44F955EB6806179B");

                entity.ToTable("BeneficioXVaga");

                entity.HasOne(d => d.IdBeneficioNavigation)
                    .WithMany(p => p.BeneficioXvaga)
                    .HasForeignKey(d => d.IdBeneficio)
                    .HasConstraintName("FK__Beneficio__IdBen__114A936A");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.BeneficioXvaga)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Beneficio__IdVag__123EB7A3");
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasKey(e => e.IdCandidato)
                    .HasName("PK__Candidat__D55989051C0770A5");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Candidat__C1F8973189474E8C")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Curriculo)
                    .HasMaxLength(1)
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

                entity.Property(e => e.TesteDePersonalidade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Candidato__IdEnd__4AB81AF0");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__Candidato__IdGen__4BAC3F29");

                entity.HasOne(d => d.IdNivelEscolaridadeNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdNivelEscolaridade)
                    .HasConstraintName("FK__Candidato__IdNiv__4CA06362");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.IdCidade)
                    .HasName("PK__Cidade__160879A3F75E4349");

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Cidade__IdEstado__3D5E1FD2");
            });

            modelBuilder.Entity<CursoExtraCurricular>(entity =>
            {
                entity.HasKey(e => e.IdCursoExtraCurricular)
                    .HasName("PK__CursoExt__B9EEEFD29B334363");

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
                    .HasConstraintName("FK__CursoExtr__IdCan__60A75C0F");
            });

            modelBuilder.Entity<CursoSenai>(entity =>
            {
                entity.HasKey(e => e.IdCursoSenai)
                    .HasName("PK__CursoSEN__50BD1AC3FC3E49F5");

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
                    .HasConstraintName("FK__CursoSENA__IdCan__5DCAEF64");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__5EF4033EDA852476");

                entity.HasIndex(e => e.Cnae)
                    .HasName("UQ__Empresa__AA5E6DE4CE8A212E")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Empresa__AA57D6B432429C65")
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
                    .HasConstraintName("FK__Empresa__IdEnder__71D1E811");

                entity.HasOne(d => d.IdPorteNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdPorte)
                    .HasConstraintName("FK__Empresa__IdPorte__70DDC3D8");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__0B7C7F177E7ECF9E");

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
                    .HasConstraintName("FK__Endereco__IdCida__440B1D61");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Endereco__IdUsua__44FF419A");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__FBB0EDC1B9ED7A6A");

                entity.Property(e => e.NomeEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estagio>(entity =>
            {
                entity.HasKey(e => e.IdEstagio)
                    .HasName("PK__Estagio__C70AD76CC2E70D8E");

                entity.Property(e => e.DataFinal).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.HasOne(d => d.IdInscricaoNavigation)
                    .WithMany(p => p.Estagio)
                    .HasForeignKey(d => d.IdInscricao)
                    .HasConstraintName("FK__Estagio__IdInscr__0B91BA14");

                entity.HasOne(d => d.IdStatusEstagioNavigation)
                    .WithMany(p => p.Estagio)
                    .HasForeignKey(d => d.IdStatusEstagio)
                    .HasConstraintName("FK__Estagio__IdStatu__0C85DE4D");
            });

            modelBuilder.Entity<ExperienciaProfissional>(entity =>
            {
                entity.HasKey(e => e.IdExperienciaProfissional)
                    .HasName("PK__Experien__7772B9DED5D33277");

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
                    .HasConstraintName("FK__Experienc__IdCan__5AEE82B9");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F8349889321CDB0");

                entity.Property(e => e.NomeGenero)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__0DD4B30D3C9F0626");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HabilidadeXcandidato>(entity =>
            {
                entity.HasKey(e => e.IdHabilidadeCandidato)
                    .HasName("PK__Habilida__F8880B5E2B5E0FB6");

                entity.ToTable("HabilidadeXCandidato");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.HabilidadeXcandidato)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__Habilidad__IdCan__66603565");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.HabilidadeXcandidato)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__Habilidad__IdHab__656C112C");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdIdioma)
                    .HasName("PK__Idioma__C867BD3660A398B9");

                entity.Property(e => e.NomeIdioma)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.Idioma)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__Idioma__IdCandid__5812160E");

                entity.HasOne(d => d.IdNivelIdiomaNavigation)
                    .WithMany(p => p.Idioma)
                    .HasForeignKey(d => d.IdNivelIdioma)
                    .HasConstraintName("FK__Idioma__IdNivelI__571DF1D5");
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasKey(e => e.IdInscricao)
                    .HasName("PK__Inscrica__6209444B996E3138");

                entity.Property(e => e.DataInscricao).HasColumnType("date");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__Inscricao__IdCan__06CD04F7");

                entity.HasOne(d => d.IdStatusInscricaoNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdStatusInscricao)
                    .HasConstraintName("FK__Inscricao__IdSta__05D8E0BE");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Inscricao__IdVag__04E4BC85");
            });

            modelBuilder.Entity<NivelEscolaridade>(entity =>
            {
                entity.HasKey(e => e.IdNivelEscolaridade)
                    .HasName("PK__NivelEsc__8D474527B82DB293");

                entity.Property(e => e.Escolaridade)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelIdioma>(entity =>
            {
                entity.HasKey(e => e.IdNivelIdioma)
                    .HasName("PK__NivelIdi__CC7EE08078213BBF");

                entity.Property(e => e.NomeNivel)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelVaga>(entity =>
            {
                entity.HasKey(e => e.IdNivelVaga)
                    .HasName("PK__NivelVag__465CED7E6F484E64");

                entity.Property(e => e.NomeNivelVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pcd>(entity =>
            {
                entity.HasKey(e => e.IdPcd)
                    .HasName("PK__PCD__2ACD55CD37B97CA9");

                entity.ToTable("PCD");

                entity.Property(e => e.IdPcd).HasColumnName("IdPCD");

                entity.Property(e => e.NomeDeficiencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PcdXcandidato>(entity =>
            {
                entity.HasKey(e => e.IdPcdCandidato)
                    .HasName("PK__PcdXCand__388A24AAFA83C430");

                entity.ToTable("PcdXCandidato");

                entity.Property(e => e.IdPcd).HasColumnName("IdPCD");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.PcdXcandidato)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__PcdXCandi__IdCan__5165187F");

                entity.HasOne(d => d.IdPcdNavigation)
                    .WithMany(p => p.PcdXcandidato)
                    .HasForeignKey(d => d.IdPcd)
                    .HasConstraintName("FK__PcdXCandi__IdPCD__52593CB8");
            });

            modelBuilder.Entity<PorteEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdPorteEmpresa)
                    .HasName("PK__PorteEmp__3E4579131EF73A06");

                entity.Property(e => e.NomePorte)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Requisito>(entity =>
            {
                entity.HasKey(e => e.IdRequisito)
                    .HasName("PK__Requisit__661FC7C2FE0C7B7F");

                entity.Property(e => e.NomeRequisito)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RequisitoXvaga>(entity =>
            {
                entity.HasKey(e => e.IdRequisitoVaga)
                    .HasName("PK__Requisit__A350B0235AFE99CB");

                entity.ToTable("RequisitoXVaga");

                entity.HasOne(d => d.IdRequisitoNavigation)
                    .WithMany(p => p.RequisitoXvaga)
                    .HasForeignKey(d => d.IdRequisito)
                    .HasConstraintName("FK__Requisito__IdReq__7F2BE32F");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.RequisitoXvaga)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Requisito__IdVag__00200768");
            });

            modelBuilder.Entity<StatusEstagio>(entity =>
            {
                entity.HasKey(e => e.IdStatusEstagio)
                    .HasName("PK__StatusEs__A18FA5E7BB3B997E");

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusInscricao>(entity =>
            {
                entity.HasKey(e => e.IdStatusInscricao)
                    .HasName("PK__StatusIn__4F419FD7D27066FC");

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BE59879CD");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoVaga>(entity =>
            {
                entity.HasKey(e => e.IdTipoVaga)
                    .HasName("PK__TipoVaga__763461BCDA1A6055");

                entity.Property(e => e.NomeTipoVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF970D07AE12");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D1053407BF68B3")
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
                    .HasConstraintName("FK__Usuario__IdTipoU__412EB0B6");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga)
                    .HasName("PK__Vaga__A848DC3E427F74E9");

                entity.Property(e => e.DataFinal).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.DescricaoAtividade)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Localização)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Vaga__IdEmpresa__787EE5A0");

                entity.HasOne(d => d.IdNivelVagaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdNivelVaga)
                    .HasConstraintName("FK__Vaga__IdNivelVag__7A672E12");

                entity.HasOne(d => d.IdTipoVagaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdTipoVaga)
                    .HasConstraintName("FK__Vaga__IdTipoVaga__797309D9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
