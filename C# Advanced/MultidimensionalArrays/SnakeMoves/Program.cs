using System;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string snakeWord = Console.ReadLine();

            int inputRows = int.Parse(inputDimensions[0]);
            int inputCols = int.Parse(inputDimensions[1]);
            string[,] matrix = new string[inputRows, inputCols];

            int currentWordIndex = 0;
            for (int row = 0; row < inputRows; row++)
            {
                string direction = (row + 1) % 2 == 0 ? "left" : "right";
                for (int col = 0; col < inputCols; col++)
                {
                    if (direction.Equals("right"))
                    {
                        matrix[row, col] = snakeWord[currentWordIndex].ToString();
                    }
                    else
                    {
                        matrix[row, inputCols - col - 1] = snakeWord[currentWordIndex].ToString();
                    }

                    currentWordIndex++;
                    if (currentWordIndex >= snakeWord.Length)
                    {
                        currentWordIndex = 0;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
