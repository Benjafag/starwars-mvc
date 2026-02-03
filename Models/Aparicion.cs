using System;
using System.Collections.Generic;

namespace StarWars.Models;

public partial class Aparicion
{
  public string? Rol { get; set; }
  public string? Alias { get; set; }
  public int Edad { get; set; }
  public string? Rango { get; set; }
  public string? Foto { get; set; }
  public int? Altura { get; set; }
  public double? Peso { get; set; }
  public string Estado { get; set; } = null!;
  public string Descripcion { get; set; } = null!;
  public int IdActor { get; set; }
  public int? IdFaccion { get; set; }
  public int IdPersonaje { get; set; }
  public int IdPelicula { get; set; }
  public virtual Actor IdActorNavigation { get; set; } = null!;
  public virtual Faccion? IdFaccionNavigation { get; set; }
  public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;
  public virtual Personaje IdPersonajeNavigation { get; set; } = null!;
}
