using System;

namespace GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int inputsCount = int.Parse(Console.ReadLine());
            Box<string> testBox = new Box<string>();

            for (int i = 0; i < inputsCount; i++)
            {
                testBox.Value = Console.ReadLine();
                Console.WriteLine(testBox.ToString());
            }
        }
    }
}