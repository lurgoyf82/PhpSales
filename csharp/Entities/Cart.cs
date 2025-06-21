using System;
using System.Collections.Generic;

namespace PhpSales.Entities
{
    public class Cart
    {
        private readonly List<Item> _items = new();
        private double _total = 0.0;
        private double _tax = 0.0;

        public void AddItem(Item item)
        {
            _items.Add(item);
            Calculate();
        }

        public IReadOnlyList<Item> GetItems()
        {
            return _items.AsReadOnly();
        }

        public double GetTotal()
        {
            return _total;
        }

        public double GetTax()
        {
            return _tax;
        }

        public void EditItem(int index, Item item)
        {
            try
            {
                if (index >= 0 && index < _items.Count)
                {
                    _items[index] = item;
                    Calculate();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cart.cs EditItem: " + e.Message);
            }
        }

        public void RemoveItem(int index)
        {
            try
            {
                if (index >= 0 && index < _items.Count)
                {
                    _items.RemoveAt(index);
                    Calculate();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cart.cs RemoveItem: " + e.Message);
            }
        }

        private void Calculate()
        {
            _total = 0.0;
            _tax = 0.0;

            foreach (var item in _items)
            {
                _total += item.TaxedPrice;
                _tax += item.Taxes;
            }
        }
    }
}
