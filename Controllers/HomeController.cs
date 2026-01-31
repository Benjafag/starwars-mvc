using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StarWars.Models;

namespace StarWars.Controllers;
public class HomeController : Controller
{
  private StarWarsContext _context;
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
    _context = new StarWarsContext();
  }

  public IActionResult Index(string query)
  {
    List<BusquedaItem> items;
    if (string.IsNullOrEmpty(query))
      items =  _context.Uniones.ToList();
    else
      items =  _context.Uniones.Where(item => item.Nombre.ToLower().Contains(query.ToLower())).ToList();
    return View(items);
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
