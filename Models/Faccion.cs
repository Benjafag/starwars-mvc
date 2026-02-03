using System;
using System.Collections.Generic;

namespace StarWars.Models;

public partial class Faccion
{    public int IdFaccion { get; set; }
    public string Nombre { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public string? PeriodoExistencia { get; set; }
    public string? Logo { get; set; }
    public int? IdLider { get; set; }
    public virtual ICollection<Aparicion>? Apariciones { get; set; } = new List<Aparicion>();
    public virtual Personaje? IdLiderNavigation { get; set; }
}
