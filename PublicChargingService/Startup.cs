using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PublicChargingService.Data;
using PublicChargingService.Service.PriceAndTaxService;
using Microsoft.OpenApi.Models;

namespace PublicChargingService
{
    public class Startup
    {
        private PriceUpdater priceUpdater;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            priceUpdater = new PriceUpdater(new PriceAndTaxService(configuration), 45, 45, 45);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<PriceAndTaxDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("??")));
            services.AddScoped<IPriceAndTaxService, PriceAndTaxService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PublicChargingService API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PublicChargingService API V1");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
