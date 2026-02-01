using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars;
using StarWars.Models;
using StarWars.ViewModels;

namespace StarWars.Controllers;
public class PeliculasController : Controller
{
  private StarWarsContext _context;
  public PeliculasController()
  {
    _context = new StarWarsContext();
  }

  public IActionResult Index () => View(_context.Peliculas.Select(p => new PeliculaIndexVM(p)).ToList());

  public IActionResult Detalles(int id)
  {
    Pelicula resultado = _context.Peliculas
    .Include(p => p.Apariciones)
    .ThenInclude(a => a.IdPersonajeNavigation)
    .FirstOrDefault(p => p.IdPelicula == id);
    resultado.Apariciones =  resultado.Apariciones.OrderBy(ap => ap.IdPersonajeNavigation.Nombre).ToList();
    return resultado != null ? View(new PeliculaDetallesVM(resultado)) : RedirectToAction("Index");
  }
}