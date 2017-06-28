using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace VowelCounter
{
    class Program
    {
        private static int vowelCount;
        private static int aCount = 0;
        private static int eCount = 0;
        private static int iCount = 0;
        private static int oCount = 0;
        private static int uCount = 0;
        static void Main(string[] args)
        {
            string menuOption;
            string input;
            
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Josh's Vowel Counter");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-=-=");
                Console.WriteLine("Menu");
                Console.WriteLine("-=-=");
                Console.WriteLine("Would you like to:");
                Console.WriteLine("(A)dd sentences manually");
                Console.WriteLine("E(x)it the program");
                menuOption = Console.ReadLine().ToUpper();
                while (menuOption == "A")
                {
                    Console.Clear();
                    Console.WriteLine("Please input words or sentences to count the vowels of. Press 'M' to exit to the menu.");
                    input = Console.ReadLine();
                    if (input.ToUpper() == "M")
                    {
                        menuOption = "M";
                    }
                    else
                    {
                        CountVowels(input);
                        Console.WriteLine("There are " + vowelCount + " vowels in the sentence");
                        Console.WriteLine("Vowels used:");
                        if (aCount > 0)
                        {
                            Console.WriteLine("A: " + aCount);
                        }
                        if (eCount > 0)
                        {
                            Console.WriteLine("E: " + eCount);
                        }
                        if (iCount > 0)
                        {
                            Console.WriteLine("I: " + iCount);
                        }
                        if (oCount > 0)
                        {
                            Console.WriteLine("O: " + oCount);
                        }
                        if (uCount > 0)
                        {
                            Console.WriteLine("U: " + uCount);
                        }
                        Console.ReadLine();
                    }
                }
                if (menuOption == "X")
                {
                    Environment.Exit(9);
                }
            }
        }

        public static int CountVowels (string input)
        {
            aCount = 0; // Resets
            eCount = 0; // All
            iCount = 0; // Of
            oCount = 0; // The
            uCount = 0; // Counts
            vowelCount = input.Count("aeiouAEIOU".Contains); // Count how many times the user's input contains the vowels
            for (int i = 0; i < input.Length; i++) // For each character in input
            {
                if (input[i] == 'a' || input[i] == 'A') // Check if it is an 'a'
                {
                    aCount++; // Increments the counter
                }
                if (input[i] == 'e' || input[i] == 'E') // Check if it is an 'e'
                {
                    eCount++; // Increments the counter
                }
                if (input[i] == 'i' || input[i] == 'I') // Check if it is an 'i'
                {
                    iCount++; // Increments the counter
                }
                if (input[i] == 'o' || input[i] == 'O') // Check if it is an 'o'
                {
                    oCount++; // Increments the counter
                }
                if (input[i] == 'u' || input[i] == 'u') // Check if it is an 'u'
                {
                    uCount++; // Increments the counter
                }
            }
            return vowelCount; // Returns the vowel count to the program
        }
    }
}
