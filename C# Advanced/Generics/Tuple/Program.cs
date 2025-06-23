using System;

namespace Tuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomTuple<string, string> firstTuple = new CustomTuple<string, string>();

            string nameAndAddress = Console.ReadLine();
            string name = nameAndAddress.Substring(0, nameAndAddress.LastIndexOf(" "));
            string address = nameAndAddress.Substring(nameAndAddress.LastIndexOf(" ") + 1, nameAndAddress.Length - name.Length - 1);
            firstTuple.Item1 = name;
            firstTuple.Item2 = address;

            CustomTuple<string, int> secondTuple = new CustomTuple<string, int>();
            string[] splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            secondTuple.Item1 = splitInput[0];
            secondTuple.Item2 = int.Parse(splitInput[1]);

            CustomTuple<int, double> thirdTuple = new CustomTuple<int, double>();
            splitInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            thirdTuple.Item1 = int.Parse(splitInput[0]);
            thirdTuple.Item2 = double.Parse(splitInput[1]);

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2}");
            Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2}");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2}");
        }
    }
}