using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PriceAndTaxes
    {
        public double Price { get; set; }
        public string Currency { get; set; }
        public string UnitOfMeassure { get; set; }
        public double Tax { get; set; }
    }
}
