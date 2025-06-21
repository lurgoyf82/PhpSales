using System;
using System.Collections.Generic;
using System.Globalization;
using PhpSales.Entities;

namespace PhpSales.Services
{
    public class InputParser
    {
        private static readonly Dictionary<string, string> ITEMTYPE = new()
        {
            {"book", "book"},
            {"music CD", "other"},
            {"chocolate bar", "food"},
            {"box of chocolates", "food"},
            {"bottle of perfume", "other"},
            {"packet of headache pills", "medical_products"}
        };

        public Item Parse(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Input text cannot be null", nameof(text));

            text = text.Trim();

            int quantityEnd = text.IndexOf(' ');
            var item = new Item();
            item.Quantity = int.Parse(text.Substring(0, quantityEnd));

            int atPos = text.LastIndexOf(" at ");
            item.Price = double.Parse(text[(atPos + 4)..], CultureInfo.InvariantCulture);

            string namePart = text.Substring(quantityEnd + 1, atPos - (quantityEnd + 1)).Trim();

            int importedIndex = namePart.IndexOf("imported", StringComparison.Ordinal);
            if (importedIndex >= 0)
            {
                item.Imported = true;
                item.TaxPercentage = 5;
                namePart = (namePart.Remove(importedIndex, "imported".Length)).Trim();
                item.Name = $"imported {namePart}";
            }
            else
            {
                item.Imported = false;
                item.TaxPercentage = 0;
                item.Name = namePart;
            }

            string typeKey = namePart;
            if (!ITEMTYPE.TryGetValue(typeKey, out var itemType))
            {
                itemType = "other";
            }
            item.ItemType = itemType;

            item.TaxPercentage += itemType switch
            {
                "book" => Taxes.book,
                "food" => Taxes.food,
                "medical_products" => Taxes.medical_products,
                _ => Taxes.other
            };

            item.Taxes = item.Quantity * TaxCalculator.CalculateTaxes(item);
            item.TaxedPrice = (item.Quantity * item.Price) + item.Taxes;

            return item;
        }
    }
}
