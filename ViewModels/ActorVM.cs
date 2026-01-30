using StarWars.Models;
namespace StarWars.ViewModels;
public class ActorAparicionVM
{
  public int IdPelicula;
  public string NombrePelicula;
  public string NombrePersonaje;
  public string Descripcion;
  public string Poster;
}


public class ActorIndexVM
{
  public ActorIndexVM() { }
  public ActorIndexVM(Actor a)
  {
    this.IdActor = a.IdActor;
    this.Nombre = a.Nombre;
    this.Apellido = a.Apellido;
    this.Foto = a.Foto;
    if (a.Apariciones != null)
      foreach (var aparicion in a.Apariciones)
        this.Apariciones.Add(new ActorAparicionVM
        {
          IdPelicula = aparicion.IdPeliculaNavigation?.IdPelicula ?? 0,
          NombrePelicula = $"Episodio {aparicion.IdPeliculaNavigation?.Episodio}: {aparicion.IdPeliculaNavigation.Titulo}" ?? "Sin titulo",
          NombrePersonaje = aparicion.IdPersonajeNavigation?.Nombre ?? "Sin nombre",
          Descripcion = aparicion.Descripcion,
          Poster = aparicion.IdPeliculaNavigation.Poster
        });
  }
  public int IdActor { get; set; }
  public string Nombre { get; set; } = null;
  public string Apellido { get; set; } = null;
  public string Foto { get; set; }
  public virtual ICollection<ActorAparicionVM> Apariciones { get; set; } = new List<ActorAparicionVM>();

}


public class ActorDetallesVM
{
  public ActorDetallesVM() { }
  public ActorDetallesVM(Actor a)
  {
    this.IdActor = a.IdActor;
    this.Nombre = a.Nombre;
    this.Apellido = a.Apellido;
    this.Foto = a.Foto;
    if (a.Apariciones != null)
      foreach (var aparicion in a.Apariciones)
        this.Apariciones.Add(new ActorAparicionVM
        {
          IdPelicula = aparicion.IdPeliculaNavigation?.IdPelicula ?? 0,
          NombrePelicula = $"Episodio {aparicion.IdPeliculaNavigation?.Episodio}: {aparicion.IdPeliculaNavigation.Titulo}" ?? "Sin titulo",
          NombrePersonaje = aparicion.IdPersonajeNavigation?.Nombre ?? "Sin nombre",
          Descripcion = aparicion.Descripcion,
          Poster = aparicion.IdPeliculaNavigation.Poster
        });
  }

  public int IdActor { get; set; }
  public string Nombre { get; set; } = null!;
  public string Apellido { get; set; } = null!;
  public DateOnly FechaNacimiento { get; set; }
  public string Nacionalidad { get; set; } = null!;
  public string Genero { get; set; } = null!;
  public string Foto { get; set; }
  public virtual ICollection<ActorAparicionVM> Apariciones { get; set; } = new List<ActorAparicionVM>();
}