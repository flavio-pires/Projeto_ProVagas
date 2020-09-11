using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProVagas.WebApi.Domains;

namespace ProVagas.WebApi.Contexts
{
    public partial class ProVagasBDContext : DbContext
    {
        public ProVagasBDContext()
        {
        }

        public ProVagasBDContext(DbContextOptions<ProVagasBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Beneficio> Beneficio { get; set; }
        public virtual DbSet<BeneficioXvaga> BeneficioXvaga { get; set; }
        public virtual DbSet<Candidato> Candidato { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Estagio> Estagio { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Inscricao> Inscricao { get; set; }
        public virtual DbSet<NivelEscolaridade> NivelEscolaridade { get; set; }
        public virtual DbSet<NivelIngles> NivelIngles { get; set; }
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
                    .HasName("PK__Administ__2B3E34A834E992A6");

                entity.HasIndex(e => e.Nif)
                    .HasName("UQ__Administ__C7DEC330D0787EE4")
                    .IsUnique();

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nif)
                    .HasColumnName("NIF")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NomeCompletoAdmin)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadeSenai)
                    .IsRequired()
                    .HasColumnName("UnidadeSENAI")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Administr__IdUsu__5BE2A6F2");
            });

            modelBuilder.Entity<Beneficio>(entity =>
            {
                entity.HasKey(e => e.IdBeneficio)
                    .HasName("PK__Benefici__14B7CA0C7C77581F");

                entity.Property(e => e.NomeBeneficio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BeneficioXvaga>(entity =>
            {
                entity.HasKey(e => e.IdBeneficioVaga)
                    .HasName("PK__Benefici__44F955EBE42E35FA");

                entity.ToTable("BeneficioXVaga");

                entity.HasOne(d => d.IdBeneficioNavigation)
                    .WithMany(p => p.BeneficioXvaga)
                    .HasForeignKey(d => d.IdBeneficio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Beneficio__IdBen__73BA3083");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.BeneficioXvaga)
                    .HasForeignKey(d => d.IdVaga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Beneficio__IdVag__74AE54BC");
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasKey(e => e.IdCandidato)
                    .HasName("PK__Candidat__D559890547926A11");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Candidat__C1F897313549028B")
                    .IsUnique();

                entity.Property(e => e.Atividades)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CursandoSenai).HasColumnName("CursandoSENAI");

                entity.Property(e => e.Curso)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Deficiencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FotoPerfil).HasColumnType("image");

                entity.Property(e => e.Habilidades)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Linkedin)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCompletoCandidato)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEmpresaExperienciaProfissional)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidato__IdGen__5629CD9C");

                entity.HasOne(d => d.IdNivelEscolaridadeNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdNivelEscolaridade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidato__IdNiv__5812160E");

                entity.HasOne(d => d.IdNivelInglesNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdNivelIngles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidato__IdNiv__571DF1D5");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidato__IdUsu__5535A963");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.IdCidade)
                    .HasName("PK__Cidade__160879A3AD4513B1");

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Cidade)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Cidade__IdEstado__164452B1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__5EF4033E9D5B83C4");

                entity.HasIndex(e => e.Cnae)
                    .HasName("UQ__Empresa__AA5E6DE4D37F03B8")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Empresa__AA57D6B48967F57B")
                    .IsUnique();

                entity.Property(e => e.Cnae)
                    .IsRequired()
                    .HasColumnName("CNAE")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
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
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PorteEmpresa)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empresa__IdUsuar__60A75C0F");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__0B7C7F17021C94AC");

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

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Endereco__IdCida__4AB81AF0");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__FBB0EDC192608C26");

                entity.Property(e => e.NomeEstado)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estagio>(entity =>
            {
                entity.HasKey(e => e.IdEstagio)
                    .HasName("PK__Estagio__C70AD76C3433A315");

                entity.Property(e => e.DataFinal).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.HasOne(d => d.IdInscricaoNavigation)
                    .WithMany(p => p.Estagio)
                    .HasForeignKey(d => d.IdInscricao)
                    .HasConstraintName("FK__Estagio__IdInscr__6EF57B66");

                entity.HasOne(d => d.IdStatusEstagioNavigation)
                    .WithMany(p => p.Estagio)
                    .HasForeignKey(d => d.IdStatusEstagio)
                    .HasConstraintName("FK__Estagio__IdStatu__6FE99F9F");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F8349888CE10882");

                entity.Property(e => e.NomeGenero)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasKey(e => e.IdInscricao)
                    .HasName("PK__Inscrica__6209444B59BB4EA4");

                entity.Property(e => e.DataInscricao).HasColumnType("date");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdCandidato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inscricao__IdCan__6B24EA82");

                entity.HasOne(d => d.IdStatusInscricaoNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdStatusInscricao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inscricao__IdSta__6A30C649");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdVaga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inscricao__IdVag__693CA210");
            });

            modelBuilder.Entity<NivelEscolaridade>(entity =>
            {
                entity.HasKey(e => e.IdNivelEscolaridade)
                    .HasName("PK__NivelEsc__8D474527C0397928");

                entity.Property(e => e.Escolaridade)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NivelIngles>(entity =>
            {
                entity.HasKey(e => e.IdNivelIngles)
                    .HasName("PK__NivelIng__783B9E711EBA83D9");

                entity.Property(e => e.Ingles)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusEstagio>(entity =>
            {
                entity.HasKey(e => e.IdStatusEstagio)
                    .HasName("PK__StatusEs__A18FA5E7FC94DDB6");

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusInscricao>(entity =>
            {
                entity.HasKey(e => e.IdStatusInscricao)
                    .HasName("PK__StatusIn__4F419FD750A63F6B");

                entity.Property(e => e.NomeStatus)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062BEA9D0231");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoVaga>(entity =>
            {
                entity.HasKey(e => e.IdTipoVaga)
                    .HasName("PK__TipoVaga__763461BC307BF9EF");

                entity.Property(e => e.NomeTipoVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF9719EDA80F");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D10534EB21B8D2")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__IdEnder__4F7CD00D");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__IdTipoU__4E88ABD4");
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga)
                    .HasName("PK__Vaga__A848DC3E2C80802F");

                entity.Property(e => e.DataFinal).HasColumnType("datetime");

                entity.Property(e => e.DataInicio).HasColumnType("datetime");

                entity.Property(e => e.DescricaoAtividade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DescricaoRequisito)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeVaga)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vaga__IdEmpresa__6477ECF3");

                entity.HasOne(d => d.IdTipoVagaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdTipoVaga)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vaga__IdTipoVaga__656C112C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
