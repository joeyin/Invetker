using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Invetker;

public class TransactionModel
{
  [Key]
  public int Id { get; set; }

  public virtual UserModel UserModel { get; set; }
  [ForeignKey(nameof(Id))]
  public int ClasseId { get; set; }

  public string Ticker { get; set; }

  public float Quantity { get; set; }

  public ActionType Action { get; set; }

  public float Price { get; set; }

  public float Fee { get; set; }

  // Transaction time
  public string Datetime { get; set; }

  public string? Notes { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public enum ActionType
{
  Bought,
  Sold,
  Deposit,
  Withdrawal,
}