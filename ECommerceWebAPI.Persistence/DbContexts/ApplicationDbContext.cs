using ECommerceWebAPI.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Persistence.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);





            // Seeding 

            modelBuilder.Entity<Product>().HasData(
        new Product
        {
            Id = 1,
            Name = "Mouse",
            Description = "Mouse with USB",
            Price = 29.99,
            Stock = 150,
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsArchived = false,
            IsDeleted = false
        },
        new Product
        {
            Id = 2,
            Name = "Keyboard",
            Description = "Keyboard with USB",
            Price = 69.99,
            Stock = 100,
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsArchived = false,
            IsDeleted = false
        },
        new Product
        {
            Id = 3,
            Name = "Monitor",
            Description = "Full HD IPS monitor",
            Price = 199.99,
            Stock = 50,
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsArchived = false,
            IsDeleted = false
        },
        new Product
        {
            Id = 4,
            Name = "IPhone 15",
            Description = "No Description",
            Price = 39.99,
            Stock = 200,
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsArchived = false,
            IsDeleted = false
        },
        new Product
        {
            Id = 5,
            Name = "Laptop",
            Description = "Asus Laptop",
            Price = 24.99,
            Stock = 80,
            CreatedDate = DateTime.UtcNow,
            IsActive = true,
            IsArchived = false,
            IsDeleted = false
        }
    );
        }
    }
}
