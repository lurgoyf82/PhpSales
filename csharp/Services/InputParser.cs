using System;
using System.Collections.Generic;
using System.Globalization;
using PhpSales.Entities;

namespace PhpSales.Services
{
    public class InputParser
    {
        private string? _text;
        private Item? _item;

        private static readonly Dictionary<string, string> ItemTypeMap = new()
        {
            {"book", "book"},
            {"music CD", "other"},
            {"chocolate bar", "food"},
            {"box of chocolates", "food"},
            {"bottle of perfume", "other"},
            {"packet of headache pills", "medical_products"}
        };

        public InputParser(string? text = null)
        {
            _text = text;
            _item = null;
        }

        public void SetText(string text)
        {
            _text = text;
            _item = null;
        }

        public Item Parse(string? text = null)
        {
            if (text != null)
            {
                SetText(text);
            }

            if (_item != null)
            {
                return _item!;
            }

            if (_text == null)
            {
                throw new ArgumentException("Input text cannot be null");
            }

            Item item = new();
            string line = _text.Trim();

            int firstSpace = line.IndexOf(' ');
            item.Quantity = int.Parse(line.Substring(0, firstSpace));

            int atPos = line.LastIndexOf("at", StringComparison.Ordinal);
            item.Price = double.Parse(line.Substring(atPos + 2).Trim(), CultureInfo.InvariantCulture);

            string description = line.Substring(firstSpace, atPos - firstSpace).Trim();

            int importedIndex = description.IndexOf("imported", StringComparison.Ordinal);
            if (importedIndex == -1)
            {
                item.Imported = false;
                item.TaxPercentage = 0;
                item.Name = description;
            }
            else
            {
                item.Imported = true;
                item.TaxPercentage = 5;
                string withoutImported = (description.Substring(0, importedIndex) + " " + description.Substring(importedIndex + 8)).Trim();
                item.Name = "imported " + withoutImported;
                description = withoutImported;
            }

            item.ItemType = ItemTypeMap.ContainsKey(description) ? ItemTypeMap[description] : "other";
            item.TaxPercentage += item.ItemType switch
            {
                "book" => Taxes.book,
                "food" => Taxes.food,
                "medical_products" => Taxes.medical_products,
                _ => Taxes.other
            };

            item.Taxes = item.Quantity * TaxCalculator.CalculateTaxes(item);
            item.TaxedPrice = (item.Quantity * item.Price) + item.Taxes;

            _item = item;
            return _item;
        }
    }