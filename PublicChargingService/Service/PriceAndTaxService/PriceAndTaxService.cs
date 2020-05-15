using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PublicChargingService.Data;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Models;

namespace PublicChargingService.Service.PriceAndTaxService
{
    public class PriceAndTaxService : IPriceAndTaxService
    {
        public IConfiguration Configuration { get; }
        private DbContextOptions<PriceAndTaxDbContext> _options;

        public PriceAndTaxService(IConfiguration configuration)
        {
            Configuration = configuration;
            _options = new DbContextOptionsBuilder<PriceAndTaxDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("??"))
                .Options;
        }

        public async Task<PriceAndTax> GetPriceAndTax(DateTime timestamp, string type)
        {
            using (var context = new PriceAndTaxDbContext(_options))
            {
                var princeAndTax = await context.PriceAndTaxes.FirstAsync(pnt => pnt.TimeStamp <= timestamp && pnt.Type == type);

                return princeAndTax;
            }
        }

        public async Task SavePriceAndTax(PriceAndTax priceAndTax)
        {
            using (var context = new PriceAndTaxDbContext(_options))
            {
                await context.PriceAndTaxes.AddAsync(priceAndTax);
                await context.SaveChangesAsync();
            }
        }

        public bool CreateDB()
        {
            using (var context = new PriceAndTaxDbContext(_options))
            {
                if (true && (context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return false;

                context.Database.EnsureDeleted();
                return context.Database.EnsureCreated();
            }
        }
    }
}
