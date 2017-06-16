using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace LetterList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Josh's Letter List Program");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");

            List<string> dictionary = new List<string>();
            string inputLetter;
            string menuOption;
            string newEntry;
            string delEntry;
            string windowsusername = Environment.UserName;
            string path = "C:\\Users\\" + windowsusername + "\\Documents\\wordlist.txt"; // Default path for text document
            string firstLetter = "F"; // The program will default to chosing words based on their first letters if nothing is inputted

            Console.WriteLine("Would you like to search words based on their (f)irst letters or (a)ll of their letters?");
            firstLetter = Console.ReadLine().ToUpper();
            while (true)
            {
                Console.WriteLine("Please choose a letter and I will print all of the words beginning with that letter. Type '\\' to go to the menu");
                inputLetter = Console.ReadLine();

                if (inputLetter.Length == 1)
                {
                    if (inputLetter == "\\")
                    {
                        Console.Clear();
                        Console.WriteLine("Menu:");
                        Console.WriteLine("(A)dd an item to the dictionary");
                        Console.WriteLine("(R)emove an item from the dictionary");
                        Console.WriteLine("(L)oad a list of words from a text file");
                        Console.WriteLine("(P)rint the dictionary");
                        menuOption = Console.ReadLine().ToUpper();

                        if (menuOption == "A")
                        {
                            Console.WriteLine("Please specify the word you would like to add to the dictionary:");
                            newEntry = Console.ReadLine();
                            dictionary.Add(newEntry);
                        }

                        if (menuOption == "R")
                        {
                            Console.WriteLine("Which item would you like to remove?");
                            delEntry = Console.ReadLine();
                            dictionary.Remove(delEntry);
                        }

                        if (menuOption == "L")
                        {
                            dictionary = File.ReadAllLines(path).ToList();
                            Console.WriteLine("File read successfully.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        
                        if (menuOption == "P")
                        {
                            foreach (string item in dictionary)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                    else if (Regex.IsMatch(inputLetter, @"^[\p{L}]+$"))
                    {
                        if (firstLetter == "F")
                        {
                            foreach (string item in dictionary)
                            {
                                string itemSubstring = item.Substring(0, 1); // Cuts up the string in to just the first character (it is formatted characterposition, length)
                                if (itemSubstring == inputLetter || itemSubstring == inputLetter.ToUpper()) // Checks if the character is equal to what the user inputted
                                {
                                    Console.WriteLine(item); // Prints the item if it is
                                }
                            }
                        }
                        else if (firstLetter == "A")
                        {
                            foreach (string item in dictionary) // For each item in the dictionary
                            {
                                for (int i = 0; i < item.Count(); i++) // Creates a for loop that will iterate the number of characters in the item
                                {
                                    string itemSubstring = item.Substring(i, 1); // Cuts up the string in to a character
                                    if (itemSubstring == inputLetter || itemSubstring == inputLetter.ToUpper()) // Checks if the character is equal to what the user inputted
                                    {
                                        Console.WriteLine(item); // Prints the item if it is
                                    }
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        while (!Regex.IsMatch(inputLetter, @"^[\p{L}]+$"))
                        {
                            Console.WriteLine("Please type a valid letter.");
                            inputLetter = Console.ReadLine();
                        }
                    }
                }
                else
                {
                    while (inputLetter.Length != 1)
                    {
                        Console.WriteLine("Please type a single letter.");
                        inputLetter = Console.ReadLine();
                    }
                }
            }
        }
    }
}
