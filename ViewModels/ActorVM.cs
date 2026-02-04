using StarWars.Models;
namespace StarWars.ViewModels;

public class ActorAparicionVM
{
  public ActorAparicionVM() { }

  public int IdPelicula { get; set; }
  public string NombrePelicula { get; set; } = null!;
  public string NombrePersonaje { get; set; } = null!;
  public string Descripcion { get; set; } = null!;
  public string Poster { get; set; } = null!;
}


public class ActorIndexVM
{
  public ActorIndexVM() { }
  public ActorIndexVM(Actor a)
  {
    IdActor = a.IdActor;
    Nombre = a.Nombre;
    Apellido = a.Apellido;
    Foto = a.Foto;
    if (a.Apariciones != null)
      foreach (var aparicion in a.Apariciones)
        Apariciones.Add(new ActorAparicionVM
        {
          IdPelicula = aparicion.IdPeliculaNavigation?.IdPelicula ?? 0,
          NombrePelicula = $"Episodio {aparicion.IdPeliculaNavigation?.Episodio}: {aparicion.IdPeliculaNavigation?.Titulo}" ?? "Sin titulo",
          NombrePersonaje = aparicion.IdPersonajeNavigation?.Nombre ?? "Sin nombre",
          Descripcion = aparicion.Descripcion ?? "Sin descripcion",
          Poster = aparicion.IdPeliculaNavigation?.Poster ?? "/img/placeholder.jpg"
        });
  }

  public int IdActor { get; set; }
  public string Nombre { get; set; } = null!;
  public string Apellido { get; set; } = null!;
  public string? Foto { get; set; }

  public virtual ICollection<ActorAparicionVM>? Apariciones { get; set; } = new List<ActorAparicionVM>();
}


public class ActorDetallesVM
{
  public ActorDetallesVM() { }
  public ActorDetallesVM(Actor a)
  {
    IdActor = a.IdActor;
    Nombre = $"{a.Nombre} {a.Apellido}";
    Foto = a.Foto;
    FechaNacimiento = a.FechaNacimiento;
    Nacionalidad = a.Nacionalidad;
    Genero = a.Genero;
    Biografia = a.Biografia;

    if (a.Apariciones != null)
      foreach (var aparicion in a.Apariciones)
        Apariciones.Add(new ActorAparicionVM
        {
          IdPelicula = aparicion.IdPeliculaNavigation?.IdPelicula ?? 0,
          NombrePelicula = $"Episodio {aparicion.IdPeliculaNavigation?.Episodio}: {aparicion.IdPeliculaNavigation?.Titulo}" ?? "Sin titulo",
          NombrePersonaje = aparicion.IdPersonajeNavigation?.Nombre ?? "Sin nombre",
          Descripcion = aparicion.Descripcion ?? "Sin descripcion",
          Poster = aparicion.IdPeliculaNavigation?.Poster ?? "/img/placeholder.jpg"
        });
  }

  public int IdActor { get; set; }
  public string? Biografia { get; set; }
  public string Nombre { get; set; } = null!;
  public DateOnly FechaNacimiento { get; set; }
  public string Nacionalidad { get; set; } = null!;
  public string Genero { get; set; } = null!;
  public string? Foto { get; set; }

  public virtual ICollection<ActorAparicionVM>? Apariciones { get; set; } = new List<ActorAparicionVM>();
}