using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string test1 = "((()()";
            string test2 = "()())(";
            string test3 = "(()(()()(()(";
            string test4 = "()()()";
            string test5 = "(()(()))";


            Console.WriteLine(IsProperly(test1));
            Console.WriteLine(IsProperly(test2));
            Console.WriteLine(IsProperly(test3));
            Console.WriteLine(IsProperly(test4));
            Console.WriteLine(IsProperly(test5));
        }

        static bool IsProperly(string sequence)
        {
            Stack<char> stack = new Stack<char>();
            stack.Push(sequence[0]);
            for (int i = 1; i < sequence.Length; i++)
            {
                if(stack.Count != 0 && sequence[i] == ')' && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else if (sequence[i] == '(')
                {
                    stack.Push(sequence[i]);
                }
            }

            return stack.Count == 0;
        }
    }
}
