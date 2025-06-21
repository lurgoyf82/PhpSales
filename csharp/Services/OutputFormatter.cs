using System;
using System.Globalization;
using PhpSales.Entities;

namespace PhpSales.Services
{
    public static class OutputFormatter
    {
        private static string FormatItem(Item item)
        {
            return $"{item.Quantity} {item.Name}: {item.TaxedPrice.ToString("F2", CultureInfo.InvariantCulture)}";
        }

        public static void PrintCart(Cart cart)
        {
            foreach (var item in cart.GetItems())
            {
                string formatted = FormatItem(item);
                Console.WriteLine(formatted + "<br />\n");
            }

            Console.WriteLine($"Sales Taxes: {cart.GetTax().ToString("F2", CultureInfo.InvariantCulture)}<br />\n");
            Console.WriteLine($"Total: {cart.GetTotal().ToString("F2", CultureInfo.InvariantCulture)}<br />\n");
        }
    }
}