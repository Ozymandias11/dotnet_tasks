using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, -2, 0, 3, -4, 5, 0, -6 }; // 2

            int[] numbers2 = { 1, 2, 3, 4, 5 };//6

            int[] numbers3 = { -1, -2, -3, -4, -5 }; //1

            Console.WriteLine(NotContains(numbers));
            Console.WriteLine(NotContains(numbers2));
            Console.WriteLine(NotContains(numbers3));

        }

        static int NotContains(int[] array)
        {
            var filteredNumbers = array.Where(x => x > 0);

            int missingMin = 1;

            foreach(var num in filteredNumbers)
            {
                if(missingMin == num)
                {
                    missingMin++;
                }
                else
                {
                    return missingMin;
                }
            }

            return missingMin;

        }
    }
}
