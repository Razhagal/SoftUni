using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int rowsCount = int.Parse(input[0]);
            int colsCount = int.Parse(input[1]);

            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] inputRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int currentColumnSum = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentColumnSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    currentColumnSum += matrix[row, col];
                }

                Console.WriteLine(currentColumnSum);
            }
        }
    }
}
