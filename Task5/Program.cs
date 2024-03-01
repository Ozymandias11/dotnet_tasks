using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //example usage
            int stairCount = 4;
            Console.WriteLine(CountVariants(stairCount + 1));
        }



        //since a person can only reach top only from (n - 1) th or  (n - 2) th 
        //floor, we can conclude that the number of ways to reach top is the number of ways to reach
        // (n - 1) th floor + the number of ways we can reach (n - 2) th floor;
        static int CountVariants(int stairCount)
        {
            if (stairCount <= 1)
            {
                return stairCount;
            }
            return CountVariants(stairCount - 1) + CountVariants(stairCount - 2);
        }
    }
}
