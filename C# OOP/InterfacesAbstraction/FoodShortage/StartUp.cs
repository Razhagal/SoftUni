using System;
using System.Collections.Generic;

namespace FoodShortage
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> foodBuyers = new Dictionary<string, IBuyer>();

            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                string inputLine = Console.ReadLine();
                string[] splitInput = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IBuyer buyer;
                if (splitInput.Length == 3)
                {
                    buyer = new Rebel(splitInput[0], int.Parse(splitInput[1]), splitInput[2]);
                }
                else
                {
                    buyer = new Citizen(splitInput[0], int.Parse(splitInput[1]), splitInput[2], splitInput[3]);
                }

                foodBuyers.Add(splitInput[0], buyer);
            }

            string input = Console.ReadLine();
            while (!input.Equals("End"))
            {
                if (foodBuyers.ContainsKey(input))
                {
                    foodBuyers[input].BuyFood();
                }

                input = Console.ReadLine();
            }

            int totalFoodBought = 0;
            foreach (var buyer in foodBuyers.Values)
            {
                totalFoodBought += buyer.Food;
            }

            Console.WriteLine(totalFoodBought);
        }
    }
}
