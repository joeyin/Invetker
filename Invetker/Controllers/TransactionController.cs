using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invetker.Controllers;

[Authorize]
public class TransactionController : Controller
{
  public readonly ILogger<TransactionController> _logger;

  private InvetkerContext _context;

  public TransactionController(ILogger<TransactionController> logger, InvetkerContext context) : base()
  {
    _logger = logger;
    _context = context;
  }

  //GET : /transaction/list
  [HttpGet]
  public async Task<object> List(DateTime? start = null, DateTime? end = null)
  {
    try
    {
      int userId = int.TryParse(
        User.FindFirstValue(ClaimTypes.NameIdentifier), out int id
      ) ? id : 0;

      if (start == null) {
        start = new DateTime(
          DateTime.Now.AddDays(-7).Year,
          DateTime.Now.AddDays(-7).Month,
          DateTime.Now.AddDays(-7).Day,
          0,
          0,
          0
        );
      }

      if (end == null) {
        end = new DateTime(
          DateTime.Now.Year,
          DateTime.Now.Month,
          DateTime.Now.Day,
          23,
          59,
          59
        );
      }

      if (userId != 0)
      {
        List<TransactionModel> data = await _context.Transactions.Where(t => t.UserModelId == userId)
        .Where(t => t.Action == ActionType.Bought || t.Action == ActionType.Sold)
        .Where(t => t.Datetime >= start)
        .Where(t => t.Datetime <= end)
        .ToListAsync();
        return new { success = true, data };
        // return Ok(new { success = true, data });
      }

      return new { success = true, data = Array.Empty<object>() };
      // return Ok(new { success = true, data = Array.Empty<object>() });
    }
    catch (DbUpdateException ex)
    {
      return new { success = false, message = ex };
      // Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
      // return Json(new { success = false, message = ex });
    }
  }

  //POST : /transaction/add
  [HttpPost]
  public async Task<IActionResult> Add(TransactionModel model)
  {
    try
    {
      var transaction = new TransactionModel
      {
        UserModelId = int.TryParse(
          User.FindFirstValue(ClaimTypes.NameIdentifier), out int id
        ) ? id : 0,
        Ticker = model.Ticker,
        Datetime = model.Datetime,
        Quantity = model.Quantity,
        Action = model.Action,
        Price = model.Price,
        Fee = model.Fee,
        Notes = model.Notes
      };
      await _context.AddAsync(transaction);
      await _context.SaveChangesAsync();
      return Ok(new { success = true });
    }
    catch (DbUpdateException ex)
    {
      Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
      return Json(new { success = false, message = ex.Message.ToString() });
    }
  }
}
