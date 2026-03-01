using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StarWars;
using StarWars.Models;
using StarWars.ViewModels;

public class EspeciesController : Controller
{
  private StarWarsContext _context;

  public EspeciesController()
  {
    _context = new StarWarsContext();
  }

  [Route("Especies/Detalles/{id}")]
  public IActionResult Detalles(int id)
  {
    Especie? res;
    res = _context.Especies?
      .Include(e => e.IdPlanetaOrigenNavigation)
      .Include(e => e.Personajes!)
      .ThenInclude(p => p.Apariciones)
      .FirstOrDefault(e => e.IdEspecie == id);
    return res != null ? View(new EspecieVM(res)) :RedirectToAction("Index","Home") ;
  }
}