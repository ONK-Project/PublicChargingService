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
        public DbSet<PriceAndTax> PriceAndTaxes { get; set; }

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
        }

        private void onModelCreatingPriceAndTax(ModelBuilder modelBuilder) {   }
    }
}
