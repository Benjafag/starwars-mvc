using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using StarWars.Models;

namespace StarWars;

public partial class StarWarsContext : DbContext
{
  public StarWarsContext() { }
  public StarWarsContext(DbContextOptions<StarWarsContext> options)
      : base(options)
  {
  }

  public virtual DbSet<Actor>? Actores { get; set; }

  public virtual DbSet<Aparicion>? Apariciones { get; set; }

  public virtual DbSet<Especie>? Especies { get; set; }

  public virtual DbSet<Evento>? Eventos { get; set; }

  public virtual DbSet<Faccion>? Facciones { get; set; }

  public virtual DbSet<Nave>? Naves { get; set; }

  public virtual DbSet<Pelicula>? Peliculas { get; set; }

  public virtual DbSet<Personaje>? Personajes { get; set; }

  public virtual DbSet<Planeta>? Planetas { get; set; }
  public virtual DbSet<BusquedaItem>? Uniones { get; set; } = null!;

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      // To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
      => optionsBuilder.UseMySql("server=localhost;port=3306;database=starwars;uid=root;password=123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.43-mysql"));

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
        .UseCollation("utf8mb4_0900_ai_ci")
        .HasCharSet("utf8mb4");

    modelBuilder.Entity<Actor>(entity =>
    {
      entity.HasKey(e => e.IdActor).HasName("PRIMARY");

      entity.ToTable("actores");

      entity.Property(e => e.IdActor).HasColumnName("id_actor");
      entity.Property(e => e.Apellido)
              .HasMaxLength(25)
              .HasColumnName("apellido");
      entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
      entity.Property(e => e.Foto)
              .HasMaxLength(100)
              .HasColumnName("foto");
      entity.Property(e => e.Genero)
              .HasColumnType("enum('Masculino','Femenino','No binario','No especificado')")
              .HasColumnName("genero");
      entity.Property(e => e.Nacionalidad)
              .HasMaxLength(25)
              .HasColumnName("nacionalidad");
      entity.Property(e => e.Nombre)
              .HasMaxLength(25)
              .HasColumnName("nombre");
    });
