using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int rowsCount = int.Parse(input[0]);
            int colsCount = int.Parse(input[1]);

            int[,] matrix = new int[rowsCount, colsCount];
            int totalSum = 0;
            for (int row = 0; row < rowsCount; row++)
            {
                int[] inputRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = inputRow[col];
                    totalSum += inputRow[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(totalSum);
        }
    }
}
