using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputRowsCount = int.Parse(Console.ReadLine());
            int[][] array = new int[inputRowsCount][];

            for (int row = 0; row < inputRowsCount; row++)
            {
                int[] inputRowValues = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                array[row] = new int[inputRowValues.Length];
                for (int col = 0; col < array[row].Length; col++)
                {
                    array[row][col] = inputRowValues[col];
                }
            }

            string command = Console.ReadLine();
            while (!command.Equals("END"))
            {
                string[] commandParams = command.Split(" ");
                int rowIndex = int.Parse(commandParams[1]);
                int colIndex = int.Parse(commandParams[2]);
                int value = int.Parse(commandParams[3]);
                if (IsValidPosition(rowIndex, colIndex, ref array))
                {
                    if (commandParams[0].Equals("Add"))
                    {
                        array[rowIndex][colIndex] += value;
                    }
                    else if (commandParams[0].Equals("Subtract"))
                    {
                        array[rowIndex][colIndex] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
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

        private static bool IsValidPosition(int rowIndex, int colIndex, ref int[][] jaggedArray)
        {
            if (rowIndex < 0 || rowIndex > jaggedArray.Length - 1 || colIndex < 0 || colIndex > jaggedArray[rowIndex].Length - 1)
            {
                return false;
            }

            return true;
        }
    }
}
