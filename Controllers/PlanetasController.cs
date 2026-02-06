using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    List<PlanetaIndexVM> res = (from p in _context.Planetas select new PlanetaIndexVM(p)).ToList().OrderBy(p => p.Region).ToList();
    return View(res);
  }

  public IActionResult Detalles(int id)
  {
    var res = _context.Planetas.Include(p => p.Eventos).Include(p => p.Personajes).Include(p => p.Especies).FirstOrDefault(p=> p.IdPlaneta == id);
    
     // inlcuir planetas, personajes
    return res is null ? RedirectToAction("Index","Home") : View(new PlanetaDetallesVM(res));
  }
}