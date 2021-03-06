﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicChargingService.Service.PriceAndTaxService
{
    public interface IPriceAndTaxService
    {
        Task<PriceAndTaxes> GetPriceAndTax(DateTime timestamp, string type);
        Task SavePriceAndTax(PriceAndTaxes priceAndTax);
        bool CreateDB();
    }
}
