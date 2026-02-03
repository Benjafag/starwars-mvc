using System;
using System.Collections.Generic;

namespace StarWars.Models;

public partial class Planeta
{
  public Planeta() { }

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

  public virtual ICollection<Especie>? Especies { get; set; } = new List<Especie>();
  public virtual ICollection<Evento>? Eventos { get; set; } = new List<Evento>();
  public virtual ICollection<Personaje>? Personajes { get; set; } = new List<Personaje>();
}
