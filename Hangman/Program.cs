using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToGuess; // Initialise a variable to store the user's word to guess
            string wordToGuessWithoutSpaces; // Initialise a variable to store the user's guess without spaces
            int maxGuess = 0; // Initialise a variable for the maximum number of guesses
            string userGuessString; // Initialises a variable for the user's guesses in string form
            char userGuess; // Initialises a variable for the user's guess in char form
            var wordtoguessList = new List<char>(); // Initialise a character list
            var guessedLetterList = new List<char>(); // Initialise a character list
            int i = 0; // Initialise i (for some for loops further on)
            int totalGuesses = 0; // Initialise a variable for the total number of guesses
            while (true)
            {
                totalGuesses = 0; // Reset the total number of guesses
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-="); // Title
                Console.WriteLine("Josh's Hangman Program"); // Screen
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine(); // Leave a space
                Console.WriteLine("Which word would you like to use in Hangman?"); // Asks the user which word they would like to use
                wordToGuess = Console.ReadLine().ToLower(); // Reads this into a variable and converts it to lowercase
                Console.WriteLine("How many guesses would you like to allow?"); // Asks the user for max number of guesses
                maxGuess = Int32.Parse(Regex.Replace(Console.ReadLine(), "[^0-9]", "")); // Strips the response of everything except numbers and converts it to an integer
                guessedLetterList.Clear(); // Clears the guessed letter list
                wordtoguessList.AddRange(wordToGuess); // Adds the wordtoGuess string to a character array
                for (i = 0; i < wordToGuess.Length; i++) // Loops for the length of the word 
                {
                    if (wordToGuess[i] != ' ') // If the character is not a space
                    {
                        guessedLetterList.Add('*'); // Add an asterisk as a placeholder
                    }
                    else // If the character is a space
                    {
                        guessedLetterList.Add(' '); // Add a space
                    }
                    
                }
                for (i = 0; i <= maxGuess; i++) // Loops until the maximum of guesses is achieved
                {
                    int correctGuesses = wordtoguessList.Count; // Count the number of correct guesses
                    Console.Clear(); // Clear the console
                    Console.WriteLine("Please guess a letter"); // Ask the user to guess a letter
                    userGuessString = Console.ReadLine().ToLower(); // Reads this into a variable and converts it to lowercase
                    while (userGuessString.Length != 1) // While the user's guess isn't one character long
                    {
                        Console.WriteLine("Please enter one letter at a time"); // Ask the user to only type one letter
                        userGuessString = Console.ReadLine(); // Read back into variable
                    }
                    userGuess = Convert.ToChar(userGuessString); // Convert the guess string into a char
                    totalGuesses++; // Increment the total number of guesses
                    Console.WriteLine(); // Leave a space
                    while (wordtoguessList.Contains(userGuess)) // While the a character from the word to guess is the same as the user's input
                    {
                        int correctletterPos = wordtoguessList.IndexOf(userGuess); // Store the position of the character in a variable
                        guessedLetterList.RemoveAt(correctletterPos); // Remove the asterisk placeholder
                        guessedLetterList.Insert(correctletterPos, userGuess); // Insert the correct letter in the place of the asterisk
                        wordtoguessList.RemoveAt(correctletterPos); // Remove it from the original list
                        wordtoguessList.Insert(correctletterPos, '*'); // Replace it with a placeholder
                    }
                    while (wordtoguessList.Contains(' ')) // While the word to guest has spaces
                    {
                        int spacePos = wordtoguessList.IndexOf(' '); // Store the position of the space character in a variable
                        wordtoguessList.RemoveAt(spacePos); // Remove the space
                        wordtoguessList.Insert(spacePos, '/'); // Replace it with a forward slash (like in normal hangman)
                    }
                    for (int x = 0; x < guessedLetterList.Count; x++) // For every letter guessed
                    {
                        if (x == 0) // If it is the first letter
                        {
                            Console.Write(guessedLetterList[x].ToString().ToUpper() + " "); // Write it to the screen and capitalise it
                        }
                        else if (wordtoguessList[x] == '/') // If it is a forward slash
                        {
                            Console.Write(" / "); // Write a forward slash to the screen
                        }
                        else // If it is neither the first letter or a forward slash
                        {
                            Console.Write(guessedLetterList[x] + " "); // Write the character to the screen
                        }
                        
                    }
                    string guessedListString = String.Join("", guessedLetterList.ToArray()); // Join together the character list to a string
                    guessedListString = guessedListString.Replace(" ", String.Empty); // Replace any spaces in the string with emptiness
                    wordToGuessWithoutSpaces = wordToGuess.Replace(" ", String.Empty); // Replace any spaces in the string with emptiness
                    if (guessedListString == wordToGuessWithoutSpaces) // If the user's guess matches with the original word to guess
                    {
                        Console.Clear(); // Clear the console
                        Console.WriteLine("Congratulations! The word was " + wordToGuess + " and you guessed it in " + totalGuesses + " guesses"); // Congratulate the user and print how many attempts they took
                        Console.ReadLine(); // Wait for user input
                        break; // Break out of the loop

                    }
                    Console.ReadLine(); // If the user's guess does not match, wait for user input
                }
                if (i == maxGuess) // If the user has ran out of guesses
                {
                    Console.WriteLine("Game over! You have ran out of guesses. Press enter to restart the program"); // Tell them they have ran out
                    Console.ReadLine(); // Wait for user input
                    Console.Clear(); // Clears the console and sends them back to the beginning of the program
                }
                Console.Clear(); // Clears the console

            }


        }
    }
}

