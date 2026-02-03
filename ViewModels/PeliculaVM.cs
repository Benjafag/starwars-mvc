using StarWars.Models;

namespace StarWars.ViewModels;

public class PeliculaIndexVM
{
  public PeliculaIndexVM() { }
  public PeliculaIndexVM(Pelicula p)
  {
    IdPelicula = p.IdPelicula;
    Episodio = p.Episodio;
    Titulo = p.Titulo;
    Anio = p.Anio;
    Poster = p.Poster;
  }

  public int IdPelicula { get; set; }
  public int Episodio { get; set; }
  public string Titulo { get; set; } = null!;
  public string? Anio { get; set; }
  public string? Poster { get; set; } = null!;
}

public class PeliculaDetallesVM
{
  public PeliculaDetallesVM() { }
  public PeliculaDetallesVM(Pelicula p)
  {
    IdPelicula = p.IdPelicula;
    Episodio = p.Episodio;
    Titulo = p.Titulo;
    Anio = p.Anio;
    AnioEstreno = p.AnioEstreno;
    Duracion = p.Duracion;
    Presupuesto = p.Presupuesto;
    Recaudado = p.Recaudado;
    Sinopsis = p.Sinopsis;
    Poster = p.Poster;
    foreach (Aparicion aparicion in p.Apariciones)
    {
      Personajes.Add(new PeliculaPersonajeVM
      {
        IdPersonaje = aparicion.IdPersonaje,
        Nombre = aparicion.IdPersonajeNavigation?.Nombre ?? "",
        Foto = aparicion.Foto
      });
    }
  }

  public int IdPelicula { get; set; }
  public int Episodio { get; set; }
  public string Titulo { get; set; } = null!;
  public int AnioEstreno { get; set; }
  public string? Anio { get; set; }
  public int Duracion { get; set; }
  public double? Presupuesto { get; set; }
  public double? Recaudado { get; set; }
  public string Sinopsis { get; set; } = null!;
  public string? Poster { get; set; }
  public virtual ICollection<PeliculaPersonajeVM> Personajes { get; set; } = new List<PeliculaPersonajeVM>();
}

public class PeliculaPersonajeVM
{
  public PeliculaPersonajeVM() { }

  public int IdPersonaje {get;set;}
  public string Nombre { get; set; } = null!;
  public string? Foto { get; set; }
}

public class PeliculaEventoVM { } // para hacer despues...