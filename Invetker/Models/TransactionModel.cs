using System.ComponentModel.DataAnnotations;

namespace Invetker;

public class TransactionModel
{
  [Key]
  public int Id { get; set; }

  public int UserId { get; set; }

  public string Ticker { get; set; }

  public float Quantity { get; set; }

  public ActionType Action { get; set; }

  public float Price { get; set; }

  public float Fee { get; set; }

  // Transaction time
  public string Datetime { get; set; }

  public string? Notes { get; set; }

  public DateTime CreatedAt { get; set; }
}

public enum ActionType
{
  Bought,
  Sold,
  Deposit,
  Withdrawal,
}