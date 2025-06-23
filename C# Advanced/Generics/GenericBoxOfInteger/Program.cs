using System;

namespace GenericBoxOfInteger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int inputsCount = int.Parse(Console.ReadLine());
            Box<int> testBox = new Box<int>();

            for (int i = 0; i < inputsCount; i++)
            {
                testBox.Value = int.Parse(Console.ReadLine());
                Console.WriteLine(testBox.ToString());
            }
        }
    }
}