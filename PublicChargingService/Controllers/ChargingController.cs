using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using PublicChargingService.Service.PriceAndTaxService;
using System;
using System.Threading.Tasks;

namespace PublicChargingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChargingController : ControllerBase
    {
        private readonly ILogger<ChargingController> _logger;
        private readonly IPriceAndTaxService _priceAndTaxService;

        public ChargingController(ILogger<ChargingController> logger, IPriceAndTaxService priceAndTaxService)
        {
            _logger = logger;
            _priceAndTaxService = priceAndTaxService;
        }

        [HttpGet]
        [Route("heat")]
        public async Task<PriceAndTax> getHeat()
        {
            return await _priceAndTaxService.GetPriceAndTax(DateTime.Now, "heat");
        }

        [HttpGet]
        [Route("water")]
        public async Task<PriceAndTax> getWater()
        {
            return await _priceAndTaxService.GetPriceAndTax(DateTime.Now, "water");
        }

        [HttpGet]
        [Route("electricity")]
        public async Task<PriceAndTax> getElectricity()
        {
            return await _priceAndTaxService.GetPriceAndTax(DateTime.Now, "electricity");
        }
    }
}