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

  [Route("Personajes/Detalles/{id}")]
  public IActionResult Detalles(int id)
  {
    Personaje? p = _context.Personajes?
    .Include(p => p.IdPlanetaOrigenNavigation)
    .Include(p => p.IdEspecieNavigation)
    .Include(p => p.Apariciones)
    .ThenInclude(ap => ap.IdPeliculaNavigation) 
    .FirstOrDefault(p => p.IdPersonaje == id);
    return p is null ? RedirectToAction("Index","Home") : View(new PersonajeDetallesVM(p)) ;
  }

  [Route("Personajes/Detalles/{IdPersonaje}/{IdPelicula}")]
  public IActionResult DetallesEnPelicula(int IdPersonaje, int IdPelicula)
  {
    var resultado = _context.Apariciones?
    .Include(ap => ap.IdActorNavigation)
    .Include(ap => ap.IdFaccionNavigation)
    .Include(ap => ap.IdPeliculaNavigation)
    .Include(ap => ap.IdPersonajeNavigation) 
    .Select(ap => new AparicionVM(ap))
    .ToList()
    .FirstOrDefault(ap => ap.IdPersonaje == IdPersonaje && ap.IdPelicula == IdPelicula);  
    
    return View(resultado);
  }
}