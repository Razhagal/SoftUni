using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    int lineIndex = 1;
                    string readLine = reader.ReadLine();
                    while (readLine != null)
                    {
                        writer.WriteLine($"{lineIndex}. {readLine}");

                        lineIndex++;
                        readLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}