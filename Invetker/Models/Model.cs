using Invetker.Models;
using Microsoft.EntityFrameworkCore;

namespace Invetker;

public class InvetkerContext : DbContext
{
  public DbSet<UserModel> Users { get; set; }

  public DbSet<TransactionModel> Transactions { get; set; }

  public DbSet<PerformanceModel> Performances { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlServer("Server=localhost,8889;Database=invetker;User=root;Password=root;");
}
