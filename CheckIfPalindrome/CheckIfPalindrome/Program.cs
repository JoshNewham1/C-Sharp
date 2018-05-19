using System;
using System.Collections.Generic;
using System.IO;
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
            var palindromesList = new List<string>();
            string input;
            string menuOption;
            string reversedInput;
            string windowsusername = Environment.UserName;
            string path = "C:\\Users\\" + windowsusername + "\\Documents\\palindromelist.txt";
            int numberofPalindromes = 0;
            string printPalindromes;

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Josh's Palindrome Checker");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");

            while (true)
            {
                Console.WriteLine("-=-=");
                Console.WriteLine("Menu");
                Console.WriteLine("-=-=");
                Console.WriteLine("(A)dd words to be checked");
                Console.WriteLine("(R)ead a list of words from a text file");
                Console.WriteLine("E(x)it the program");
                menuOption = Console.ReadLine().ToUpper();

                while (menuOption == "A")
                {
                    Console.WriteLine("Please enter a word that you would like to check or type 'M' to enter the menu.");
                    input = Console.ReadLine(); // Reads in the input
                    if (input.ToUpper() == "M") // If the input is 'M'
                    {
                        menuOption = "M";
                        Console.Clear();
                    }
                    else
                    {
                        while (input.Length <= 1) // While the input is smaller or equal to 1 letter long
                        {
                            Console.WriteLine("Please specify a word that is longer than 1 digit"); // Ask for another number
                            input = Console.ReadLine(); // Read this in to a variable and check again
                        }
                        input = input.ToLower(); // Palindromes aren't case sensitive so the input is converted to lower case
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

                if (menuOption == "R")
                {
                    StreamReader sr = new StreamReader(path); // Creates a reader and specifies the path of the text file
                    while (!sr.EndOfStream)
                    {
                        input = sr.ReadLine().ToLower(); // Reads a line from the text document and converts it to lower case
                        charArray = input.ToCharArray(); // Take the individual characters of the user's input and add them to an array
                        Array.Reverse(charArray); // Reverses the order of the array
                        reversedInput = new string(charArray); // Converts the array to a string
                        if (reversedInput == input) // Checks if the reversed input is the same as the regular input
                        {
                            numberofPalindromes++; // Increments the numberofPalindromes
                            palindromesList.Add(input); // Adds the palindrome to a list which can be printed later on
                        }
                    }
                    Console.WriteLine("-=-=-=-");
                    Console.WriteLine("Summary");
                    Console.WriteLine("-=-=-=-");
                    Console.WriteLine("There were " + numberofPalindromes + " palindrome(s) in the text file"); // Tells the user how many palindromes were in the file
                    Console.WriteLine("Would you like to print the words that were palindromes?"); // Asks the user if they would like to print the palindromes
                    printPalindromes = Console.ReadLine().ToUpper(); // Reads the user's answer and converts it to upper case
                    if (printPalindromes == "Y") // If the user typed Y
                    {
                        for (int i = 0; i < palindromesList.Count; i++) // For every palindrome in the list
                        {
                            Console.WriteLine(palindromesList[i]); // Print it out
                        }
                        Console.ReadLine(); // Wait for user input
                        Console.Clear(); // Clear the console
                    }
                }

                if (menuOption == "X")
                {
                    Environment.Exit(9);
                }

                
            }
        }
    }
}


