using System;
using System.Collections.Generic;

namespace StarWars.Models;

public partial class Pelicula
{
  public int IdPelicula { get; set; }
  public int Episodio { get; set; }
  public string Titulo { get; set; } = null!;
  public int AnioEstreno { get; set; }
  public string? Anio { get; set; }
  public int Duracion { get; set; }
  public double? Presupuesto { get; set; }
  public double? Recaudado { get; set; }
  public string Sinopsis { get; set; } = null!;
  public string? Poster { get; set; } = null!;
  public virtual ICollection<Aparicion> Apariciones { get; set; } = new List<Aparicion>();
  public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
  public virtual ICollection<Nave>? Naves { get; set; } = new List<Nave>();
}
