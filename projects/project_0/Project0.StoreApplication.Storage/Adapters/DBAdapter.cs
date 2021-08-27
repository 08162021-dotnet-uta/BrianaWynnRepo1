using Microsoft.EntityFrameworkCore;
using Project0.StoreApplication.Domain.Models;

namespace Project0.StoreApplication.Storage.Adapters
{
  public class DBAdapter : DbContext
  {
    public DbSet<Customer> Customers { get; set; }// tells serializer(entity framework) when I try to reach the customer table 
    //it should be a set of customer instances. Each instance should be a record in sql
    public DbSet<Order> Orders { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database= StoreApplicationDB; Trusted_Connection = True;");
    }

  }
}