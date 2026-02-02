using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars;
using StarWars.Models;
using StarWars.ViewModels;
public class PersonajesController : Controller
{
  private StarWarsContext _context;

  public PersonajesController()
  {
    _context = new StarWarsContext();
  }

  public IActionResult Detalles(int id)
  {
    var resultado = 
    _context
    .Personajes
    .Include(p => p.IdPlanetaOrigenNavigation)
    .Include(p => p.IdEspecieNavigation)
    .Include(p => p.Apariciones)
    .ThenInclude(ap => ap.IdPeliculaNavigation)
    // .OrderBy(p => p.Apariciones.Edad) // investigar como se hace
    .Select(p => new PersonajeDetallesVM
    {
      IdPersonaje = p.IdPersonaje,
      Nombre = p.Nombre,
      Genero = p.Genero,
      SensibleALaFuerza = p.SensibleALaFuerza,
      Biografia = p.Biografia,
      IdEspecie = p.IdEspecie,
      Especie = p.IdEspecieNavigation.Nombre ?? "Especie desconocida",
      IdPlanetaOrigen = p.IdPlanetaOrigen,
      PlanetaOrigen = p.IdPlanetaOrigenNavigation.Nombre ?? "Origen desconocido", // se rompe si el atributo no es nullable y la db devuelve un null, asi que lo controlo en el select
      Foto = p.Apariciones.ToList().OrderBy(ap => ap.Edad).Last().Foto ?? "",
      Apariciones = p.Apariciones.Select(ap => new PersonajeAparicionVM
        {
          Descripcion = ap.Descripcion,
          IdPelicula = ap.IdPelicula,
          NombrePelicula = ap.IdPeliculaNavigation.Titulo,
          Poster = ap.IdPeliculaNavigation.Poster,
          Foto = ap.Foto
        }).ToList()
    }) 
    .FirstOrDefault(p => p.IdPersonaje == id);
    return resultado is null ? RedirectToAction("Index","Home") : View(resultado) ;
  }
}