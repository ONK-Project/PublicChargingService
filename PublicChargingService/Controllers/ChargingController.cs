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
        [Route("heat")]
        public async Task<PriceAndTaxes> getHeat([FromQuery]DateTime dateTime)
        {
            Console.WriteLine(DateTime.Now.ToString() + " - Get Heat Price And Tax Called with timeStamp: " + dateTime.ToString());
            return await _priceAndTaxService.GetPriceAndTax(dateTime, "heat");
        }

        [HttpGet]
        [Route("water")]
        public async Task<PriceAndTaxes> getWater([FromQuery]DateTime dateTime)
        {
            Console.WriteLine(DateTime.Now.ToString() + " - Get Water Price And Tax Called with timeStamp: " + dateTime.ToString());
            return await _priceAndTaxService.GetPriceAndTax(dateTime, "water");
        }

        [HttpGet]
        [Route("electricity")]
        public async Task<PriceAndTaxes> getElectricity([FromQuery]DateTime dateTime)
        {
            Console.WriteLine(DateTime.Now.ToString() + " - Get Electricity Price And Tax Called with timeStamp: " + dateTime.ToString());
            return await _priceAndTaxService.GetPriceAndTax(dateTime, "electricity");
        }
    }
}