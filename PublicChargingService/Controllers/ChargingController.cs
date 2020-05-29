using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using PublicChargingService.Service.PriceAndTaxService;
using System;
using System.Net;
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
            _priceAndTaxService.CreateDB();
        }

        [HttpGet]
        [Route("heat/{timeStamp}")]
        public async Task<PriceAndTaxes> getHeat(DateTime timeStamp)
        {
            Console.WriteLine(DateTime.Now.ToString() + " - Get Heat Price And Tax Called with timeStamp: " + timeStamp.ToString());
            return await _priceAndTaxService.GetPriceAndTax(timeStamp, "heat");
        }

        [HttpGet]
        [Route("water/{timeStamp}")]
        public async Task<PriceAndTaxes> getWater(DateTime timeStamp)
        {
            Console.WriteLine(DateTime.Now.ToString() + " - Get Water Price And Tax Called with timeStamp: " + timeStamp.ToString());
            return await _priceAndTaxService.GetPriceAndTax(timeStamp, "water");
        }

        [HttpGet]
        [Route("electricity/{timeStamp}")]
        public async Task<PriceAndTaxes> getElectricity(DateTime timeStamp)
        {
            Console.WriteLine(DateTime.Now.ToString() + " - Get Electricity Price And Tax Called with timeStamp: " + timeStamp.ToString());
            return await _priceAndTaxService.GetPriceAndTax(timeStamp, "electricity");
        }
    }
}