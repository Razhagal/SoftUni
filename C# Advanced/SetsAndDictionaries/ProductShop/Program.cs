using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsProductsDict = new Dictionary<string, Dictionary<string, double>>();

            string command = Console.ReadLine();
            while (!command.Equals("Revision"))
            {
                string[] commandParts = command.Split(", ");
                string shopName = commandParts[0];
                string productName = commandParts[1];
                double productPrice = double.Parse(commandParts[2]);

                if (!shopsProductsDict.ContainsKey(shopName))
                {
                    shopsProductsDict.Add(shopName, new Dictionary<string, double>());
                }

                shopsProductsDict[shopName].Add(productName, productPrice);

                command = Console.ReadLine();
            }

            shopsProductsDict = shopsProductsDict.OrderBy(s => s.Key).ToDictionary(x => x.Key, p => p.Value);

            foreach (var shop in shopsProductsDict)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
