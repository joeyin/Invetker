using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Invetker.Models;

namespace Invetker.Controllers;

public class UserController : Controller
{
  private readonly ILogger<UserController> _logger;

  public UserController(ILogger<UserController> logger)
  {
    _logger = logger;
  }

  //POST : /User/Register
  [HttpPost]
  public IActionResult Register(string Name, string Email, string Password)
  {
    User UserModal = new User();
    UserModal.Name = Name;
    UserModal.Email = Email;
    UserModal.Password = Password;

    var result = UserModal.Create(UserModal);

    if (result.success) {
      return Ok(result);
    } else {
      return Problem(result.message, null, 400);
    }
  }

  //POST : /User/Login
  [HttpGet]
  public string Login(string Email, string Password)
  {
    _logger.LogDebug("Hello World!");
    _logger.LogError("ABC");
    return "321";
    // return View();
  }

  public IActionResult Logout()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
