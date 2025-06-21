using System;
using PhpSales.Entities;

namespace PhpSales.Services
{
    public static class OutputFormatter
    {
        private static string FormatItem(Item item)
        {
            return $"{item.Quantity} {item.Name}: {item.TaxedPrice:F2}";
        }

        public static void PrintCart(Cart cart)
        {
            foreach (var item in cart.GetItems())
            {
                Console.WriteLine(FormatItem(item));
            }
            Console.WriteLine($"Sales Taxes: {cart.GetTax():F2}");
            Console.WriteLine($"Total: {cart.GetTotal():F2}");
        }
    }
}
