using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInput[col].ToString();
                }
            }

            string searchedSymbol = Console.ReadLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col].Equals(searchedSymbol))
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
        }
    }
}
