using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputSize = int.Parse(Console.ReadLine());
            double[][] array = new double[inputSize][];

            for (int row = 0; row < inputSize; row++)
            {
                double[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                array[row] = new double[inputRow.Length];
                for (int col = 0; col < inputRow.Length; col++)
                {
                    array[row][col] = inputRow[col];
                }

                if (row > 0)
                {
                    double multiplier = array[row].Length == array[row - 1].Length ? 2 : 0.5d;
                    for (int col = 0; col < array[row - 1].Length; col++)
                    {
                        array[row - 1][col] = (array[row - 1][col] * multiplier);
                    }

                    for (int col = 0; col < array[row].Length; col++)
                    {
                        array[row][col] = (array[row][col] * multiplier);
                    }
                }
            }

            string command = Console.ReadLine();
            while (!command.Equals("End"))
            {
                string[] splitCommand = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(splitCommand[1]);
                int col = int.Parse(splitCommand[2]);
                long value = long.Parse(splitCommand[3]);
                if (IsValidPosition(row, col, ref array))
                {
                    if (splitCommand[0].Equals("Add"))
                    {
                        array[row][col] += value;
                    }
                    else if (splitCommand[0].Equals("Subtract"))
                    {
                        array[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < array.Length; row++)
            {
                for (int col = 0; col < array[row].Length; col++)
                {
                    Console.Write(array[row][col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidPosition(int rowIndex, int colIndex, ref double[][] array)
        {
            if (rowIndex < 0 || rowIndex >= array.Length || colIndex < 0 || colIndex >= array[rowIndex].Length)
            {
                return false;
            }

            return true;
        }
    }
}