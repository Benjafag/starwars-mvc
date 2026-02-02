using System;
using System.Collections.Generic;
using StarWars.Models;

namespace StarWars.ViewModels;

public class PersonajeDetallesVM
{
  public PersonajeDetallesVM() { }
  public int IdPersonaje { get; set; }
  public string Nombre { get; set; } = null!;
  public string Genero { get; set; }
  public bool SensibleALaFuerza { get; set; }
  public string Biografia { get; set; } = null!;
  public int IdEspecie { get; set; }
  public string Especie { get; set; }
  public int IdPlanetaOrigen { get; set; }
  public string PlanetaOrigen { get; set; }
  public string Foto { get; set; }
  public List<PersonajeAparicionVM> Apariciones { get; set; }

}


public class PersonajeAparicionVM
{
  public string Descripcion { get; set; }
  public int IdPelicula { get; set; }
  public string NombrePelicula { get; set; }
  public string Poster { get; set; }
  public string Foto { get; set; }
}