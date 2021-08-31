using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Adapters
{
  public class DBAdapter : DbContext
  {
    /// <summary>
    /// Customer entity for serialization
    /// </summary>
    public DbSet<Customer> Customers { get; set; }
    /// <summary>
    /// Order entity for serialization
    /// </summary>
    public DbSet<Order> Orders { get; set; }
    /// <summary>
    /// store entity for serialziation
    /// </summary>
    public DbSet<Store> Stores { get; set; }
    /// <summary>
    /// product entity for serialization
    /// </summary>
    public DbSet<Product> Products { get; set; }
    
    /// <summary>
    /// connection for c# to communicate with sql
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database= StoreApplicationDB; Trusted_Connection = True;");
    }

  }
}