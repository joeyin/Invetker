using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Invetker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;

namespace Invetker.Controllers;

public class UserController : Controller
{
  private readonly ILogger<UserController> _logger;
  private readonly SignInManager<UserModel> _signInManager;
  private readonly UserManager<UserModel> _userManager;

  public UserController(
    SignInManager<UserModel> signInManager,
    UserManager<UserModel> userManager,
    ILogger<UserController> logger
  )
  {
    _signInManager = signInManager;
    _userManager = userManager;
    _logger = logger;
  }

  //POST : /User/Register
  [HttpPost]
  public async Task<IActionResult> Register(string Name, string Email, string Password)
  {
    var user = new UserModel
    {
      UserName = Name,
      Email = Email,
      HashId = String.Format("{0:X}", (DateTime.Now + Name).GetHashCode())
    };

    var result = await _userManager.CreateAsync(user, Password);

    if (result.Succeeded)
    {
      return Ok(new { success = true });
    }
    else
    {
      var messages = string.Join(", ", result.Errors.Select(x => x.Description));
      Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
      return Json(new { success = false, messages });
    }
  }

  //POST : /User/Login
  [HttpPost]
  public async Task<IActionResult> Login(string Email, string Password)
  {
    var user = await _userManager.FindByEmailAsync(Email);
    if (user == null) {
      Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
      return Json(new { success = false, messages = "Incorrect username or password." });
    }

    var result = await _signInManager.PasswordSignInAsync(user.UserName, Password, false, lockoutOnFailure: false);
    if (result.Succeeded) {
      await _signInManager.SignInAsync(user,
        new AuthenticationProperties()
        {
          AllowRefresh = true,
          IssuedUtc = DateTime.UtcNow,
          ExpiresUtc = DateTime.UtcNow.AddDays(15),
          IsPersistent = true
        });
      return Ok(new { success = true });
    } else {
      Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
      return Json(new { success = false, messages = result });
    }
  }

  //Get : /User/Logout
  [HttpGet]
  public async Task<IActionResult> Logout()
  {
    await _signInManager.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
