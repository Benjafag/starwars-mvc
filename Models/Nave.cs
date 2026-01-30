using System;
using System.Collections.Generic;

namespace StarWars.Models;

public partial class Nave
{
    public int IdNave { get; set; }

    public string Nombre { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Fabricante { get; set; }

    public string Tipo { get; set; } = null!;

    public int VelocidadMaxima { get; set; }

    public string Foto { get; set; }

    public int IdDuenio { get; set; }

    public int IdPrimerPelicula { get; set; }

    public virtual Personaje IdDuenioNavigation { get; set; }

    public virtual Pelicula IdPrimerPeliculaNavigation { get; set; }
}
