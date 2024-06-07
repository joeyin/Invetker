using System.ComponentModel.DataAnnotations;

namespace Invetker;

public class PerformanceModel
{
  [Key]
  public int Id { get; set; }

  public int UserId { get; set; }

  // Total user deposit
  public float TotalDeposit { get; set; }

  // Count total property amount
  public float NetLiquidityValue { get; set; }

  // Unresized portfolio / Total user deposit
  public float Rate { get; set; }

  public DateTime CreatedAt { get; set; }
}
