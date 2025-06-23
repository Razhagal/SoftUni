using System;
using System.Linq;

namespace SquareWithMaxSum
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
                int[] inputRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int maxFoundSum = int.MinValue;
            int currentSum = 0;
            int maxSumRowIndex = 0;
            int maxSumColIndex = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    currentSum = 0;
                    currentSum += matrix[row, col];
                    currentSum += matrix[row, col + 1];
                    currentSum += matrix[row + 1, col];
                    currentSum += matrix[row + 1, col + 1];

                    if (currentSum > maxFoundSum)
                    {
                        maxFoundSum = currentSum;
                        maxSumRowIndex = row;
                        maxSumColIndex = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxSumRowIndex, maxSumColIndex]} {matrix[maxSumRowIndex, maxSumColIndex + 1]}");
            Console.WriteLine($"{matrix[maxSumRowIndex + 1, maxSumColIndex]} {matrix[maxSumRowIndex + 1, maxSumColIndex + 1]}");
            Console.WriteLine(maxFoundSum);
        }
    }
}
