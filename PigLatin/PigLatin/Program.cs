using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuOption;
            string input;
            string windowsusername = Environment.UserName;
            string path = "C:\\Users\\" + windowsusername + "\\Documents\\piglatin.txt";
            var pigLatinList = new List<string>();
            string showSummary = "";

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Josh's Pig Latin Generator");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");

            while (true)
            {
                Console.WriteLine("-=-=");
                Console.WriteLine("Menu");
                Console.WriteLine("-=-=");
                Console.WriteLine("(A)dd words to be converted to Pig Latin");
                Console.WriteLine("(R)ead a text file of words to convert to Pig Latin");
                Console.WriteLine("E(x)it the program");
                menuOption = Console.ReadLine().ToUpper(); // Asks the user what they would like to do and stores it in a variable

                while (menuOption == "A") // If the user chose to add words manually
                {
                    Console.Clear(); // Clears the console
                    Console.WriteLine("Please enter a word to convert to Pig Latin or type 'M' to return to the menu"); // Asks the user for a word or if they want to return to the menu
                    input = Console.ReadLine(); // Stores the answer in a variable

                    if (input.ToUpper() == "M") // If they have chosen to return to the menu
                    {
                        menuOption = "M"; // Change the menuOption so it will break out of the while loop
                        Console.Clear(); // Clear the console
                    }
                    else // If they have chosen a word
                    {
                        
                        Console.WriteLine(PigLatinGenerator(input)); // Write the word after it has been put through the PigLatinGenerator method
                        Console.ReadLine(); // Waits for user input
                    }
                }
                if (menuOption == "R") // If the user chose to read in from a text file
                {
                    if (File.Exists(path)) // If the file exists
                    {
                        StreamReader sr = new StreamReader(path); // Open a StreamReader on that file
                        while (!sr.EndOfStream) // While there are lines left in the file
                        {
                            input = sr.ReadLine(); // Read a line in to a variable
                            pigLatinList.Add(PigLatinGenerator(input)); // Add the result of that variable being put through the PigLatinGenerator method to a list
                        }
                        Console.WriteLine("Would you like to see a summary?"); // Asks the user if they would like to see a summary
                        showSummary = Console.ReadLine().ToUpper(); // Stores the response in a variable
                        if (showSummary == "Y") // If they would like to see a summary
                        {
                            Console.Clear(); // Clear the console
                            Console.WriteLine("-=-=-=-");
                            Console.WriteLine("Summary");
                            Console.WriteLine("-=-=-=-");
                            for (int i = 0; i < pigLatinList.Count; i++) // For each item in the pigLatinList
                            {
                                Console.WriteLine("Word " + (i + 1) + ": " + pigLatinList[i]); // Print out the item and which number word it is
                                Console.ReadLine(); // Wait for user input
                            }
                            Console.Clear(); // Clears console
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please create a text file here: " + path); // Tells the user where to create the text file
                        Console.ReadLine(); // Waits for user input
                    }
                    
                }
                if (menuOption == "X") // If the user has chosen to exit the program
                {
                    Environment.Exit(9); // Exit with code 9
                }
            }
        }
        public static string PigLatinGenerator (string input) // PigLatinGenerator Method
        {
            string pigLatinWord = ""; // Set the pigLatinWord variable to nothing
            string firstLetter = input.Substring(0, 1); // Set firstLetter to the first letter of the string (Substring(position, length))
            string secondLetter = input.Substring(1, 1); // Set secondLetter to the second letter of the string (Substring(position, length))
            string restofWord = input.Substring(2, (input.Length - 2)); // Set the restofWord to the rest of the string starting at position 2 and continuing on for the length of the word minus the two we have already taken
            bool firstletterVowel = "aeiouAEIOU".IndexOf(firstLetter) >= 0; // If the first letter is a vowel, set the boolean to true
            bool secondletterVowel = "aeiouAEIOU".IndexOf(secondLetter) >= 0; // If the second letter is a vowel, set the boolean to true
            if (firstletterVowel == false) // If the first letter is a consonant
            {
                if (secondletterVowel == false)// And if the second letter is a consonant
                {
                    pigLatinWord = restofWord + firstLetter + secondLetter + "ay"; // Create the pigLatinWord conforming to rules stated on Wikipedia
                }
                else // If only the first letter is a consonant
                {
                    pigLatinWord = secondLetter + restofWord + firstLetter + "ay"; // Create the pigLatinWord conforming to rules stated on Wikipedia
                }

            }
            else if (firstletterVowel == true) // If the first letter is a vowel
            {
                pigLatinWord = input + "way"; // Just add 'way' to the end of input
            }
            return pigLatinWord; // Returns the generated word
        }
    }
}

