using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebAPIDemoDataAcess.EntityModels;


#nullable disable

namespace WebAPIDemoDataAcess
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }
        public virtual DbSet<ProductStore> ProductStores { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<ViewStoreOrder> ViewStoreOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
                var config = builder.Build();
                var connectionString = config.GetConnectionString("CoreDbContextConnectionString");
                    
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                //entity.Property(e => e.CardNumber).HasColumnName("cardNumber");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PWord)
                    .HasMaxLength(100)
                    .HasColumnName("pWord");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__73BA3083");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__StoreId__74AE54BC");

                
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK__ProductO__08D097A326D34EF7");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__ProductOr__Order__7A672E12");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductOrders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductOr__Produ__7B5B524B");
            });

            modelBuilder.Entity<ProductStore>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("PK__ProductS__F0C23D6D7386D552");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductStores)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductSt__Produ__7E37BEF6");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductStores)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__ProductSt__Store__7F2BE32F");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");
            });

            modelBuilder.Entity<Inventory>(
             eb =>
             {
                 eb.HasNoKey();
                 eb.ToView("Inventory");
                 
             });

            modelBuilder.Entity<ViewStoreOrder>(
           eb =>
           {
               eb.HasNoKey();
               eb.ToView("ViewStoreOrder");

           });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
