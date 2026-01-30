using System;
using System.Collections.Generic;

namespace StarWars.Models;

public partial class Actor
{
  public int IdActor { get; set; }

  public string Nombre { get; set; } = null!;

  public string Apellido { get; set; } = null!;

  public DateOnly FechaNacimiento { get; set; }

  public string Nacionalidad { get; set; } = null!;

  public string Genero { get; set; } = null!;

  public string Foto { get; set; }

  public virtual ICollection<Aparicion> Apariciones { get; set; } = new List<Aparicion>();
}
