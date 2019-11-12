using System;
using System.Linq;
using BitcoinLogger.Api.Data.Models;
using BitCoinLogger.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BitcoinLogger.Api.Data
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Source> Sources { get; set; }

        public DbSet<PriceHistoryItem> PriceHistory { get; set; }
           
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Source>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedOnAdd();
                e.Property(x => x.CreatedAt)
                    .HasColumnType("timestamp");
            });
            
            builder.Entity<PriceHistoryItem>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).ValueGeneratedOnAdd();
                e.Property(x => x.CreatedAt)
                    .HasColumnType("timestamp");
            });
        }

        public override int SaveChanges()
        {
            var currentDateTime = DateTime.UtcNow;
            var entries =
                ChangeTracker.Entries()
                    .Where(e => e.Entity is IModelBase &&
                                (e.State == EntityState.Added || e.State == EntityState.Modified)).ToList();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((IModelBase) entry.Entity).CreatedAt = currentDateTime;
                }
            }

            var modifiedCount = 0;
            try
            {
                modifiedCount = base.SaveChanges();
            }
            catch
            {
                // TODO: Log error
            }

            return modifiedCount;
        }
    }
}
