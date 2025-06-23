using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> colorClothesCount = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < inputCount; i++)
            {
                string[] inputRow = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = inputRow[0];
                string[] clothes = inputRow[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!colorClothesCount.ContainsKey(color))
                {
                    colorClothesCount.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!colorClothesCount[color].ContainsKey(clothes[j]))
                    {
                        colorClothesCount[color].Add(clothes[j], 0);
                    }

                    colorClothesCount[color][clothes[j]]++;
                }
            }

            string[] searchedCloth = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string searchedColor = searchedCloth[0];
            string clothType = searchedCloth[1];
            foreach (var color in colorClothesCount)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value}");
                    if (color.Key.Equals(searchedColor) && cloth.Key.Equals(clothType))
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
