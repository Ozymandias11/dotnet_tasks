using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //some test Cases
            Console.WriteLine(isPalindrome("aba") ? "YES" : "NO"); //YES
            Console.WriteLine(isPalindrome("madam") ? "YES" : "NO"); //YES
            Console.WriteLine(isPalindrome("A man, a plan, a canal, Panama!") ? "YES" : "NO"); //NO
            Console.WriteLine(isPalindrome("Is the string a palindrome?") ? "YES" : "NO"); //NO
        }



        static bool isPalindrome(string input)
        {
            string cleanedInput = removeSpecialChars(input);
            cleanedInput = cleanedInput.ToLower();
            return isPalindromeChecker(cleanedInput);
        }

        // for example: if we are dealing with strings that end with "?", "!" 
        //we should remove that first and then check
        static string removeSpecialChars(string s)
        {
            char[] specialChars = { '!', '.', '?' };
            foreach(char c in specialChars)
            {
                s = s.Replace(c.ToString(), string.Empty);
            }
            return s;
        }
        static bool isPalindromeChecker(string input)
        {
            int left = 0;
            int right = input.Length - 1;

            while(left < right) 
            {
                if (input[left] != input[right]) 
                {
                    return false;
                }

                left++;
                right--;
            }
            return true;
        }
    }
}
