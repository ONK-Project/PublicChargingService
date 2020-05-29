using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PublicChargingService.Data;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Models;
using System.Linq;

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
                .UseSqlServer(Configuration.GetConnectionString("F20ITONKASPNETServiceConnection"))
                .Options;
        }

        public async Task<PriceAndTaxes> GetPriceAndTax(DateTime timestamp, string type)
        {
            using (var context = new PriceAndTaxDbContext(_options))
            {
                var priceAndTax = await context.PriceAndTaxes.Where(pnt => pnt.TimeStamp <= timestamp && pnt.Type == type).ToListAsync();
                Console.WriteLine("PriceAndTax nearest to {" + timestamp.ToString() + "} is from {" + priceAndTax.Last().TimeStamp.ToString() + "}");
                return priceAndTax.Last();
            }
        }

        public async Task SavePriceAndTax(PriceAndTaxes priceAndTax)
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
