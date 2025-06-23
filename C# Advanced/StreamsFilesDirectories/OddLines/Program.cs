using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    int lineIndex = 0;
                    string readLine = reader.ReadLine();
                    while (readLine != null)
                    {
                        if (lineIndex % 2 == 1)
                        {
                            writer.WriteLine(readLine);
                        }

                        lineIndex++;
                        readLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
