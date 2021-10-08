using Microsoft.EntityFrameworkCore;
using Nortwind.Entities;
using System;


namespace NorthWind.Repositories.EFCore
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // config entity
            modelBuilder.Entity<Customer>()
                      .Property(p => p.Id)
                       .HasMaxLength(10)
                       .IsFixedLength();
            // costumer
            modelBuilder.Entity<Customer>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            // product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);
            // order
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(c => c.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);
            // rules fields

            modelBuilder.Entity<Order>()
                .Property(c => c.ShipCity)
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Order>()
                .Property(p => p.ShipPostCode)
                .HasMaxLength(10);

            // foraing key 
            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
                 

            // configuring primary key for details

            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });

            // foreing key
            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(c => c.ProductId);


            // ADDING CODE TEST
            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, Name = "COCA COLA" },
                new Product { Id = 2, Name = "PESI" },
                new Product { Id = 3, Name = "DASANI" }
                );
            // ADDING CODE TEST
            modelBuilder.Entity<Customer>()
                .HasData(
                  new Customer { Id = "ALFKI",Name = "Alfreds F." },
                  new Customer { Id = "ANATR", Name = "Ana Trujillo" },
                  new Customer { Id = "ANTON", Name = "Antonio Moreno" }
                );
        }

    }
}
