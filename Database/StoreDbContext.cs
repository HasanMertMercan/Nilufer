using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ValueTypes.Entity;

namespace Database
{
    public class StoreDbContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public DbSet<Customer> CustomerList { get; set; }
        public DbSet<CustomerOrder> CustomerOrderList { get; set; }
        public DbSet<Dealer> DealerList { get; set; }
        public DbSet<DealerOrder> DealerOrderList { get; set; }
        public DbSet<Expenditure> ExpenditureList { get; set; }
        public DbSet<OutgoingOrder> OutgoingOrderList { get; set; }
        public DbSet<Product> ProductList { get; set; }
        public DbSet<Supplier> SupplierList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Configuration.GetConnectionString("NiluferDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductCode);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.UnitPrice).IsRequired();
            });

            modelBuilder.Entity<Dealer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.StoreName).IsRequired();
                entity.Property(e => e.OwnerName);
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.EmailAddress);
                entity.Property(e => e.Address);
                entity.Property(e => e.TotalBalance).IsRequired();
            });

            modelBuilder.Entity<Customer>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.EmailAddress);
                entity.Property(e => e.TotalBalance).IsRequired();
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.StoreName).IsRequired();
                entity.Property(e => e.OwnerName);
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.EmailAddress);
                entity.Property(e => e.Address);
                entity.Property(e => e.TotalBalance).IsRequired();
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.CustomerId).IsRequired();
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.OrderAmount).IsRequired();
                entity.Property(e => e.DeliveryDate).IsRequired();
                entity.Property(e => e.AdvancePayment);
                entity.Property(e => e.OrderStatus).IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired();
            });

            modelBuilder.Entity<DealerOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.DealerId).IsRequired();
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.OrderAmount).IsRequired();
                entity.Property(e => e.DeliveryDate).IsRequired();
                entity.Property(e => e.AdvancePayment);
                entity.Property(e => e.OrderStatus).IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired();
            });

            modelBuilder.Entity<OutgoingOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.SupplierId).IsRequired();
                entity.Property(e => e.ProductId).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.OrderAmount).IsRequired();
                entity.Property(e => e.DeliveryDate).IsRequired();
                entity.Property(e => e.AdvancePayment);
                entity.Property(e => e.OrderStatus).IsRequired();
                entity.Property(e => e.TotalPrice).IsRequired();
            });

            modelBuilder.Entity<Expenditure>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OutgoingOrderId);
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.TotalAmount).IsRequired();
                entity.Property(e => e.Description).IsRequired();
            });
        }
    }
}
