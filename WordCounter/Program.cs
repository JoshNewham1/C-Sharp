using System;
using System.Collections.Generic;
using System.IO;
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
            int totalWords = 0;
            string menuOption;
            string input = "";
            string windowsusername = Environment.UserName;
            string path = "C:\\Users\\" + windowsusername + "\\Documents\\wordcounter.txt";
            string showSummary = "";
            var wordCountList = new List<int>();

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

                while (menuOption == "A") // If the user has chosen to add words manually
                {
                    Console.Clear(); // Clear the console
                    Console.WriteLine("Please write words that you would like to be counted or type 'M' to return to the menu."); // Asks the user to write words or type 'M' to return to the menu
                    input = Console.ReadLine(); // Stores the input
                    if (input.ToUpper() == "M") // If the input is 'M' or 'm'
                    {
                        menuOption = "M"; // End the while loop
                        Console.Clear(); // Clear the console
                    }
                    else
                    {
                        Console.WriteLine(CountWords(input) + " words"); // Call the CountWords method and print the amount of words
                        Console.ReadLine(); // Wait for user input
                    }
                    
                }

                if (menuOption == "R") // If the user has chosen to read from a text file
                {
                    Console.Clear(); // Clear the console
                    if (File.Exists(path)) // Check if the text file exists to avoid a FileNotFoundException
                    {
                        StreamReader sr = new StreamReader(path); // Creates a reader for the text file
                        while (!sr.EndOfStream) // While there is text in the text file
                        {
                            input = sr.ReadLine(); // Read a line from the text file in to a variable
                            wordCountList.Add(CountWords(input)); // Add the input to a list for the summary
                        }
                        Console.WriteLine("Would you like to see a summary? "); // Asks the user if they would like to see a summary
                        showSummary = Console.ReadLine().ToUpper(); // Stores the answer in a variable
                        if (showSummary == "Y") // If the user would like to show a summary
                        {
                            Console.WriteLine("-=-=-=-");
                            Console.WriteLine("Summary");
                            Console.WriteLine("-=-=-=-");
                            for (int i = 0; i < wordCountList.Count; i++) // For every line in the list
                            {
                                Console.WriteLine("The number of words in line " + (i + 1) + " is " + wordCountList[i]); // Prints how many words there are in the line
                                totalWords += wordCountList[i]; // Adds the word count for one line to a total word count                     
                            }
                            Console.WriteLine("The total number of words for the text document is " + totalWords); // Prints the total number of words
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }
                    }
                    else // If a text file doesn't exist
                    {
                        Console.WriteLine("Please create a text file here: " + path); // Tell the user to create a text document in the path
                        Console.ReadLine(); // Waits for user input
                    }
                    
                }

                if (menuOption == "X") // If the user has chosen to exit
                {
                    Environment.Exit(9); // Exit with code 9
                }
            }
        }

        public static int CountWords (string input) // CountWords method
        {
            MatchCollection words = Regex.Matches(input, @"[\S]+"); // Seperates each word using a space (\S)
            return words.Count; // Counts how many times the words are seperated
        }
    }
}
