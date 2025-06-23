using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continentsCountriesCitiesDict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continentsCountriesCitiesDict.ContainsKey(continent))
                {
                    continentsCountriesCitiesDict.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continentsCountriesCitiesDict[continent].ContainsKey(country))
                {
                    continentsCountriesCitiesDict[continent].Add(country, new List<string>());
                }

                continentsCountriesCitiesDict[continent][country].Add(city);
            }

            foreach (var continent in continentsCountriesCitiesDict)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
