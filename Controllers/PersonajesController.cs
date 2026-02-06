using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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

  public IActionResult Index()
  {
  List<PersonajeIndexVM>? res =
    // from u in _context.Uniones
    // join p in _context.Personajes on u.Id equals p.IdPersonaje
    // select new PersonajeIndexVM {  };
    _context.Uniones?
    .Where(u=>u.Categoria=="personaje")
    .Select(u => new PersonajeIndexVM(u))
    .ToList();
    return View(res);
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