using Microsoft.EntityFrameworkCore;
using ShopBridge.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopBridge.API.Data.Repositories
{
    public class InventoryContext : DbContext
    {
        public DbSet<InventoryItem> Employees { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<InventoryItem>().ToTable("InventoryItems");
            builder.Entity<InventoryItem>().HasKey(p => p.Id);
            builder.Entity<InventoryItem>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<InventoryItem>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<InventoryItem>().Property(p => p.Price);
            builder.Entity<InventoryItem>().Property(p => p.Manufacturer).HasMaxLength(100);

            builder.Entity<InventoryItem>().HasData(new InventoryItem
            {
                Id = 1,
                Name = "Car",
                Price = 100,
                Manufacturer = "Shakespeare"
            }); ;
        }


        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseClass && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseClass)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseClass)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
