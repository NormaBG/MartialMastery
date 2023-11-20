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

    public virtual DbSet<Artemarcial> Artemarcials { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cinturone> Cinturones { get; set; }

    public virtual DbSet<Competicione> Competiciones { get; set; }

    public virtual DbSet<Juece> Jueces { get; set; }

    public virtual DbSet<Juecestorneo> Juecestorneos { get; set; }

    public virtual DbSet<Organizacione> Organizaciones { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<Participantesartesmarciale> Participantesartesmarciales { get; set; }

    public virtual DbSet<Peleadore> Peleadores { get; set; }

    public virtual DbSet<ResultadosPelea> ResultadosPeleas { get; set; }

    public virtual DbSet<Tiposdeusuario> Tiposdeusuarios { get; set; }

    public virtual DbSet<Torneo> Torneos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\NMSQL;Database=MartialMaster;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artemarcial>(entity =>
        {
            entity.HasKey(e => e.IdArtemarcial).HasName("PK__artemarc__2F66BB0E22BEBC64");

            entity.ToTable("artemarcial");

            entity.Property(e => e.IdArtemarcial).HasColumnName("id_artemarcial");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__categori__CD54BC5A635BCDDE");

            entity.ToTable("categorias");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasMany(d => d.IdArteMarcials).WithMany(p => p.IdCategoria)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoriasArtesMarciale",
                    r => r.HasOne<Artemarcial>().WithMany()
                        .HasForeignKey("IdArteMarcial")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__categoria__id_ar__2EA5EC27"),
                    l => l.HasOne<Categoria>().WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__categoria__id_ca__2DB1C7EE"),
                    j =>
                    {
                        j.HasKey("IdCategoria", "IdArteMarcial").HasName("PK__categori__0CD4E2EC1D3FE69A");
                        j.ToTable("categorias_artes_marciales");
                        j.IndexerProperty<int>("IdCategoria").HasColumnName("id_categoria");
                        j.IndexerProperty<int>("IdArteMarcial").HasColumnName("id_arte_marcial");
                    });
        });

        modelBuilder.Entity<Cinturone>(entity =>
        {
            entity.HasKey(e => e.IdCinturon).HasName("PK__cinturon__C0FD7F1CAC34F1D7");

            entity.ToTable("cinturones");

            entity.Property(e => e.IdCinturon).HasColumnName("id_cinturon");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.IdArtemarcial).HasColumnName("id_artemarcial");

            entity.HasOne(d => d.IdArtemarcialNavigation).WithMany(p => p.Cinturones)
                .HasForeignKey(d => d.IdArtemarcial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cinturones_artemarcial");
        });

        modelBuilder.Entity<Competicione>(entity =>
        {
            entity.HasKey(e => e.IdCompetencia).HasName("PK__COMPETIC__6803894C6666308A");

            entity.ToTable("COMPETICIONES");

            entity.Property(e => e.IdCompetencia).HasColumnName("id_competencia");
            entity.Property(e => e.IdArtemarcial).HasColumnName("id_artemarcial");
            entity.Property(e => e.IdTorneo).HasColumnName("id_torneo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Juece>(entity =>
        {
            entity.HasKey(e => e.IdJuez).HasName("PK__jueces__0FA80749E4FBEF0E");

            entity.ToTable("jueces");

            entity.Property(e => e.IdJuez).HasColumnName("id_juez");
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

            entity.Property(e => e.IdOrg).HasColumnName("id_org");
            entity.Property(e => e.Artemarcial)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("artemarcial");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PK__particip__A88054DCBA9D5055");

            entity.ToTable("participantes");

            entity.Property(e => e.IdParticipante).HasColumnName("id_participante");
            entity.Property(e => e.IdCompetencia).HasColumnName("id_competencia");
            entity.Property(e => e.Nombreparticipante)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombreparticipante");

            entity.HasOne(d => d.IdCompetenciaNavigation).WithMany(p => p.Participantes)
                .HasForeignKey(d => d.IdCompetencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__participa__id_co__52E34C9D");
        });

        modelBuilder.Entity<Participantesartesmarciale>(entity =>
        {
            entity.HasKey(e => e.IdParticipanteartemaricial).HasName("PK__particip__8316E8BE94636E7D");

            entity.ToTable("participantesartesmarciales");

            entity.Property(e => e.IdParticipanteartemaricial).HasColumnName("id_participanteartemaricial");
            entity.Property(e => e.IdArtemarcial).HasColumnName("id_artemarcial");
            entity.Property(e => e.IdCinturon).HasColumnName("id_cinturon");
            entity.Property(e => e.IdParticipante).HasColumnName("id_participante");

            entity.HasOne(d => d.IdArtemarcialNavigation).WithMany(p => p.Participantesartesmarciales)
                .HasForeignKey(d => d.IdArtemarcial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__participa__id_ar__56B3DD81");

            entity.HasOne(d => d.IdCinturonNavigation).WithMany(p => p.Participantesartesmarciales)
                .HasForeignKey(d => d.IdCinturon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__participa__id_ci__57A801BA");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.Participantesartesmarciales)
                .HasForeignKey(d => d.IdParticipante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__participa__id_pa__55BFB948");
        });

        modelBuilder.Entity<Peleadore>(entity =>
        {
            entity.HasKey(e => e.IdPeleador).HasName("PK__peleador__163A82E94B32349C");

            entity.ToTable("peleadores");

            entity.Property(e => e.IdPeleador).HasColumnName("id_peleador");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Artemarcial).HasColumnName("artemarcial");
            entity.Property(e => e.Cinturon).HasColumnName("cinturon");
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
            entity.Property(e => e.Peso).HasColumnName("peso");

            entity.HasOne(d => d.ArtemarcialNavigation).WithMany(p => p.Peleadores)
                .HasForeignKey(d => d.Artemarcial)
                .HasConstraintName("FK_peleadores_artemarcial");

            entity.HasOne(d => d.CinturonNavigation).WithMany(p => p.Peleadores)
                .HasForeignKey(d => d.Cinturon)
                .HasConstraintName("FK_peleadores_cinturon");
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

            entity.HasOne(d => d.IdTorneoNavigation).WithMany(p => p.ResultadosPeleas)
                .HasForeignKey(d => d.IdTorneo)
                .HasConstraintName("FK__Resultado__id_to__48CFD27E");
        });

        modelBuilder.Entity<Tiposdeusuario>(entity =>
        {
            entity.HasKey(e => e.IdTp);

            entity.ToTable("tiposdeusuario");

            entity.Property(e => e.IdTp)
                .ValueGeneratedNever()
                .HasColumnName("id_tp");
            entity.Property(e => e.NombreDelTipo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Torneo>(entity =>
        {
            entity.HasKey(e => e.IdTorneo).HasName("PK__torneos__DBB62AF8E6DF09EF");

            entity.ToTable("torneos");

            entity.Property(e => e.IdTorneo)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_torneo");
            entity.Property(e => e.Categorias).HasColumnName("categorias");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FehcaFin)
                .HasColumnType("date")
                .HasColumnName("fehca_fin");
            entity.Property(e => e.Horario)
                .HasColumnType("datetime")
                .HasColumnName("horario");
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

            entity.HasOne(d => d.IdTorneoNavigation).WithOne(p => p.Torneo)
                .HasForeignKey<Torneo>(d => d.IdTorneo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_torneos_categoria");

            entity.HasMany(d => d.IdArtemarcials).WithMany(p => p.IdTorneos)
                .UsingEntity<Dictionary<string, object>>(
                    "TorneoArtesMarciale",
                    r => r.HasOne<Artemarcial>().WithMany()
                        .HasForeignKey("IdArtemarcial")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TorneoArt__id_ar__65F62111"),
                    l => l.HasOne<Torneo>().WithMany()
                        .HasForeignKey("IdTorneo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TorneoArt__id_to__6501FCD8"),
                    j =>
                    {
                        j.HasKey("IdTorneo", "IdArtemarcial").HasName("PK__TorneoAr__29404148EA7EE7F6");
                        j.ToTable("TorneoArtesMarciales");
                        j.IndexerProperty<int>("IdTorneo").HasColumnName("id_torneo");
                        j.IndexerProperty<int>("IdArtemarcial").HasColumnName("id_artemarcial");
                    });

            entity.HasMany(d => d.IdCategoria).WithMany(p => p.IdTorneos)
                .UsingEntity<Dictionary<string, object>>(
                    "TorneosCategoria",
                    r => r.HasOne<Categoria>().WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__torneos_c__id_ca__24285DB4"),
                    l => l.HasOne<Torneo>().WithMany()
                        .HasForeignKey("IdTorneo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__torneos_c__id_to__2334397B"),
                    j =>
                    {
                        j.HasKey("IdTorneo", "IdCategoria").HasName("PK__torneos___6763613D09849D52");
                        j.ToTable("torneos_categorias");
                        j.IndexerProperty<int>("IdTorneo").HasColumnName("id_torneo");
                        j.IndexerProperty<int>("IdCategoria").HasColumnName("id_categoria");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.TipoDeUserNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoDeUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuarios_tiposdeusuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
