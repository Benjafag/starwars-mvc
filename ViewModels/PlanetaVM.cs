using StarWars;
using StarWars.Models;

namespace StarWars.ViewModels;
public class PlanetaIndexVM
{
  public PlanetaIndexVM() { }
  public PlanetaIndexVM(Planeta p)
  {
    IdPlaneta = p.IdPlaneta;
    Nombre = p.Nombre;
    SistemaEstelar = p.SistemaEstelar;
    Region = p.Region;
    Tipo = p.Tipo;
    Foto = p.Foto;
  }

  public int IdPlaneta { get; set; }
  public string Nombre { get; set; } = null!;
  public string SistemaEstelar { get; set; } = null!;
  public string Region { get; set; } = null!;
  public string Tipo { get; set; } = null!;
  public string? Foto { get; set; }
}


public class PlanetaDetallesVM
{
  private static StarWarsContext _context = new StarWarsContext(); 
  public PlanetaDetallesVM() { }
  public PlanetaDetallesVM(Planeta p)
  {
    IdPlaneta = p.IdPlaneta;
    Nombre = p.Nombre;
    SistemaEstelar = p.SistemaEstelar;
    Region = p.Region;
    Tipo = p.Tipo;
    Clima = p.Clima;
    Gravedad = p.Gravedad;
    PoblacionAproximada = p.PoblacionAproximada;
    Gobierno = p.Gobierno;
    Capital = p.Capital;
    Foto = p.Foto;

    if (p.Eventos is not null)
      Eventos = p.Eventos.Select(e => new EventoPlanetaVM
        {
          IdEvento = e.IdEvento,
          Titulo = e.Titulo,
          Fecha = e.Fecha,
          Imagen = e.Imagen
        }).ToList();

    if (p.Especies is not null)
      Especies = p.Especies.Select(e => new EspeciePlanetaVM
      {
        IdEspecie = e.IdEspecie,
        Nombre = e.Nombre,
      }).ToList();

    if (p.Personajes is not null)
      foreach (var personaje in p.Personajes)
      {
        Personajes.Add(new PersonajePlanetaVM
        {
          IdPersonaje = personaje.IdPersonaje,
          Nombre = personaje.Nombre,
          Foto = _context.Apariciones.Where(ap => ap.IdPersonaje == personaje.IdPersonaje).OrderBy(ap => ap.Edad).Last().Foto
        });
      }
  }

  public int IdPlaneta { get; set; }
  public string Nombre { get; set; } = null!;
  public string SistemaEstelar { get; set; } = null!;
  public string Region { get; set; } = null!;
  public string Tipo { get; set; } = null!;
  public string? Clima { get; set; }
  public double? Gravedad { get; set; }
  public long? PoblacionAproximada { get; set; }
  public string? Gobierno { get; set; }
  public string? Capital { get; set; }
  public string? Foto { get; set; }

  public List<EventoPlanetaVM> Eventos {get;set;} = new()!;
  public List<PersonajePlanetaVM> Personajes {get;set;} = new()!;
  public List<EspeciePlanetaVM> Especies {get;set;} = new();
}

public class EventoPlanetaVM
{
  public int IdEvento { get; set; }
  public string Titulo { get; set; } = null!;
  public string? Fecha { get; set; }
  public string? Imagen { get; set; }
}
public class PersonajePlanetaVM
{
  public int IdPersonaje { get; set; }
  public string Nombre { get; set; } = null!;
  public string Foto { get; set; } = null!;
}
public class EspeciePlanetaVM
{
  public int IdEspecie { get; set; }
  public string Nombre { get; set; } = null!;
}