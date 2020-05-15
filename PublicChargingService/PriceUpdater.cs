using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using PublicChargingService.Service.PriceAndTaxService;
using Models;

namespace PublicChargingService
{
    public class PriceUpdater
    {
        int _heatUpdateFrequenzyMinutes;
        int _waterUpdateFrequenzyMinutes;
        int _electricityUpdateFrequenzyMinutes;
        private readonly IPriceAndTaxService _priceAndTaxService;

        public PriceUpdater(
            IPriceAndTaxService priceAndTaxService,
            int heatUpdateFrequenzyMinutes,
            int waterUpdateFrequenzyMinutes,
            int electricityUpdateFrequenzyMinutes)
        {
            _priceAndTaxService = priceAndTaxService;
            _heatUpdateFrequenzyMinutes = heatUpdateFrequenzyMinutes;
            _waterUpdateFrequenzyMinutes = waterUpdateFrequenzyMinutes;
            _electricityUpdateFrequenzyMinutes = electricityUpdateFrequenzyMinutes;

            var heatThread = new Thread(new ThreadStart(updateHeatPricing));
            heatThread.Start();

            var waterThread = new Thread(new ThreadStart(updatewaterPricing));
            waterThread.Start();

            var electrictyThread = new Thread(new ThreadStart(updateElectricityPricing));
            electrictyThread.Start();
        }

        public void updateHeatPricing()
        {
            Random rand = new Random();
            while (true)
            {
                _priceAndTaxService.SavePriceAndTax(new PriceAndTax
                {
                    Type = "heat",
                    Price = (rand.NextDouble()*500),
                    Currency = "Dkk",
                    UnitOfMeassure = "kWh/m^3",
                    Tax = (rand.NextDouble() * 100),
                    TimeStamp = DateTime.Now
                });
                Console.WriteLine("HEAT - Pricing Added");
                Thread.Sleep(_heatUpdateFrequenzyMinutes * 60 * 1000);
            }
        }

        public void updatewaterPricing()
        {
            Random rand = new Random();
            while (true)
            {
                _priceAndTaxService.SavePriceAndTax(new PriceAndTax
                {
                    Type = "water",
                    Price = (rand.NextDouble() * 500),
                    Currency = "Dkk",
                    UnitOfMeassure = "m^3",
                    Tax = (rand.NextDouble() * 100),
                    TimeStamp = DateTime.Now
                });
                Console.WriteLine("WATER - Pricing Added");
                Thread.Sleep(_waterUpdateFrequenzyMinutes * 60 * 1000);
            }
        }

        public void updateElectricityPricing()
        {
            Random rand = new Random();
            while (true)
            {
                _priceAndTaxService.SavePriceAndTax(new PriceAndTax
                {
                    Type = "electricity",
                    Price = (rand.NextDouble() * 500),
                    Currency = "Dkk",
                    UnitOfMeassure = "kWh",
                    Tax = (rand.NextDouble() * 100),
                    TimeStamp = DateTime.Now
                });
                Console.WriteLine("ELECTRICITY - Pricing Added");
                Thread.Sleep(_electricityUpdateFrequenzyMinutes * 60 * 1000);
            }
        }
    }
}
