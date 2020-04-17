using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace PublicChargingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChargingController : ControllerBase
    {
        private readonly ILogger<ChargingController> _logger;

        public ChargingController(ILogger<ChargingController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("heat")]
        public PriceAndTaxes getHeat()
        {
            PriceAndTaxes pt = new PriceAndTaxes();
            pt.Currency = "Dkk";
            pt.Price = 222.34;
            pt.Tax = 0.45;
            pt.UnitOfMeassure = "kWh";

            return pt;
        }

        [HttpGet]
        [Route("water")]
        public PriceAndTaxes getWater()
        {
            return null;
        }

        [HttpGet]
        [Route("electricity")]
        public PriceAndTaxes getElectricity()
        {
            return null;
        }
    }
}