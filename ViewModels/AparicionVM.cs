using System;
using System.Collections.Generic;

namespace StarWars.Models;

public class AparicionVM
{
  public AparicionVM() {  }
  public AparicionVM(Aparicion ap)
  {
    Alias = ap.Alias;
    Rol = ap.Rol;
    Edad = ap.Edad;
    Rango = ap.Rango;
    Foto = ap.Foto;
    Altura = ap.Altura;
    Peso = ap.Peso;
    Estado = ap.Estado;
    Descripcion = ap.Descripcion;
    IdActor = ap.IdActor;
    IdFaccion = ap.IdFaccion;
    IdPersonaje = ap.IdPersonaje;
    IdPelicula = ap.IdPelicula;
    NombreActor = ap.IdActorNavigation?.Nombre + " " + ap.IdActorNavigation?.Apellido;
    FotoActor = ap.IdActorNavigation?.Foto;
    NombreFaccion = ap.IdFaccionNavigation?.Nombre ?? "";
    LogoFaccion = ap.IdFaccionNavigation?.Logo;
    TituloPelicula = ap.IdPeliculaNavigation?.Titulo ?? "";
    PosterPelicula = ap.IdPeliculaNavigation?.Poster;
    NombrePersonaje = ap.IdPersonajeNavigation?.Nombre ?? "";
  }
  public string? Rol { get; set; }
  public string? Alias { get; set; }
  public int Edad { get; set; } = 0;
  public string? Rango { get; set; }
  public string? Foto { get; set; }
  public int? Altura { get; set; } = 0;
  public double? Peso { get; set; } = 0;
  public string Estado { get; set; } = null!;
  public string Descripcion { get; set; } = null!;
  public int IdActor { get; set; } = 0;
  public int? IdFaccion { get; set; } = 0;
  public int IdPersonaje { get; set; } = 0;
  public int IdPelicula { get; set; } = 0;
  public string NombreActor  { get; set; } = null!;
  public string? FotoActor {get;set;}
  public string NombreFaccion  { get; set; } = null!;
  public string? LogoFaccion {get;set;}
  public string TituloPelicula  { get; set; } = null!;
  public string? PosterPelicula {get;set;}
  public string NombrePersonaje  { get; set; } = null!;
}
