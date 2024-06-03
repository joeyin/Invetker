using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Invetker.Models;

namespace Invetker.Controllers;

public class PortalController : Controller
{
  private readonly ILogger<PortalController> _logger;

  public PortalController(ILogger<PortalController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Transactions()
  {
    return View();
  }

  public IActionResult Settings()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
