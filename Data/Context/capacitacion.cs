using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class capacitacion : DbContext
    {
        public capacitacion()
        {
        }

        public capacitacion(DbContextOptions<capacitacion> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }
        public virtual DbSet<Puntajes> Puntajes { get; set; }
        public virtual DbSet<Reparticiones> Reparticiones { get; set; }
        public virtual DbSet<Temas> Temas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=167.172.2.95)(PORT=1522)))(CONNECT_DATA=(SID=ORCLCDB)));User Id=capacitacion;Password=capacitacion;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:DefaultSchema", "CAPACITACION");

            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("ALUMNOS_PK");

                entity.ToTable("ALUMNOS");

                entity.HasIndex(e => e.IdAlumno)
                    .HasName("ALUMNOS_PK")
                    .IsUnique();

                entity.Property(e => e.IdAlumno)
                    .HasColumnName("ID_ALUMNO")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdPersona)
                    .HasColumnName("ID_PERSONA")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.IdReparticion)
                    .HasColumnName("ID_REPARTICION")
                    .HasColumnType("NUMBER");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("ALUMNOS_FK2");

                entity.HasOne(d => d.IdReparticionNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdReparticion)
                    .HasConstraintName("ALUMNOS_FK1");
            });

            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("CARGOS_PK");

                entity.ToTable("CARGOS");

                entity.HasIndex(e => e.IdCargo)
                    .HasName("CARGOS_PK")
                    .IsUnique();

                entity.Property(e => e.IdCargo)
                    .HasColumnName("ID_CARGO")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(200)");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PERSONAS_PK");

                entity.ToTable("PERSONAS");

                entity.HasIndex(e => e.IdPersona)
                    .HasName("PERSONAS_PK")
                    .IsUnique();

                entity.Property(e => e.IdPersona)
                    .HasColumnName("ID_PERSONA")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Apellido)
                    .HasColumnName("APELLIDO")
                    .HasColumnType("VARCHAR2(200)");

                entity.Property(e => e.Cuil)
                    .IsRequired()
                    .HasColumnName("CUIL")
                    .HasColumnType("VARCHAR2(200)");

                entity.Property(e => e.Edad)
                    .HasColumnName("EDAD")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(200)");
            });

            modelBuilder.Entity<Profesores>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PROFESORES_PK");

                entity.ToTable("PROFESORES");

                entity.HasIndex(e => e.IdProfesor)
                    .HasName("PROFESORES_PK")
                    .IsUnique();

                entity.Property(e => e.IdProfesor)
                    .HasColumnName("ID_PROFESOR")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.IdCargo)
                    .HasColumnName("ID_CARGO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.IdPersona)
                    .HasColumnName("ID_PERSONA")
                    .HasColumnType("NUMBER");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("PROFESORES_FK2");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("PROFESORES_FK1");
            });

            modelBuilder.Entity<Puntajes>(entity =>
            {
                entity.HasKey(e => new { e.IdPuntaje, e.IdTema, e.IdProfesor, e.IdAlumno })
                    .HasName("PUNTAJES_PK");

                entity.ToTable("PUNTAJES");

                entity.HasIndex(e => new { e.IdPuntaje, e.IdTema, e.IdProfesor, e.IdAlumno })
                    .HasName("PUNTAJES_PK")
                    .IsUnique();

                entity.Property(e => e.IdPuntaje)
                    .HasColumnName("ID_PUNTAJE")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdTema)
                    .HasColumnName("ID_TEMA")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.IdProfesor)
                    .HasColumnName("ID_PROFESOR")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.IdAlumno)
                    .HasColumnName("ID_ALUMNO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Complejidad)
                    .HasColumnName("COMPLEJIDAD")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Entendimiento)
                    .HasColumnName("ENTENDIMIENTO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Interes)
                    .HasColumnName("INTERES")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("OBSERVACIONES")
                    .HasColumnType("VARCHAR2(500)");

                entity.Property(e => e.Valoracion)
                    .HasColumnName("VALORACION")
                    .HasColumnType("NUMBER");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Puntajes)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PUNTAJES_FK1");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Puntajes)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PUNTAJES_FK2");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Puntajes)
                    .HasForeignKey(d => d.IdTema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PUNTAJES_FK3");
            });

            modelBuilder.Entity<Reparticiones>(entity =>
            {
                entity.HasKey(e => e.IdReparticion)
                    .HasName("REPARTICIONES_PK");

                entity.ToTable("REPARTICIONES");

                entity.HasIndex(e => e.IdReparticion)
                    .HasName("REPARTICIONES_PK")
                    .IsUnique();

                entity.Property(e => e.IdReparticion)
                    .HasColumnName("ID_REPARTICION")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(200)");
            });

            modelBuilder.Entity<Temas>(entity =>
            {
                entity.HasKey(e => e.IdTema)
                    .HasName("TEMAS_PK");

                entity.ToTable("TEMAS");

                entity.HasIndex(e => e.IdTema)
                    .HasName("TEMAS_PK")
                    .IsUnique();

                entity.Property(e => e.IdTema)
                    .HasColumnName("ID_TEMA")
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasColumnType("VARCHAR2(200)");

                entity.Property(e => e.Duracion)
                    .HasColumnName("DURACION")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasColumnType("VARCHAR2(200)");
            });

            modelBuilder.HasSequence("ISEQ$$_79883");

            modelBuilder.HasSequence("ISEQ$$_79886");

            modelBuilder.HasSequence("ISEQ$$_79889");

            modelBuilder.HasSequence("ISEQ$$_79892");

            modelBuilder.HasSequence("ISEQ$$_79903");

            modelBuilder.HasSequence("ISEQ$$_79907");
        }
    }
}
