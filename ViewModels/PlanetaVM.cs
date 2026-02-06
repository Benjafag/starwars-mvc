using StarWars.Models;

public class PlanetaIndexVM
{
  public PlanetaIndexVM() { }
  public PlanetaIndexVM(Planeta p)
  {
    IdPlaneta = p.IdPlaneta;
    Nombre = p.Nombre;
    SistemaEstelar = p.SistemaEstelar;
    Region = p.Region;
    Tipo = p.Tipo;
    Foto = p.Foto;
  }

  public int IdPlaneta { get; set; }
  public string Nombre { get; set; } = null!;
  public string SistemaEstelar { get; set; } = null!;
  public string Region { get; set; } = null!;
  public string Tipo { get; set; } = null!;
  public string? Foto { get; set; }
}

public class PlanetaDetallesVM
{
  public PlanetaDetallesVM() { }
  public PlanetaDetallesVM(Planeta p)
  {
    IdPlaneta = p.IdPlaneta;
    Nombre = p.Nombre;
    SistemaEstelar = p.SistemaEstelar;
    Region = p.Region;
    Tipo = p.Tipo;
    Clima = p.Clima;
    Gravedad = p.Gravedad;
    PoblacionAproximada = p.PoblacionAproximada;
    Gobierno = p.Gobierno;
    Capital = p.Capital;
    Foto = p.Foto;
  }

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
}