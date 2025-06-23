using System;

namespace Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomTuple<string, string, string> firstTuple = new CustomTuple<string, string, string>();

            string[] splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            firstTuple.Item1 = splitInput[0] + " " + splitInput[1];
            firstTuple.Item2 = splitInput[2];

            string townName = string.Empty;
            for (int i = 3; i < splitInput.Length; i++)
            {
                townName += splitInput[i] + " ";
            }

            firstTuple.Item3 = townName;

            CustomTuple<string, int, bool> secondTuple = new CustomTuple<string, int, bool>();
            splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            secondTuple.Item1 = splitInput[0];
            secondTuple.Item2 = int.Parse(splitInput[1]);
            secondTuple.Item3 = splitInput[2].Equals("drunk") ? true : false;

            CustomTuple<string, double, string> thirdTuple = new CustomTuple<string, double, string>();
            splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            thirdTuple.Item1 = splitInput[0];
            thirdTuple.Item2 = double.Parse(splitInput[1]);
            thirdTuple.Item3 = splitInput[2];

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2} -> {firstTuple.Item3}");
            Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2} -> {secondTuple.Item3}");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2} -> {thirdTuple.Item3}");
        }
    }
}