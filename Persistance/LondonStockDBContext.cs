using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LondonStock.Domain.Entity.Common;
using LondonStock.Domain.Entity;

namespace LondonStock.Persistance
{
    public class LondonStockDBContext : DbContext
    {
        public LondonStockDBContext(DbContextOptions<LondonStockDBContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockType>().HasKey(t => t.Ticker);
            modelBuilder.Entity<StockType>().HasData(
                new StockType
                {
                    Id = "1",
                    Name = "testStock",
                    Ticker = "sas",
                    Price = "500",

                }, new StockType
                {
                    Id = "2",
                    Name = "testStock2",
                    Ticker = "frw",
                    Price = "350"
                }, new StockType
                {
                    Id = "3",
                    Name = "testStock3",
                    Ticker = "sat",
                    Price = "500",

                });



            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LondonStockDBContext).Assembly);

        }
             
        public DbSet<StockType> Stocks { get; set; }
        public DbSet<TransactionType> Transactions { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
