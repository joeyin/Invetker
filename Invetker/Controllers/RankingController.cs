using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Invetker.Models;

namespace Invetker.Controllers;

public class RankingController : Controller
{
  private readonly ILogger<RankingController> _logger;

  public RankingController(ILogger<RankingController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
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