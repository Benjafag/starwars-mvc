namespace StarWars.Models;
public class BusquedaItem
{
  public int Id {get;set;} = 0;
  public string Nombre { get; set; } = "";
  public string Foto {get; set; } = "";

  public string Categoria { get; set; } = "";
  public string Controlador () {
    return Categoria switch
    {
      "planeta" => "Planetas",
      "pelicula" => "Peliculas",
      "actor" => "Actores",
      _ => "Personajes",
    };
  }
}
