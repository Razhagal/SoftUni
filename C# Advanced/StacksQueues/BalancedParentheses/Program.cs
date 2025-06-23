using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> parenthesesStack = new Stack<char>();

            bool isBalanced = true;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '{':
                        parenthesesStack.Push(input[i]);
                        break;
                    case '(':
                        parenthesesStack.Push(input[i]);
                        break;
                    case '[':
                        parenthesesStack.Push(input[i]);
                        break;
                    case '}':
                        if (parenthesesStack.Count == 0 || !parenthesesStack.Peek().Equals('{'))
                        {
                            isBalanced = false;
                        }
                        else
                        {
                            parenthesesStack.Pop();
                        }

                        break;
                    case ')':
                        if (parenthesesStack.Count == 0 || !parenthesesStack.Peek().Equals('('))
                        {
                            isBalanced = false;
                        }
                        else
                        {
                            parenthesesStack.Pop();
                        }

                        break;
                    case ']':
                        if (parenthesesStack.Count == 0 || !parenthesesStack.Peek().Equals('['))
                        {
                            isBalanced = false;
                        }
                        else
                        {
                            parenthesesStack.Pop();
                        }

                        break;
                    case ' ':
                        if (parenthesesStack.Count == 0)
                        {
                            parenthesesStack.Push(input[i]);
                        }
                        else
                        {
                            if (parenthesesStack.Peek().Equals(' '))
                            {
                                parenthesesStack.Pop();
                            }
                            else
                            {
                                char topStackChar = parenthesesStack.Peek();
                                if (topStackChar.Equals('{') || topStackChar.Equals('(') || topStackChar.Equals('['))
                                {
                                    parenthesesStack.Push(input[i]);
                                }
                                else
                                {
                                    isBalanced = false;
                                }
                            }
                        }

                        break;
                }

                if (!isBalanced)
                {
                    break;
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
