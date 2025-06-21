using System;

namespace PhpSales.Entities
{
    public class Item
    {
        public string ItemType { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Taxes { get; set; }
        public double TaxedPrice { get; set; }
        public double TaxPercentage { get; set; }
        public int Quantity { get; set; }
        public bool Imported { get; set; }
    }
}
