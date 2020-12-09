using Microsoft.EntityFrameworkCore;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DAL.EF
{
    public class SolutionDBContext:DbContext
    {
        public SolutionDBContext(DbContextOptions<SolutionDBContext> options)
            : base(options)
        {

        }

        public SolutionDBContext()
        {
        }
        public DbSet<Calificaciones> Calificaciones { get; set; }
        public DbSet<Grados> Grados { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
        public DbSet<Instituciones> Instituciones { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TipoOperaciones> TipoOperaciones { get; set; }
        public DbSet<TipoPeriodo> TipoPeriodo { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuarioXGrupo> UsuarioXGrupo { get; set; }
        public DbSet<UsuarioXInstitucion> UsuarioXInstitucion { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-7DP82M34\\SQLEXPRESS;Database=ProyectoProgramacionWeb; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificaciones>(entity =>
            {
                entity.HasKey(e => new { e.IdGrupo, e.Cedula, e.IdTipoOperacion, e.IdMateria, e.IdPeriodo });

                entity.Property(e => e.Nota).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.Cedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_Cedula");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_IdGrupo");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_IdMateria");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_IdPeriodo");

                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.Calificaciones)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Calificaciones_IdTipoOperacion");
            });

            modelBuilder.Entity<Grados>(entity =>
            {
                entity.HasKey(e => e.IdGrado);

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.Grados)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grados_Instituciones");
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.IdGrupo);

                entity.HasOne(d => d.IdGradoNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdGrado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupos_Grados");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grupos_Instituciones");
            });

            modelBuilder.Entity<Instituciones>(entity =>
            {
                entity.HasKey(e => e.IdInstitucion);
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Materias_Instituciones");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoOperaciones>(entity =>
            {
                entity.HasKey(e => e.IdTipoOperacion);

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.TipoOperaciones)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoOperaciones_Instituciones");
            });

            modelBuilder.Entity<TipoPeriodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo);

                entity.ToTable("TipoPeriodo");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.TipoPeriodos)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipoPeriodo_Instituciones");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.Property(e => e.Cedula).ValueGeneratedNever();

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Roles");
            });

            modelBuilder.Entity<UsuarioXGrupo>(entity =>
            {
                entity.HasKey(e => new { e.IdGrupo, e.Cedula });

                entity.ToTable("Usuario_X_Grupo");

                entity.Property(e => e.IdUsuarioXgrupo).HasColumnName("IdUsuarioXGrupo");

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.UsuarioXGrupos)
                    .HasForeignKey(d => d.Cedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_X_Grupo_Usuario");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.UsuarioXGrupos)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_X_Grupo_IdGrupo");
            });

            modelBuilder.Entity<UsuarioXInstitucion>(entity =>
            {
                entity.HasKey(e => new { e.Cedula, e.IdInstitucion });

                entity.ToTable("Usuario_X_Institucion");

                entity.Property(e => e.IdUsuarioXInstitucion).HasColumnName("IdUsuarioXInstitucion");

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.UsuarioXInstitucions)
                    .HasForeignKey(d => d.Cedula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_X_Institucion_Usuario");

                entity.HasOne(d => d.IdInstitucionNavigation)
                    .WithMany(p => p.UsuarioXInstitucions)
                    .HasForeignKey(d => d.IdInstitucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_X_Institucion_Instituciones");
            });
        }

        }
}
