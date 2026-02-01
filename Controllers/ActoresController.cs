using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars;
using StarWars.Models;
using StarWars.ViewModels;

namespace StarWars.Controllers;
public class ActoresController : Controller
{
  private static StarWarsContext _context;

  public ActoresController()
  {
    _context = new StarWarsContext();
  }

  public IActionResult Index() => View(
    _context.Actores
    .Include(a => a.Apariciones)
    .ThenInclude(ap => ap.IdPeliculaNavigation)
    .Include(a => a.Apariciones)
    .ThenInclude(ap => ap.IdPersonajeNavigation)
    .OrderBy(a => a.Nombre)
    .Select(a => new ActorIndexVM(a))
    .ToList()
  );

  public IActionResult Detalles(int id)
  {
    Actor resultado = _context.Actores
    .Include(a => a.Apariciones)
    .ThenInclude(a => a.IdPeliculaNavigation)
    .Include(a => a.Apariciones)
    .ThenInclude(ap => ap.IdPersonajeNavigation)
    .FirstOrDefault(a => a.IdActor == id);
    return resultado != null ? View(new ActorDetallesVM(resultado)) : RedirectToAction("Index");
  }
}