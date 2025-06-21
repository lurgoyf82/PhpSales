using System;
using PhpSales.Entities;

namespace PhpSales.Services
{
    public static class TaxCalculator
    {
        public static double CalculateTaxes(Item item)
        {
            double taxes = (item.Price / 100) * item.TaxPercentage;
            if (taxes > 0)
            {
                taxes = Math.Ceiling(taxes * 20) / 20;
            }
            return taxes;
        }
    }
}
