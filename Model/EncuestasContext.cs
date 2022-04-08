using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EncuestasApi.Model
{
    public partial class EncuestasContext : DbContext
    {
        public EncuestasContext()
        {
        }

        public EncuestasContext(DbContextOptions<EncuestasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campoencuestum> Campoencuesta { get; set; }
        public virtual DbSet<Encuestum> Encuesta { get; set; }
        public virtual DbSet<Respuesta> Respuestas { get; set; }
        public virtual DbSet<Respuestaencuestum> Respuestaencuesta { get; set; }
        public virtual DbSet<Tipodecampo> Tipodecampos { get; set; }
        public virtual DbSet<Usersapp> Usersapps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=database-1.cswzkawsfdts.us-east-1.rds.amazonaws.com;Database=Encuestas;user=admin;password=eWWx7aZZPHFvWyU;Trusted_Connection=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Campoencuestum>(entity =>
            {
                entity.HasKey(e => e.CampoId)
                    .HasName("PK__CAMPOENC__298250769836A65B");

                entity.ToTable("CAMPOENCUESTA");

                entity.Property(e => e.CampoId).HasColumnName("CampoID");

                entity.Property(e => e.NombreCampo)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Requerido).HasDefaultValueSql("((0))");

                entity.Property(e => e.TítuloCampo)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.EncuestaNavigation)
                    .WithMany(p => p.Campoencuesta)
                    .HasForeignKey(d => d.Encuesta)
                    .HasConstraintName("FK__CAMPOENCU__Encue__3F466844");

                entity.HasOne(d => d.TipoCampoNavigation)
                    .WithMany(p => p.Campoencuesta)
                    .HasForeignKey(d => d.TipoCampo)
                    .HasConstraintName("FK__CAMPOENCU__TipoC__3E52440B");
            });

            modelBuilder.Entity<Encuestum>(entity =>
            {
                entity.HasKey(e => e.EncuestaId)
                    .HasName("PK__ENCUESTA__82FD78C8944E3D9B");

                entity.ToTable("ENCUESTA");

                entity.Property(e => e.EncuestaId).HasColumnName("EncuestaID");

                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Habilitada).HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreEncuesta)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Respuesta>(entity =>
            {
                entity.HasKey(e => e.RespuestaCampo)
                    .HasName("PK__RESPUEST__F89167A410746FB9");

                entity.ToTable("RESPUESTAS");

                entity.Property(e => e.Respuesta1)
                    .HasColumnType("text")
                    .HasColumnName("respuesta");

                entity.Property(e => e.RespuestaEncuesta).HasColumnName("respuestaEncuesta");

                entity.HasOne(d => d.CampoNavigation)
                    .WithMany(p => p.Respuesta)
                    .HasForeignKey(d => d.Campo)
                    .HasConstraintName("FK__RESPUESTA__Campo__44FF419A");

                entity.HasOne(d => d.RespuestaEncuestaNavigation)
                    .WithMany(p => p.Respuesta)
                    .HasForeignKey(d => d.RespuestaEncuesta)
                    .HasConstraintName("FK__RESPUESTA__respu__45F365D3");
            });

            modelBuilder.Entity<Respuestaencuestum>(entity =>
            {
                entity.HasKey(e => e.RespuestaId)
                    .HasName("PK__RESPUEST__31F7FC31C6A75DCD");

                entity.ToTable("RESPUESTAENCUESTA");

                entity.Property(e => e.RespuestaId).HasColumnName("RespuestaID");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.EncuestaNavigation)
                    .WithMany(p => p.Respuestaencuesta)
                    .HasForeignKey(d => d.Encuesta)
                    .HasConstraintName("FK__RESPUESTA__Fecha__4222D4EF");
            });

            modelBuilder.Entity<Tipodecampo>(entity =>
            {
                entity.HasKey(e => e.TipoId)
                    .HasName("PK__TIPODECA__97099E97DFFBB256");

                entity.ToTable("TIPODECAMPO");

                entity.Property(e => e.TipoId).HasColumnName("TipoID");

                entity.Property(e => e.NombreTipo)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usersapp>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__USERSAPP__1788CCAC5B36E8F8");

                entity.ToTable("USERSAPP");

                entity.HasIndex(e => e.Correo, "uc_correo")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("contrasena");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
