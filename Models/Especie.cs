using System;
using System.Collections.Generic;

namespace StarWars.Models;

public partial class Especie
{
  public int IdEspecie { get; set; }
  public string Nombre { get; set; } = null!;
  public int? EsperanzaDeVida { get; set; }
  public int? AlturaPromedio { get; set; }
  public string? Habilidades { get; set; }
  public string? Idioma { get; set; }
  public int? IdPlanetaOrigen { get; set; }
  public virtual Planeta? IdPlanetaOrigenNavigation { get; set; }
  public virtual ICollection<Personaje>? Personajes { get; set; } = new List<Personaje>();
}