modelBuilder.Entity<Aparicion>(entity =>
{
    // PK compuesta
    entity.HasKey(e => new { e.IdPersonaje, e.IdPelicula })
          .HasName("PRIMARY");

    entity.ToTable("apariciones");

    entity.HasIndex(e => e.IdActor, "id_actor");
    entity.HasIndex(e => e.IdFaccion, "id_faccion");
    entity.HasIndex(e => e.IdPelicula, "id_pelicula");
    // ya NO hace falta el unique sobre (IdPersonaje, IdPelicula),
    // porque la PK ya lo garantiza.

    entity.Property(e => e.Alias)
          .HasMaxLength(25)
          .HasColumnName("alias");

    entity.Property(e => e.Altura).HasColumnName("altura");

    entity.Property(e => e.Descripcion)
          .HasMaxLength(150)
          .HasColumnName("descripcion");

    entity.Property(e => e.Edad).HasColumnName("edad");

    entity.Property(e => e.Estado)
          .HasColumnType("enum('Vivo','Muerto','Desconocido')")
          .HasColumnName("estado");

    // si "foto" ahora es URL, esto está bien:
    entity.Property(e => e.Foto)
          .HasMaxLength(100)
          .HasColumnName("foto");

    entity.Property(e => e.IdActor).HasColumnName("id_actor");
    entity.Property(e => e.IdFaccion).HasColumnName("id_faccion");

    // parte de la PK compuesta:
    entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
    entity.Property(e => e.IdPersonaje).HasColumnName("id_personaje");

    entity.Property(e => e.Peso).HasColumnName("peso");

    entity.Property(e => e.Rango)
          .HasColumnType("enum('Padawan','Jedi','Sith','Senador','Gobernador','General','Comandante','Soldado','Sargento')")
          .HasColumnName("rango");

    entity.Property(e => e.Rol)
          .HasColumnType("enum('Protagonista','Secundario','Cameo')")
          .HasColumnName("rol");

    entity.HasOne(d => d.IdActorNavigation)
          .WithMany(p => p.Apariciones)
          .HasForeignKey(d => d.IdActor)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("apariciones_ibfk_1");

    entity.HasOne(d => d.IdFaccionNavigation)
          .WithMany(p => p.Apariciones)
          .HasForeignKey(d => d.IdFaccion)
          .HasConstraintName("apariciones_ibfk_2");

    entity.HasOne(d => d.IdPeliculaNavigation)
          .WithMany(p => p.Apariciones)
          .HasForeignKey(d => d.IdPelicula)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("apariciones_ibfk_4");

    entity.HasOne(d => d.IdPersonajeNavigation)
          .WithMany(p => p.Apariciones)
          .HasForeignKey(d => d.IdPersonaje)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("apariciones_ibfk_3");
});


    modelBuilder.Entity<Especie>(entity =>
    {
      entity.HasKey(e => e.IdEspecie).HasName("PRIMARY");

      entity.ToTable("especies");

      entity.HasIndex(e => e.IdPlanetaOrigen, "id_planeta_origen");

      entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

      entity.Property(e => e.IdEspecie).HasColumnName("id_especie");
      entity.Property(e => e.AlturaPromedio).HasColumnName("altura_promedio");
      entity.Property(e => e.EsperanzaDeVida).HasColumnName("esperanza_de_vida");
      entity.Property(e => e.Habilidades)
              .HasMaxLength(100)
              .HasColumnName("habilidades");
      entity.Property(e => e.IdPlanetaOrigen).HasColumnName("id_planeta_origen");
      entity.Property(e => e.Idioma)
              .HasMaxLength(20)
              .HasColumnName("idioma");
      entity.Property(e => e.Nombre)
              .HasMaxLength(50)
              .HasColumnName("nombre");

      entity.HasOne(d => d.IdPlanetaOrigenNavigation).WithMany(p => p.Especies)
              .HasForeignKey(d => d.IdPlanetaOrigen)
              .HasConstraintName("especies_ibfk_1");
    });

    modelBuilder.Entity<Evento>(entity =>
    {
      entity.HasKey(e => e.IdEvento).HasName("PRIMARY");

      entity.ToTable("eventos");

      entity.HasIndex(e => e.IdPelicula, "id_pelicula");

      entity.HasIndex(e => e.IdPlaneta, "id_planeta");

      entity.Property(e => e.IdEvento).HasColumnName("id_evento");
      entity.Property(e => e.Descripcion)
              .HasColumnType("text")
              .HasColumnName("descripcion");
      entity.Property(e => e.Fecha)
              .HasMaxLength(10)
              .HasColumnName("fecha");
      entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
      entity.Property(e => e.IdPlaneta).HasColumnName("id_planeta");
      entity.Property(e => e.Imagen)
              .HasMaxLength(100)
              .HasColumnName("imagen");
      entity.Property(e => e.Resultado)
              .HasMaxLength(50)
              .HasColumnName("resultado");
      entity.Property(e => e.Titulo)
              .HasMaxLength(20)
              .HasColumnName("titulo");

      entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Eventos)
              .HasForeignKey(d => d.IdPelicula)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("eventos_ibfk_2");

      entity.HasOne(d => d.IdPlanetaNavigation).WithMany(p => p.Eventos)
              .HasForeignKey(d => d.IdPlaneta)
              .HasConstraintName("eventos_ibfk_1");
    });

    modelBuilder.Entity<Faccion>(entity =>
    {
      entity.HasKey(e => e.IdFaccion).HasName("PRIMARY");

      entity.ToTable("facciones");

      entity.HasIndex(e => e.IdLider, "id_lider");

      entity.Property(e => e.IdFaccion).HasColumnName("id_faccion");
      entity.Property(e => e.IdLider).HasColumnName("id_lider");
      entity.Property(e => e.Logo)
              .HasMaxLength(100)
              .HasColumnName("logo");
      entity.Property(e => e.Nombre)
              .HasMaxLength(25)
              .HasColumnName("nombre");
      entity.Property(e => e.PeriodoExistencia)
              .HasMaxLength(20)
              .HasColumnName("periodo_existencia");
      entity.Property(e => e.Tipo)
              .HasColumnType("enum('Religiosa','Politica','Militar')")
              .HasColumnName("tipo");

      entity.HasOne(d => d.IdLiderNavigation).WithMany(p => p.Facciones)
              .HasForeignKey(d => d.IdLider)
              .HasConstraintName("facciones_ibfk_1");
    });

    modelBuilder.Entity<Nave>(entity =>
    {
      entity.HasKey(e => e.IdNave).HasName("PRIMARY");

      entity.ToTable("naves");

      entity.HasIndex(e => e.IdDuenio, "id_duenio");

      entity.HasIndex(e => e.IdPrimerPelicula, "id_primer_pelicula");

      entity.Property(e => e.IdNave).HasColumnName("id_nave");
      entity.Property(e => e.Fabricante)
              .HasMaxLength(20)
              .HasColumnName("fabricante");
      entity.Property(e => e.Foto)
              .HasMaxLength(100)
              .HasColumnName("foto");
      entity.Property(e => e.IdDuenio).HasColumnName("id_duenio");
      entity.Property(e => e.IdPrimerPelicula).HasColumnName("id_primer_pelicula");
      entity.Property(e => e.Modelo)
              .HasMaxLength(25)
              .HasColumnName("modelo");
      entity.Property(e => e.Nombre)
              .HasMaxLength(25)
              .HasColumnName("nombre");
      entity.Property(e => e.Tipo)
              .HasColumnType("enum('Caza estelar','Bombardero','Carguero','Transporte','Nave capital','Transbordador','Fragata','Corbeta')")
              .HasColumnName("tipo");
      entity.Property(e => e.VelocidadMaxima).HasColumnName("velocidad_maxima");

      entity.HasOne(d => d.IdDuenioNavigation).WithMany(p => p.Naves)
              .HasForeignKey(d => d.IdDuenio)
              .HasConstraintName("naves_ibfk_1");

      entity.HasOne(d => d.IdPrimerPeliculaNavigation).WithMany(p => p.Naves)
              .HasForeignKey(d => d.IdPrimerPelicula)
              .HasConstraintName("naves_ibfk_2");
    });

    modelBuilder.Entity<Pelicula>(entity =>
    {
      entity.HasKey(e => e.IdPelicula).HasName("PRIMARY");

      entity.ToTable("peliculas");

      entity.HasIndex(e => e.Episodio, "episodio").IsUnique();

      entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
      entity.Property(e => e.Anio)
              .HasMaxLength(10)
              .HasColumnName("anio");
      entity.Property(e => e.AnioEstreno).HasColumnName("anio_estreno");
      entity.Property(e => e.Duracion).HasColumnName("duracion");
      entity.Property(e => e.Episodio).HasColumnName("episodio");
      entity.Property(e => e.Poster)
              .HasMaxLength(100)
              .HasColumnName("poster");
      entity.Property(e => e.Presupuesto).HasColumnName("presupuesto");
      entity.Property(e => e.Recaudado).HasColumnName("recaudado");
      entity.Property(e => e.Sinopsis)
              .HasColumnType("text")
              .HasColumnName("sinopsis");
      entity.Property(e => e.Titulo)
              .HasMaxLength(50)
              .HasColumnName("titulo");
    });

    modelBuilder.Entity<Personaje>(entity =>
    {
      entity.HasKey(e => e.IdPersonaje).HasName("PRIMARY");

      entity.ToTable("personajes");

      entity.HasIndex(e => e.IdEspecie, "id_especie");

      entity.HasIndex(e => e.IdPlanetaOrigen, "id_planeta_origen");

      entity.Property(e => e.IdPersonaje).HasColumnName("id_personaje");
      entity.Property(e => e.Biografia)
              .HasMaxLength(150)
              .HasColumnName("biografia");
      entity.Property(e => e.Genero)
              .HasMaxLength(20)
              .HasColumnName("genero");
      entity.Property(e => e.IdEspecie).HasColumnName("id_especie");
      entity.Property(e => e.IdPlanetaOrigen).HasColumnName("id_planeta_origen");
      entity.Property(e => e.Nombre)
              .HasMaxLength(50)
              .HasColumnName("nombre");
      entity.Property(e => e.SensibleALaFuerza).HasColumnName("sensible_a_la_fuerza");

      entity.HasOne(d => d.IdEspecieNavigation).WithMany(p => p.Personajes)
              .HasForeignKey(d => d.IdEspecie)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("personajes_ibfk_1");

      entity.HasOne(d => d.IdPlanetaOrigenNavigation).WithMany(p => p.Personajes)
              .HasForeignKey(d => d.IdPlanetaOrigen)
              .OnDelete(DeleteBehavior.ClientSetNull)
              .HasConstraintName("personajes_ibfk_2");
    });

    modelBuilder.Entity<Planeta>(entity =>
    {
      entity.HasKey(e => e.IdPlaneta).HasName("PRIMARY");

      entity.ToTable("planetas");

      entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

      entity.Property(e => e.IdPlaneta).HasColumnName("id_planeta");
      entity.Property(e => e.Capital)
              .HasMaxLength(50)
              .HasColumnName("capital");
      entity.Property(e => e.Clima)
              .HasMaxLength(50)
              .HasColumnName("clima");
      entity.Property(e => e.Foto)
              .HasMaxLength(100)
              .HasColumnName("foto");
      entity.Property(e => e.Gobierno)
              .HasMaxLength(20)
              .HasColumnName("gobierno");
      entity.Property(e => e.Gravedad).HasColumnName("gravedad");
      entity.Property(e => e.Nombre)
              .HasMaxLength(25)
              .HasColumnName("nombre");
      entity.Property(e => e.PoblacionAproximada).HasColumnName("poblacion_aproximada");
      entity.Property(e => e.Region)
              .HasColumnType("enum('Nucleo','Borde Medio','Borde Exterior','Region Desconocida')")
              .HasColumnName("region");
      entity.Property(e => e.SistemaEstelar)
              .HasMaxLength(50)
              .HasColumnName("sistema_estelar");
      entity.Property(e => e.Tipo)
              .HasColumnType("enum('Desertico','Helado','Ciudad','Acuatico','Volcánico','Selvático','Pantanoso','Capital','Desconocido')")
              .HasColumnName("tipo");
    });

    OnModelCreatingPartial(modelBuilder);

    modelBuilder.Entity<BusquedaItem>(entity =>
    {
      entity.HasNoKey();           // sigue siendo VIEW sin clave
      entity.ToView("uniones");

      entity.Property(e => e.Id).HasColumnName("id");
      entity.Property(e => e.Nombre).HasColumnName("nombre");
      entity.Property(e => e.Foto).HasColumnName("foto");
      entity.Property(e => e.Categoria).HasColumnName("categoria");
    });


  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
