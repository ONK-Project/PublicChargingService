using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace PublicChargingService.Data
{
    public class PriceAndTaxDbContext : DbContext
    {
        public DbSet<PriceAndTaxes> PriceAndTaxes { get; set; }

        public PriceAndTaxDbContext() { }

        public PriceAndTaxDbContext(DbContextOptions<PriceAndTaxDbContext> options)
           : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            onModelCreatingPriceAndTax(modelBuilder);
            onModelCreatingSeedData(modelBuilder);
        }

        private void onModelCreatingPriceAndTax(ModelBuilder modelBuilder) {   }

        private void onModelCreatingSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceAndTaxes>().HasData(
                new PriceAndTaxes
                {
                    Id = 1111,
                    Type = "heat",
                    Price = 420,
                    Currency = "Dkk",
                    UnitOfMeassure = "kWh/m^3",
                    Tax = 69,
                    TimeStamp = DateTime.Now
                },
                new PriceAndTaxes
                {
                    Id = 2222,
                    Type = "electricity",
                    Price = 420,
                    Currency = "Dkk",
                    UnitOfMeassure = "kWh",
                    Tax = 69,
                    TimeStamp = DateTime.Now
                },
                new PriceAndTaxes
                {
                    Id = 3333,
                    Type = "water",
                    Price = 420,
                    Currency = "Dkk",
                    UnitOfMeassure = "m^3",
                    Tax = 69,
                    TimeStamp = DateTime.Now
                }
                );
        }
    }
}
