using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Invetker.Models;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices.JavaScript;
using System.Web;

namespace Invetker.Controllers;

[Authorize]
public class PortalController : TransactionController
{

  public PortalController(ILogger<TransactionController> logger, InvetkerContext context) : base(logger, context)
  {
  }

  public async Task<IActionResult> Index()
  {
    TempData["slider-collapsed"] = Request.Cookies["slider-collapsed"];

    var model = new {
      transactions = await this.List()
    };

    return View(model);
  }

  [HttpGet]
  public async Task<IActionResult> Transactions(string daterange)
  {
    TempData["slider-collapsed"] = Request.Cookies["slider-collapsed"];

    _logger.LogInformation("range:" + daterange);

    var model = new {
      transactions = await this.List()
    };

    return View(model);
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
