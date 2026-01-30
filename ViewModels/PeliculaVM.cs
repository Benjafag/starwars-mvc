using StarWars.Models;

namespace StarWars.ViewModels;

public class PeliculaIndexVM
{
  public PeliculaIndexVM() { }
  public PeliculaIndexVM(Pelicula p)
  {
    this.IdPelicula = p.IdPelicula;
    this.Episodio = p.Episodio;
    this.Titulo = p.Titulo;
    this.Anio = p.Anio;
    this.Poster = p.Poster;
  }
  public int IdPelicula { get; set; }
  public int Episodio { get; set; }
  public string Titulo { get; set; } = null!;
  public string Anio { get; set; }
  public string Poster { get; set; }
}

public class PeliculaDetallesVM
{
  public PeliculaDetallesVM()
  {
  }
  public PeliculaDetallesVM(Pelicula p)
  {
    this.IdPelicula = p.IdPelicula;
    this.Episodio = p.Episodio;
    this.Titulo = p.Titulo;
    this.Anio = p.Anio;
    this.AnioEstreno = p.AnioEstreno;
    this.Duracion = p.Duracion;
    this.Presupuesto = p.Presupuesto;
    this.Recaudado = p.Recaudado;
    this.Sinopsis = p.Sinopsis;
    this.Poster = p.Poster;
    foreach (Aparicion aparicion in p.Apariciones)
    {
      Personajes.Add(new PeliculaPersonajeVM
      {
        Nombre = aparicion.IdPersonajeNavigation?.Nombre,
        Foto = aparicion.Foto
      });
    }
  }
  public int IdPelicula { get; set; }
  public int Episodio { get; set; }
  public string Titulo { get; set; } = null!;
  public int AnioEstreno { get; set; }
  public string Anio { get; set; }
  public int Duracion { get; set; }
  public double Presupuesto { get; set; }
  public double Recaudado { get; set; }
  public string Sinopsis { get; set; } = null!;
  public string Poster { get; set; }
  public virtual ICollection<PeliculaPersonajeVM> Personajes { get; set; } = new List<PeliculaPersonajeVM>();
}

public class PeliculaPersonajeVM
{
  public string Nombre;
  public string Foto;  
}

public class PeliculaEventoVM {} // para hacer despues...