using System;
using System.Collections.Generic;

namespace StarWars.Models;

public partial class Evento
{
  public int IdEvento { get; set; }

  public string Titulo { get; set; } = null!;

  public string? Fecha { get; set; }

  public string Descripcion { get; set; } = null!;

  public string? Resultado { get; set; }

  public string? Imagen { get; set; }

  public int? IdPlaneta { get; set; }

  public int IdPelicula { get; set; }

  public virtual Pelicula IdPeliculaNavigation { get; set; } = null!;

  public virtual Planeta? IdPlanetaNavigation { get; set; } = null!;
}
