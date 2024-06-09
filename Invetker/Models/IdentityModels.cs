using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Invetker;

public class InvetkerContext : IdentityDbContext
{
  static readonly string connectionString = "Server=localhost;Port=8889;User=root;Password=root;Database=invetker";

  public DbSet<UserModel> Users { get; set; }

  public DbSet<TransactionModel> Transactions { get; set; }

  public DbSet<PerformanceModel> Performances { get; set; }

  public InvetkerContext(DbContextOptions options) : base(options)
	{

	}

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var builder = WebApplication.CreateBuilder();

    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
  }

}
