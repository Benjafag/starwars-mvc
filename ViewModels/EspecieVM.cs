using StarWars.Models;

namespace StarWars.ViewModels;

public partial class EspecieVM
{
  public EspecieVM() { }
  public EspecieVM(Especie e)
  {
    IdEspecie = e.IdEspecie;
    Nombre = e.Nombre;
    EsperanzaDeVida = e.EsperanzaDeVida;
    AlturaPromedio = e.AlturaPromedio;
    Habilidades = e.Habilidades;
    Idioma = e.Idioma;
    PlanetaOrigen = new PlanetaEspecieVM(e.IdPlanetaOrigen, e.IdPlanetaOrigenNavigation?.Nombre ?? "" , e.IdPlanetaOrigenNavigation?.Foto ?? "/images/desconocido.webp");
    Personajes = e.Personajes?.Select(p => new PersonajeEspecieVM(p)).ToList() ?? [];
  }

  public int IdEspecie { get; set; }
  public string Nombre { get; set; } = null!;
  public int? EsperanzaDeVida { get; set; }
  public int? AlturaPromedio { get; set; }
  public string? Habilidades { get; set; }
  public string? Idioma { get; set; }
  public virtual PlanetaEspecieVM? PlanetaOrigen { get; set; }
  public virtual List<PersonajeEspecieVM>? Personajes { get; set; } = new List<PersonajeEspecieVM>();
}

public class PersonajeEspecieVM
{
  public PersonajeEspecieVM() { }
  public PersonajeEspecieVM(Personaje p)
  {
    IdPersonaje = p.IdPersonaje;
    Nombre = p.Nombre;
    Foto = p.Apariciones!.OrderBy(p => p.Edad).First().Foto;
  }

  public int IdPersonaje { get; set; }
  public string Nombre { get; set; } = null!;
  public string? Foto { get; set; }
}

public class PlanetaEspecieVM
{
  public PlanetaEspecieVM() { }
  public PlanetaEspecieVM(int? id, string nombre, string foto)
  {
    IdPlaneta = id;
    NombrePlaneta = nombre;
    Foto = foto;
  }
  public int? IdPlaneta;
  public string NombrePlaneta = null!;
  public string Foto = null!;
}