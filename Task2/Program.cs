using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //example usage
            int amount = 67;
            int[] coins = { 50, 20, 10, 5, 1 };
            int[] counts = MinSplit(amount, coins);

            for (int i = 0; i < coins.Length; i++)
            {
                Console.WriteLine(coins[i] + " Tetri: " + counts[i]);
            }

        }

        static int[] MinSplit(int amount, int[] coins)
        {
            int[] counts = new int[coins.Length];
            int remainingAmount = amount;

            for(int i = 0; i < coins.Length; i++)
            {
                counts[i] = remainingAmount / coins[i];
                remainingAmount %= coins[i];
            }
            
            return counts;

        }
    }
}
