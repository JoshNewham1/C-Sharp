using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuOption;
            string input;

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Josh's Word Counter");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-");

            while (true)
            {
                Console.WriteLine("-=-=");
                Console.WriteLine("Menu");
                Console.WriteLine("-=-=");
                Console.WriteLine("(A)dd words and sentences to be counted");
                Console.WriteLine("(R)ead a text file of sentences to count");
                Console.WriteLine("E(x)it the program");
                menuOption = Console.ReadLine().ToUpper();

                while (menuOption == "A")
                {
                    Console.WriteLine("Please write words that you would like to be counted or type 'M' to return to the menu.");
                    input = Console.ReadLine();
                    if (input.ToUpper() == "M")
                    {
                        menuOption = "M";
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine(CountWords(input) + " words");
                    }
                    
                }

                if (menuOption == "X")
                {
                    Environment.Exit(9);
                }
            }
        }

        public static int CountWords (string input)
        {
            MatchCollection words = Regex.Matches(input, @"[\S]+");
            return words.Count;
        }
    }
}
