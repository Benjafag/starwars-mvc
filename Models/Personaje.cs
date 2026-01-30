using System;
using System.Collections.Generic;

namespace StarWars.Models;

public partial class Personaje
{
    public int IdPersonaje { get; set; }

    public string Nombre { get; set; } = null!;

    public string Genero { get; set; }

    public bool SensibleALaFuerza { get; set; }

    public string Biografia { get; set; } = null!;

    public int IdEspecie { get; set; }

    public int IdPlanetaOrigen { get; set; }

    public virtual ICollection<Aparicion> Apariciones { get; set; } = new List<Aparicion>();

    public virtual ICollection<Faccion> Facciones { get; set; } = new List<Faccion>();

    public virtual Especie IdEspecieNavigation { get; set; } = null!;

    public virtual Planeta IdPlanetaOrigenNavigation { get; set; } = null!;

    public virtual ICollection<Nave> Naves { get; set; } = new List<Nave>();
}
