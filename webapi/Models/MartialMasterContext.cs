using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class MartialMasterContext : DbContext
{
    public MartialMasterContext()
    {
    }

    public MartialMasterContext(DbContextOptions<MartialMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Juece> Jueces { get; set; }

    public virtual DbSet<Juecestorneo> Juecestorneos { get; set; }

    public virtual DbSet<Organizacione> Organizaciones { get; set; }

    public virtual DbSet<Participacion> Participacions { get; set; }

    public virtual DbSet<Peleadore> Peleadores { get; set; }

    public virtual DbSet<ResultadosPelea> ResultadosPeleas { get; set; }

    public virtual DbSet<Tiposuser> Tiposusers { get; set; }

    public virtual DbSet<Torneo> Torneos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\NMSQL;Database=MartialMaster;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Juece>(entity =>
        {
            entity.HasKey(e => e.IdJuez).HasName("PK__jueces__0FA80749E4FBEF0E");

            entity.ToTable("jueces");

            entity.Property(e => e.IdJuez)
                .ValueGeneratedNever()
                .HasColumnName("id_juez");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Edad)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Peleasj)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("peleasj");
        });

        modelBuilder.Entity<Juecestorneo>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__juecesto__C3F7F9668991FB86");

            entity.ToTable("juecestorneo");

            entity.Property(e => e.IdAsignacion)
                .ValueGeneratedNever()
                .HasColumnName("id_asignacion");
            entity.Property(e => e.IdJuez).HasColumnName("id_juez");
            entity.Property(e => e.IdTorneo).HasColumnName("id_torneo");

            entity.HasOne(d => d.IdJuezNavigation).WithMany(p => p.Juecestorneos)
                .HasForeignKey(d => d.IdJuez)
                .HasConstraintName("FK__juecestor__id_ju__47DBAE45");

            entity.HasOne(d => d.IdTorneoNavigation).WithMany(p => p.Juecestorneos)
                .HasForeignKey(d => d.IdTorneo)
                .HasConstraintName("FK__juecestor__id_to__46E78A0C");
        });

        modelBuilder.Entity<Organizacione>(entity =>
        {
            entity.HasKey(e => e.IdOrg).HasName("PK__organiza__6E0C5F09378F4CF4");

            entity.ToTable("organizaciones");

            entity.Property(e => e.IdOrg)
                .ValueGeneratedNever()
                .HasColumnName("id_org");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Participacion>(entity =>
        {
            entity.HasKey(e => e.IdParticipacion).HasName("PK__particip__E42D0FE07B367337");

            entity.ToTable("participacion");

            entity.Property(e => e.IdParticipacion)
                .ValueGeneratedNever()
                .HasColumnName("id_participacion");
            entity.Property(e => e.FechaDeRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_de_registro");
            entity.Property(e => e.IdPeleador).HasColumnName("id_peleador");
            entity.Property(e => e.IdTorneo).HasColumnName("id_torneo");

            entity.HasOne(d => d.IdPeleadorNavigation).WithMany(p => p.Participacions)
                .HasForeignKey(d => d.IdPeleador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__participa__id_pe__4BAC3F29");

            entity.HasOne(d => d.IdTorneoNavigation).WithMany(p => p.Participacions)
                .HasForeignKey(d => d.IdTorneo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__participa__id_to__4CA06362");
        });

        modelBuilder.Entity<Peleadore>(entity =>
        {
            entity.HasKey(e => e.IdPeleador).HasName("PK__peleador__163A82E94B32349C");

            entity.ToTable("peleadores");

            entity.Property(e => e.IdPeleador)
                .ValueGeneratedNever()
                .HasColumnName("id_peleador");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Cinturon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cinturon");
            entity.Property(e => e.Edad)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("edad");
            entity.Property(e => e.Estatura).HasColumnName("estatura");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Organizacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("organizacion");
            entity.Property(e => e.Peleasganadas).HasColumnName("peleasganadas");
            entity.Property(e => e.Peleasperdidas).HasColumnName("peleasperdidas");
        });

        modelBuilder.Entity<ResultadosPelea>(entity =>
        {
            entity.HasKey(e => e.IdResultado).HasName("PK__Resultad__33A42B30D78073C9");

            entity.Property(e => e.IdResultado)
                .ValueGeneratedNever()
                .HasColumnName("id_resultado");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.IdJuezGanador).HasColumnName("id_juez_ganador");
            entity.Property(e => e.IdJuezPerdedor).HasColumnName("id_juez_perdedor");
            entity.Property(e => e.IdParticipacion).HasColumnName("id_participacion");
            entity.Property(e => e.IdPelea).HasColumnName("id_pelea");
            entity.Property(e => e.IdTorneo).HasColumnName("id_torneo");
            entity.Property(e => e.Resultado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("resultado");

            entity.HasOne(d => d.IdJuezGanadorNavigation).WithMany(p => p.ResultadosPeleaIdJuezGanadorNavigations)
                .HasForeignKey(d => d.IdJuezGanador)
                .HasConstraintName("FK__Resultado__id_ju__49C3F6B7");

            entity.HasOne(d => d.IdJuezPerdedorNavigation).WithMany(p => p.ResultadosPeleaIdJuezPerdedorNavigations)
                .HasForeignKey(d => d.IdJuezPerdedor)
                .HasConstraintName("FK__Resultado__id_ju__4AB81AF0");

            entity.HasOne(d => d.IdParticipacionNavigation).WithMany(p => p.ResultadosPeleas)
                .HasForeignKey(d => d.IdParticipacion)
                .HasConstraintName("FK__Resultado__id_pa__5EBF139D");

            entity.HasOne(d => d.IdTorneoNavigation).WithMany(p => p.ResultadosPeleas)
                .HasForeignKey(d => d.IdTorneo)
                .HasConstraintName("FK__Resultado__id_to__48CFD27E");
        });

        modelBuilder.Entity<Tiposuser>(entity =>
        {
            entity.HasKey(e => e.IdTp).HasName("PK_tiposuser_1");

            entity.ToTable("tiposuser");

            entity.Property(e => e.IdTp).HasColumnName("id_tp");
            entity.Property(e => e.TipoDeUser)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Torneo>(entity =>
        {
            entity.HasKey(e => e.IdTorneo).HasName("PK__torneos__DBB62AF8E6DF09EF");

            entity.ToTable("torneos");

            entity.Property(e => e.IdTorneo)
                .ValueGeneratedNever()
                .HasColumnName("id_torneo");
            entity.Property(e => e.Categorias)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categorias");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Horario).HasColumnName("horario");
            entity.Property(e => e.IdOrg).HasColumnName("id_org");
            entity.Property(e => e.Nareas).HasColumnName("nareas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdOrgNavigation).WithMany(p => p.Torneos)
                .HasForeignKey(d => d.IdOrg)
                .HasConstraintName("FK__torneos__id_org__5DCAEF64");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__usuarios__D2D146376D075D6A");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.TipoDeUserNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoDeUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tipodeuser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
