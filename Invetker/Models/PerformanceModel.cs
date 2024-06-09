using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Invetker.Models;
using Microsoft.AspNetCore.Identity;

namespace Invetker;

public class PerformanceModel
{
  [Key]
  public int Id { get; set; }

  public virtual UserModel UserModel { get; set; }
  [ForeignKey(nameof(Id))]
  public int ClasseId { get; set; }

  // Total user deposit
  public float TotalDeposit { get; set; }

  // Count total property amount
  public float NetLiquidityValue { get; set; }

  // Unresized portfolio / Total user deposit
  public float Rate { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
}
