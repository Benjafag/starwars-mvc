using Microsoft.AspNetCore.Mvc;
using StarWars;
using StarWars.Models;
using StarWars.ViewModels;

public class PlanetasController : Controller
{
  private StarWarsContext _context;

  public PlanetasController()
  {
    _context = new StarWarsContext();
  }

  public IActionResult Index()
  {
    List<PlanetaIndexVM> res = (from p in _context.Planetas select new PlanetaIndexVM(p)).ToList();
    return View(res);
  }

  public IActionResult Detalles(int id)
  {
    PlanetaDetallesVM? res = new PlanetaDetallesVM(_context.Planetas?.Find(id));
    return res is null ? RedirectToAction("Index","Home") : View(res);
  }
}