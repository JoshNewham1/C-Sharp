using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] charArray;
            string input;
            string reversedInput;

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Josh's Palindrome Checker");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");

            while (true)
            {
                Console.WriteLine("Please enter a word that you would like to check or type 'Q' to quit.");
                input = Console.ReadLine(); // Reads in the input
                if (input.ToUpper() == "Q") // If the input is 'Q'
                {
                    Environment.Exit(9); // Exit the application
                }
                while (input.Length <= 1) // While the input is smaller or equal to 1 letter long
                {
                    Console.WriteLine("Please specify a word that is longer than 1 digit"); // Ask for another number
                    input = Console.ReadLine(); // Read this in to a variable and check again
                }
                charArray = input.ToCharArray(); // Take the individual characters of the user's input and add them to an array
                Array.Reverse(charArray); // Reverse the order of the array
                reversedInput = new string(charArray); // Convert this array to a string
                if (reversedInput == input) // If the reversed string is the same as the user's input
                {
                    Console.WriteLine("The word '" + input + "' is a palindrome"); // Tells the user their word is a palindrome
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear(); // Clears the screen
                }
                else if (reversedInput != input)
                {
                    Console.WriteLine("The word '" + input + "' is not a palindrome"); // Tells the user their word isn't a palindrome
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear(); // Clears the screen
                }
            }
        }

    }
}

