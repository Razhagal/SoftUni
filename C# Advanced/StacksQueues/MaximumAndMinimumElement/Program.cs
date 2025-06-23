using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        private static void Main(string[] args)
        {
            int sequencesCount = int.Parse(Console.ReadLine());
            Stack<int> numbersStack = new Stack<int>();

            for (int i = 0; i < sequencesCount; i++)
            {
                int[] sequencePair = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                switch (sequencePair[0])
                {
                    case 1:
                        numbersStack.Push(sequencePair[1]);
                        break;
                    case 2:
                        numbersStack.Pop();
                        break;
                    case 3:
                        if (numbersStack.Count > 0)
                        {
                            Console.WriteLine(GetMaxNumber(ref numbersStack));
                        }
                        break;
                    case 4:
                        if (numbersStack.Count > 0)
                        {
                            Console.WriteLine(GetMinNumber(ref numbersStack));
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbersStack));
        }

        private static int GetMaxNumber(ref Stack<int> numberStack)
        {
            int[] numbersArr = numberStack.ToArray();
            int maxNum = numbersArr[0];
            for (int i = 1; i < numbersArr.Length; i++)
            {
                if (numbersArr[i] > maxNum)
                {
                    maxNum = numbersArr[i];
                }
            }

            return maxNum;
        }

        private static int GetMinNumber(ref Stack<int> numberStack)
        {
            int[] numbersArr = numberStack.ToArray();
            int minNum = numbersArr[0];
            for (int i = 1; i < numbersArr.Length; i++)
            {
                if (numbersArr[i] < minNum)
                {
                    minNum = numbersArr[i];
                }
            }

            return minNum;
        }
    }
}
