using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(input[0]);
            int colsCount = int.Parse(input[1]);

            int[,] matrix = new int[rowsCount, colsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                int[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int maxFoundSum = int.MinValue;
            int currentSum = 0;
            int maxSumRowIndex = 0;
            int maxSumColIndex = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    currentSum = 0;
                    currentSum += matrix[row, col];
                    currentSum += matrix[row, col + 1];
                    currentSum += matrix[row + 1, col];
                    currentSum += matrix[row + 1, col + 1];


                    currentSum += matrix[row + 2, col];
                    currentSum += matrix[row + 2, col + 1];
                    currentSum += matrix[row, col + 2];
                    currentSum += matrix[row + 1, col + 2];
                    currentSum += matrix[row + 2, col + 2];

                    if (currentSum > maxFoundSum)
                    {
                        maxFoundSum = currentSum;
                        maxSumRowIndex = row;
                        maxSumColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxFoundSum}");
            Console.WriteLine($"{matrix[maxSumRowIndex, maxSumColIndex]} {matrix[maxSumRowIndex, maxSumColIndex + 1]} {matrix[maxSumRowIndex, maxSumColIndex + 2]}");
            Console.WriteLine($"{matrix[maxSumRowIndex + 1, maxSumColIndex]} {matrix[maxSumRowIndex + 1, maxSumColIndex + 1]} {matrix[maxSumRowIndex + 1, maxSumColIndex + 2]}");
            Console.WriteLine($"{matrix[maxSumRowIndex + 2, maxSumColIndex]} {matrix[maxSumRowIndex + 2, maxSumColIndex + 1]} {matrix[maxSumRowIndex + 2, maxSumColIndex + 2]}");
        }
    }
}
