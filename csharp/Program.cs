using System;
using System.Collections.Generic;
using PhpSales.Entities;
using PhpSales.Services;

namespace PhpSales
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = new Dictionary<int, List<string>>
            {
                [1] = new List<string>
                {
                    "2 book at 12.49",
                    "1 music CD at 14.99",
                    "1 chocolate bar at 0.85"
                },
                [2] = new List<string>
                {
                    "1 imported box of chocolates at 10.00",
                    "1 imported bottle of perfume at 47.50"
                },
                [3] = new List<string>
                {
                    "1 imported bottle of perfume at 27.99",
                    "1 bottle of perfume at 18.99",
                    "1 packet of headache pills at 9.75",
                    "3 box of imported chocolates at 11.25"
                },
                [4] = new List<string>
                {
                    "2 bottle of perfume imported at 27.99",
                    "1 bottle of imported perfume at 18.99",
                    "4 packet of imported headache pills at 9.75",
                    "3 box of chocolates at 11.25"
                }
            };

            var inputParser = new InputParser();
            var carts = new Dictionary<int, Cart>();
            int cartNumber = 1;

            foreach (var entry in inputs)
            {
                Console.WriteLine($"Input {cartNumber}:");
                carts[cartNumber] = new Cart();

                foreach (var line in entry.Value)
                {
                    Console.WriteLine(line);
                    carts[cartNumber].AddItem(inputParser.Parse(line));
                }

                Console.WriteLine();
                cartNumber++;
            }

            Console.WriteLine("OUTPUT");
            for (int i = 1; i < cartNumber; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Output {i}:");
                OutputFormatter.PrintCart(carts[i]);
            }
        }
    }
}
