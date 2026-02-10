using System;
using System.Collections.Generic;
using StarWars.Models;

namespace StarWars.ViewModels;

public class PersonajeIndexVM
{
  public PersonajeIndexVM() {}
  public PersonajeIndexVM(Personaje p)
  {
    IdPersonaje = p.IdPersonaje;
    Nombre = p.Nombre;
    Especie = p.IdEspecieNavigation.Nombre;
    PlanetaOrigen = p.IdPlanetaOrigenNavigation.Nombre;
    ImagenPlaneta = p.IdPlanetaOrigenNavigation.Foto ?? "/images/desconocido.webp";
    Foto = p.Apariciones.OrderBy(ap => ap.Edad).Last().Foto ?? "/images/placeholder.webp";
  }

  public int IdPersonaje { get; set; }
  public string Nombre { get; set; } = null!;
  public string Especie {get;set;} = null!;
  public string PlanetaOrigen {get;set;} = null!;
  public string ImagenPlaneta { get; set; } = null!;
  public string? Foto { get; set; }
}

public class PersonajeDetallesVM
{
  public PersonajeDetallesVM() { }
  public PersonajeDetallesVM(Personaje p)
  {
    IdPersonaje = p.IdPersonaje;
    Nombre = p.Nombre;
    Genero = p.Genero;
    SensibleALaFuerza = p.SensibleALaFuerza;
    Biografia = p.Biografia;
    IdEspecie = p.IdEspecie;
    Especie = p.IdEspecieNavigation?.Nombre ?? "Especie desconocida";
    IdPlanetaOrigen = p.IdPlanetaOrigen;
    PlanetaOrigen = p.IdPlanetaOrigenNavigation?.Nombre ?? "Origen desconocido"; // se rompe si el atributo no es nullable y la db devuelve un null; asi que lo controlo en el select
    Foto = p.Apariciones.ToList().OrderBy(ap => ap.Edad).Last().Foto ?? "";
    Apariciones = p.Apariciones.Select(ap => new PersonajeAparicionVM
    {
      Descripcion = ap.Descripcion,
      IdPelicula = ap.IdPelicula,
      NombrePelicula = ap.IdPeliculaNavigation.Titulo,
      Poster = ap.IdPeliculaNavigation.Poster,
      Foto = ap.Foto
    }).ToList();
  }

  public int IdPersonaje { get; set; }
  public string Nombre { get; set; } = null!;
  public string? Genero { get; set; }
  public bool SensibleALaFuerza { get; set; }
  public string Biografia { get; set; } = null!;
  public int IdEspecie { get; set; }
  public string Especie { get; set; } = null!;
  public int IdPlanetaOrigen { get; set; }
  public string PlanetaOrigen { get; set; } = null!;
  public string? Foto { get; set; }
  public List<PersonajeAparicionVM> Apariciones { get; set; } = [];

}


public class PersonajeAparicionVM
{
  public PersonajeAparicionVM() { }

  public string Descripcion { get; set; } = null!;
  public int IdPelicula { get; set; }
  public string NombrePelicula { get; set; } = null!;
  public string? Poster { get; set; } = null!;
  public string? Foto { get; set; }
}